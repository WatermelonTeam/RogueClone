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

        public BoardFactory(Position topLeftCorner, Position bottomRightCorner)
        {
            this.TopLeftCorner = topLeftCorner;
            this.BottomRightCorner = bottomRightCorner;
            this.TotalCols = this.BottomRightCorner.X - this.TopLeftCorner.X + 1;
            this.TotalRows = this.BottomRightCorner.Y - this.TopLeftCorner.Y + 1;
            this.PortionRows = this.TotalRows / 3 + 5;
            this.PortionCols = this.TotalCols / 3 + 10;

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
        private Position TopLeftCorner { get; set; }
        private Position BottomRightCorner { get; set; }
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
            Position entryPortion = new Position();
            Position exitPortion = new Position();
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
            List<Position> removedPortions = new List<Position>(new Position[]{
                                            new Position(0, 0), new Position(0, 1), new Position(0, 2),
                                            new Position(1, 0), new Position(1, 1), new Position(1, 2),
                                            new Position(2, 0), new Position(2, 1), new Position(2, 2)
                                                                             });
            var allPortions = new List<Position>(removedPortions);
            
            var portionsWithRooms = new List<Position>();
            var doorsPositions = new List<List<Position>>();
            removedPortions.Remove(entryPortion);
            removedPortions.Remove(exitPortion);
            while (removedPortions.Count != removedCount)
            {
                removedPortions.RemoveAt(BoardFactory.rand.Next(0, removedPortions.Count));
            }

            if (removedCount >= 4)
            {
                // there should not be any lonely room in its row and column for corridors to work 
                var leftPortions = allPortions.Except(removedPortions);
                bool lonelyRoom = true;
                while (lonelyRoom)
                {
                    foreach (var portion in leftPortions)
                    {
                        if (portion.X == portion.Y || portion.X - portion.Y == 2)
                        {
                            if (leftPortions.Count(p => p.X == portion.X) == 1 && leftPortions.Count(p => p.Y == portion.Y) == 1)
                            {
                                lonelyRoom = true;
                                removedPortions.RemoveAt(0);
                                break;
                            }
                        }
                        else
                        {
                            lonelyRoom = false;
                        }
                    }
                }
            }

            for (int portionRow = 0; portionRow < 3; portionRow++)
            {
                for (int portionCol = 0; portionCol < 3; portionCol++)
                {
                    if (removedPortions.Any(port => port.X == portionRow && port.Y == portionCol))
                    {
                        continue;
                    }
                    portionsWithRooms.Add(new Position(portionRow, portionCol));
                    doorsPositions.Add(new List<Position>());


                    int roomRows = BoardFactory.rand.Next(0, this.PortionRows - BoardFactory.MinRoomRows) + BoardFactory.MinRoomRows;
                    int roomCols = BoardFactory.rand.Next(0, this.PortionCols - BoardFactory.MinRoomCols) + BoardFactory.MinRoomCols;
                    Position doorPos = new Position(roomRows / 2, roomCols / 2);
                    Position start = new Position();
                    start.X = BoardFactory.rand.Next(0, this.PortionRows - roomRows);
                    start.Y = BoardFactory.rand.Next(0, this.PortionCols - roomCols);

                    bool atEntryPortion = entryPortion.X == portionRow && entryPortion.Y == portionCol;
                    bool atExitPortion = exitPortion.X == portionRow && exitPortion.Y == portionCol;

                    Position entry = new Position();
                    if (atEntryPortion)
                    {
                        entry.X = BoardFactory.rand.Next(1, roomRows - 2);
                        entry.Y = BoardFactory.rand.Next(1, roomCols - 2);
                    }

                    Position exit = new Position();
                    if (atExitPortion)
                    {
                        exit.X = BoardFactory.rand.Next(1, roomRows - 2);
                        exit.Y = BoardFactory.rand.Next(1, roomCols - 2);
                    }

                    for (int row = 0; row < roomRows; row++)
                    {
                        for (int col = 0; col < roomCols; col++)
                        {
                            int y = this.TopLeftCorner.Y + start.X + row + portionRow * this.PortionRows;
                            int x = this.TopLeftCorner.X + start.Y + col + portionCol * this.PortionCols;

                            if ((row == 0 && col == 0) || (row == 0 && col == roomCols - 1) || (row == roomRows - 1 && col == 0) || (row == roomRows - 1 && col == roomCols - 1))
                            {
                                board.CornersPos.Add(new Position(x, y));
                            }
                            else if (row == 0)
                            {
                                if (portionRow != 0 && col == doorPos.Y)
                                {
                                    board.DoorsPos.Add(new Position(x, y));
                                    doorsPositions[doorsPositions.Count - 1].Add(board.DoorsPos[board.DoorsPos.Count - 1]);
                                }
                                else
                                {
                                    board.HorizontalWallsPos.Add(new Position(x, y));
                                }
                            }
                            else if (row == roomRows - 1)
                            {
                                if (portionRow != 2 && col == doorPos.Y)
                                {
                                    board.DoorsPos.Add(new Position(x, y)); 
                                    doorsPositions[doorsPositions.Count - 1].Add(board.DoorsPos[board.DoorsPos.Count - 1]);  
                                }
                                else
                                {
                                    board.HorizontalWallsPos.Add(new Position(x, y));                                
                                }
                            }
                            else if (col == 0)
                            {
                                if (portionCol != 0 && row == doorPos.X)
                                {
                                    board.DoorsPos.Add(new Position(x, y));
                                    doorsPositions[doorsPositions.Count - 1].Add(board.DoorsPos[board.DoorsPos.Count - 1]);
                                }
                                else
                                {
                                    board.VerticalWallsPos.Add(new Position(x, y));
                                }
                            }
                            else if (col == roomCols - 1)                            
                            {
                                if (portionCol != 2 && row == doorPos.X)
                                {
                                    board.DoorsPos.Add(new Position(x, y));
                                    doorsPositions[doorsPositions.Count - 1].Add(board.DoorsPos[board.DoorsPos.Count - 1]);
                                }
                                else
                                {
                                    board.VerticalWallsPos.Add(new Position(x, y));
                                }
                            }
                            else if (atEntryPortion && row == entry.X && col == entry.Y)
                            {
                                board.EntryStairPos = new Position(x, y);
                            }
                            else if (atExitPortion && row == exit.X && col == exit.Y)
                            {
                                board.ExitStairPos = new Position(x, y);
                            }
                            else
                            {
                                board.FloorsPos.Add(new Position(x, y));
                            }
                        }
                    }
                }
            }

            var updatedDoorsPos = new List<Position>();
            var currentDoor = new Position();
            var otherDoor = new Position();
            for (int i = 0; i < portionsWithRooms.Count; i++)
            {
                currentDoor = doorsPositions[i].OrderByDescending(d => d.Y).First();
                for (int j = i + 1; j < portionsWithRooms.Count; j++)
                {
                    if (portionsWithRooms[i].X == portionsWithRooms[j].X)
                    {
                        otherDoor = doorsPositions[j].OrderBy(d => d.Y).First();
                        var distance = otherDoor.Y - currentDoor.Y;
                        var offset = otherDoor.X - currentDoor.X;
                        for (int k = currentDoor.Y + 1; k <= currentDoor.Y + distance / 2; k++)
                        {
                            board.CorridorsPos.Add(new Position(currentDoor.X, k));
                        }
                        for (int k = currentDoor.Y + distance / 2; k < otherDoor.Y; k++)
                        {
                            board.CorridorsPos.Add(new Position(otherDoor.X, k));
                        }
                        if (offset > 1)
                        {
                            for (int l = 1; l < offset; l++)
                            {
                                board.CorridorsPos.Add(new Position(l + currentDoor.X, currentDoor.Y + distance / 2));
                            }
                        }
                        else if (offset < -1)
                        {
                            offset = -offset;
                            for (int l = 1; l < offset; l++)
                            {
                                board.CorridorsPos.Add(new Position(l + otherDoor.X, currentDoor.Y + distance / 2));
                            }
                        }
                        updatedDoorsPos.Add(currentDoor);
                        updatedDoorsPos.Add(otherDoor);
                        break;
                    }
                }

                currentDoor = doorsPositions[i].OrderByDescending(d => d.X).First();
                for (int j = i + 1; j < portionsWithRooms.Count; j++)
                {
                    if (portionsWithRooms[i].Y == portionsWithRooms[j].Y)
                    {
                        otherDoor = doorsPositions[j].OrderBy(d => d.X).First();
                        var distance = otherDoor.X - currentDoor.X;
                        var offset = otherDoor.Y - currentDoor.Y;
                        for (int k = currentDoor.X + 1; k <= currentDoor.X + distance / 2; k++)
                        {
                            board.CorridorsPos.Add(new Position(k, currentDoor.Y));
                        }
                        for (int k = currentDoor.X + distance / 2; k < otherDoor.X; k++)
                        {
                            board.CorridorsPos.Add(new Position(k, otherDoor.Y));
                        }
                        if (offset > 1)
                        {
                            for (int l = 1; l < offset; l++)
                            {
                                board.CorridorsPos.Add(new Position(currentDoor.X + distance / 2, l + currentDoor.Y));
                            }
                        }
                        else if (offset < -1)
                        {
                            offset = -offset;
                            for (int l = 1; l < offset; l++)
                            {
                                board.CorridorsPos.Add(new Position(currentDoor.X + distance / 2, l + otherDoor.Y));
                            }
                        }
                        updatedDoorsPos.Add(currentDoor);
                        updatedDoorsPos.Add(otherDoor);
                        break;
                    }
                }
            }
            board.DoorsPos.Clear();
            board.DoorsPos.AddRange(updatedDoorsPos);
        }
        private void SetGoldAndItems(Board board)
        {
            for (int i = 0; i < this.MaxItemCount; i++)
            {
                int check = BoardFactory.rand.Next(0, 100);

                if (check < this.ItemChance)
                {
                    int randomFloor = BoardFactory.rand.Next(0, board.FloorsPos.Count);
                    board.ItemsPos.Add(board.FloorsPos[randomFloor]);   
                    board.FloorsPos.RemoveAt(randomFloor);
                }
            }

            for (int i = 0; i < this.MaxGoldCount; i++)
            {
                int check = BoardFactory.rand.Next(0, 100);

                if (check < this.GoldChance)
                {
                    int randomFloor = BoardFactory.rand.Next(0, board.FloorsPos.Count);
                    board.GoldPositionsPos.Add(board.FloorsPos[randomFloor]);
                    board.Items.Add(new HealthPotion(board.FloorsPos[randomFloor]));//////////////////////////////////////////////////////////
                    board.FloorsPos.RemoveAt(randomFloor);
                }
            }
        }
        private void SetShopKeeper(Board board)
        {
            int check = BoardFactory.rand.Next(0, 100);
            if (check < this.ShopKeeperChance)
            {
                int randomFloor = BoardFactory.rand.Next(0, board.FloorsPos.Count);
                board.ShopKeeperPos = board.FloorsPos[randomFloor];
                board.FloorsPos.RemoveAt(randomFloor);
            }
        }
    }
}

// TODO: OOP board with no magic numbers