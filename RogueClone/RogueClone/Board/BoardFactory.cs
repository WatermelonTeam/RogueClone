namespace RogueClone
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BoardFactory
    {
        private const int MinRoomRows = 5;
        private const int MinRoomCols = 10;

        private static Random rand = new Random();
        private int totalRows;
        private int totalCols;
        private int itemChance;
        private int maxItemCount;
        private int goldChance;
        private int maxGoldCount;
        private int shopKeeperChance;

        public BoardFactory(Point2D topLeftCorner, Point2D bottomRightCorner)
        {
            this.TopLeftCorner = topLeftCorner;
            this.BottomRightCorner = bottomRightCorner;
            this.TotalRows = this.BottomRightCorner.X - this.TopLeftCorner.X + 1;
            this.TotalCols = this.BottomRightCorner.Y - this.TopLeftCorner.Y + 1;
            this.PortionRows = this.TotalRows / 3;
            this.PortionCols = this.TotalCols / 3;

            this.ItemChance = 35;
            this.MaxItemCount = 7;
            this.GoldChance = 35;
            this.MaxGoldCount = 10;
            this.ShopKeeperChance = 100; //Change this to 10;
        }

        public int ItemChance
        {
            get
            {
                return this.itemChance;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Chance must be between 0 and 100.");
                }

                this.itemChance = value;
            }
        }
        public int MaxItemCount
        {
            get
            {
                return this.maxItemCount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MaxItemCount can't be less than zero.");
                }

                this.maxItemCount = value;
            }
        }
        public int GoldChance
        {
            get
            {
                return this.goldChance;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Chance must be between 0 and 100.");
                }

                this.goldChance = value;
            }
        }
        public int MaxGoldCount
        {
            get
            {
                return this.maxGoldCount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MaxGoldCount can't be less than zero.");
                }

                this.maxGoldCount = value;
            }
        }
        public int ShopKeeperChance
        {
            get
            {
                return this.shopKeeperChance;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Chance must be between 0 and 100.");
                }

                this.shopKeeperChance = value;
            }
        }
        private Point2D TopLeftCorner { get; set; }
        private Point2D BottomRightCorner { get; set; }
        private int TotalRows
        {
            get
            {
                return this.totalRows;
            }
            set
            {
                if (value < (BoardFactory.MinRoomRows * 3) + 2)
                {
                    throw new ArgumentException("Not enough rows for rooms and paths.");
                }

                this.totalRows = value;
            }
        }
        private int TotalCols
        {
            get
            {
                return this.totalCols;
            }
            set
            {
                if (value < (BoardFactory.MinRoomCols * 3) + 2)
                {
                    throw new ArgumentException("Not enough cols for rooms and paths.");
                }

                this.totalCols = value;
            }
        }
        private int PortionRows { get; set; }
        private int PortionCols { get; set; }

        public Board GenerateBoard()
        {
            Board result = new Board();

            int roomRows = BoardFactory.rand.Next(0, this.PortionRows - BoardFactory.MinRoomRows + 1) + BoardFactory.MinRoomRows;
            int roomCols = BoardFactory.rand.Next(0, this.PortionCols - BoardFactory.MinRoomCols + 1) + BoardFactory.MinRoomCols;

            SetRooms(result);
            SetGoldAndItems(result);
            SetShopKeeper(result);
            
            return result;
        }
        private void SetRooms(Board board)
        {
            Point2D entryPortion = new Point2D();
            Point2D exitPortion = new Point2D();
            int stairsRoom = BoardFactory.rand.Next(0, 4);
            switch (stairsRoom)
            {
                case 0:
                    entryPortion.X = 0;
                    entryPortion.Y = 0;
                    exitPortion.X = 2;
                    exitPortion.Y = 2;
                    break;
                case 1:
                    entryPortion.X = 2;
                    entryPortion.Y = 2;
                    exitPortion.X = 0;
                    exitPortion.Y = 0;
                    break;
                case 2:
                    entryPortion.X = 0;
                    entryPortion.Y = 2;
                    exitPortion.X = 2;
                    exitPortion.Y = 0;
                    break;
                case 3:
                    entryPortion.X = 2;
                    entryPortion.Y = 0;
                    exitPortion.X = 0;
                    exitPortion.Y = 2;
                    break;
                default:
                    throw new Exception("Something went horribly wrong in switch at BoardFactory.");
            }

            int removedCount = BoardFactory.rand.Next(0, 5);
            List<Point2D> removedPortions = new List<Point2D>(new Point2D[]{
                                            new Point2D(0, 0), new Point2D(0, 1), new Point2D(0, 2),
                                            new Point2D(1, 0), new Point2D(1, 1), new Point2D(1, 2),
                                            new Point2D(2, 0), new Point2D(2, 1), new Point2D(2, 2)
                                                                             });
            removedPortions.Remove(entryPortion);
            removedPortions.Remove(exitPortion);
            while (removedPortions.Count != removedCount)
            {
                removedPortions.RemoveAt(BoardFactory.rand.Next(0, removedPortions.Count));
            }

            for (int portionRow = 0; portionRow < 3; portionRow++)
            {
                for (int portionCol = 0; portionCol < 3; portionCol++)
                {
                    if (removedPortions.Any(port => port.X == portionRow && port.Y == portionCol))
                    {
                        continue;
                    }

                    int roomRows = BoardFactory.rand.Next(0, this.PortionRows - BoardFactory.MinRoomRows) + BoardFactory.MinRoomRows;
                    int roomCols = BoardFactory.rand.Next(0, this.PortionCols - BoardFactory.MinRoomCols) + BoardFactory.MinRoomCols;
                    Point2D doorPos = new Point2D(roomRows / 2, roomCols / 2);
                    Point2D start = new Point2D();
                    start.X = BoardFactory.rand.Next(0, this.PortionRows - roomRows);
                    start.Y = BoardFactory.rand.Next(0, this.PortionCols - roomCols);

                    bool atEntryPortion = entryPortion.X == portionRow && entryPortion.Y == portionCol;
                    bool atExitPortion = exitPortion.X == portionRow && exitPortion.Y == portionCol;

                    Point2D entry = new Point2D();
                    if (atEntryPortion)
                    {
                        entry.X = BoardFactory.rand.Next(1, roomRows - 2);
                        entry.Y = BoardFactory.rand.Next(1, roomCols - 2);
                    }

                    Point2D exit = new Point2D();
                    if (atExitPortion)
                    {
                        exit.X = BoardFactory.rand.Next(1, roomRows - 2);
                        exit.Y = BoardFactory.rand.Next(1, roomCols - 2);
                    }

                    for (int row = 0; row < roomRows; row++)
                    {
                        for (int col = 0; col < roomCols; col++)
                        {
                            if ((row == 0 && col == 0) || (row == 0 && col == roomCols - 1) || (row == roomRows - 1 && col == 0) || (row == roomRows - 1 && col == roomCols - 1))
                            {
                                board.Corners.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));
                            }
                            else if (row == 0)
                            {
                                if (portionRow != 0 && col == doorPos.Y)
                                {
                                    board.Doors.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));                                    
                                }
                                else
                                {
                                    board.HorizontalWalls.Add(new Point2D(this.TopLeftCorner.X + start.X  + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));
                                }
                            }
                            else if (row == roomRows - 1)
                            {
                                if (portionRow != 2 && col == doorPos.Y)
                                {
                                    board.Doors.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));                                                                    
                                }
                                else
                                {
                                    board.HorizontalWalls.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));                                
                                }
                            }
                            else if (col == 0)
                            {
                                if (portionCol != 0 && row == doorPos.X)
                                {
                                    board.Doors.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));                                    
                                }
                                else
                                {
                                    board.VerticalWalls.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));
                                }
                            }
                            else if (col == roomCols - 1)                            
                            {
                                if (portionCol != 2 && row == doorPos.X)
                                {
                                    board.Doors.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));
                                }
                                else
                                {
                                    board.VerticalWalls.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols));
                                }
                            }
                            else if (atEntryPortion && row == entry.X && col == entry.Y)
                            {
                                board.EntryStair = new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.Y + start.Y + col + portionCol * this.PortionCols);
                            }
                            else if (atExitPortion && row == exit.X && col == exit.Y)
                            {
                                board.ExitStair = new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.X + start.Y + col + portionCol * this.PortionCols);
                            }
                            else
                            {
                                board.Floors.Add(new Point2D(this.TopLeftCorner.X + start.X + row + portionRow * this.PortionRows, this.TopLeftCorner.X + start.Y + col + portionCol * this.PortionCols));
                            }
                        }
                    }
                }
            }

        }
        private void SetGoldAndItems(Board board)
        {
            for (int i = 0; i < this.MaxItemCount; i++)
            {
                int check = BoardFactory.rand.Next(0, 100);

                if (check < this.ItemChance)
                {
                    int randomFloor = BoardFactory.rand.Next(0, board.Floors.Count);
                    board.Items.Add(board.Floors[randomFloor]);
                    board.Floors.RemoveAt(randomFloor);
                }
            }

            for (int i = 0; i < this.MaxGoldCount; i++)
            {
                int check = BoardFactory.rand.Next(0, 100);

                if (check < this.GoldChance)
                {
                    int randomFloor = BoardFactory.rand.Next(0, board.Floors.Count);
                    board.GoldPostions.Add(board.Floors[randomFloor]);
                    board.Floors.RemoveAt(randomFloor);
                }
            }
        }
        private void SetShopKeeper(Board board)
        {
            int check = BoardFactory.rand.Next(0, 100);
            if (check < this.ShopKeeperChance)
            {
                int randomFloor = BoardFactory.rand.Next(0, board.Floors.Count);
                board.ShopKeeper = board.Floors[randomFloor];
                board.Floors.RemoveAt(randomFloor);
            }
        }
    }
}