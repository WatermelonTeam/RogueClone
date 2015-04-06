namespace RogueClone
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BoardFactory
    {
        private readonly ICollection<BoardPositionable> BoardPositionables;

        private const int MaxItemCount = 5;
        private const int MaxShopkeeperCount = 1;
        private const int MaxGoldCount = 10;
        private const int ItemLargeProbability = 10;
        private const int ItemSmallProbability = 5;
        private const int ShopkeeperProbability = 10;
        private const int GoldProbability = 25;
        private const int MinRoomRows = 5;
        private const int MinRoomCols = 10;

        private static Random rand = new Random();
        private int totalRows;
        private int totalCols;

        public BoardFactory(Position topLeftCorner, Position bottomRightCorner)
        {
            this.TopLeftCorner = topLeftCorner;
            this.BottomRightCorner = bottomRightCorner;
            this.TotalCols = this.BottomRightCorner.X - this.TopLeftCorner.X + 1;
            this.TotalRows = this.BottomRightCorner.Y - this.TopLeftCorner.Y + 1;
            this.PortionRows = this.TotalRows / 3 + 5;
            this.PortionCols = this.TotalCols / 3 + 12;

            BoardPositionables = new List<BoardPositionable>()
            {
                new BoardPositionable("Gold", GoldProbability, MaxGoldCount),
                new BoardPositionable("HealthPotion", ItemLargeProbability, MaxItemCount),
                new BoardPositionable("ManaPotion", ItemLargeProbability, MaxItemCount),
                new BoardPositionable("RogueArmorStrong", ItemSmallProbability, MaxItemCount),
                new BoardPositionable("RogueArmorWeak", ItemSmallProbability, MaxItemCount),
                new BoardPositionable("WizardArmorStrong", ItemSmallProbability, MaxItemCount),
                new BoardPositionable("WizardArmorWeak", ItemSmallProbability, MaxItemCount),
                new BoardPositionable("RogueWeaponStrong", ItemSmallProbability, MaxItemCount),
                new BoardPositionable("RogueWeaponWeak", ItemSmallProbability, MaxItemCount),
                new BoardPositionable("WizardWeaponStrong", ItemSmallProbability, MaxItemCount), 
                new BoardPositionable("WizardWeaponWeak", ItemSmallProbability, MaxItemCount),
                new BoardPositionable("Trinket", ItemLargeProbability, MaxItemCount),
                new BoardPositionable("ShopKeeper", ShopkeeperProbability, MaxShopkeeperCount),
            };
            
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
            SetPositionables(result);
            
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
                currentDoor = doorsPositions[i].OrderByDescending(d => d.X).First();
                for (int j = i + 1; j < portionsWithRooms.Count; j++)
                {
                    if (portionsWithRooms[i].X == portionsWithRooms[j].X)
                    {
                        otherDoor = doorsPositions[j].OrderBy(d => d.X).First();
                        var distance = otherDoor.X - currentDoor.X;
                        var offset = otherDoor.Y - currentDoor.Y;
                        for (int k = currentDoor.X - 1; k <= currentDoor.X + distance / 2; k++)
                        {
                            board.CorridorsPos.Add(new Position(k, currentDoor.Y));
                        }
                        for (int k = currentDoor.X + distance / 2; k <= otherDoor.X + 1; k++)
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
                        //board.DoorsPos.Add(new Position(currentDoor.X - 1, currentDoor.Y));
                        //board.DoorsPos.Add(new Position(otherDoor.X + 1, otherDoor.Y));
                        board.FloorsPos.Remove(new Position(currentDoor.X - 1, currentDoor.Y));
                        board.FloorsPos.Remove(new Position(otherDoor.X + 1, otherDoor.Y));
                        //board.DoorsPos.Remove(currentDoor);
                        //board.DoorsPos.Remove(otherDoor);
                        updatedDoorsPos.Add(currentDoor);
                        updatedDoorsPos.Add(otherDoor);
                        break;
                    }
                }

                currentDoor = doorsPositions[i].OrderByDescending(d => d.Y).First();
                for (int j = i + 1; j < portionsWithRooms.Count; j++)
                {
                    if (portionsWithRooms[i].Y == portionsWithRooms[j].Y)
                    {
                        otherDoor = doorsPositions[j].OrderBy(d => d.Y).First();
                        var distance = otherDoor.Y - currentDoor.Y;
                        var offset = otherDoor.X - currentDoor.X;
                        for (int k = currentDoor.Y - 1; k <= currentDoor.Y + distance / 2; k++)
                        {
                            board.CorridorsPos.Add(new Position(currentDoor.X, k));
                        }
                        for (int k = currentDoor.Y + distance / 2; k <= otherDoor.Y + 1; k++)
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
                        //board.DoorsPos.Add(new Position(currentDoor.Y - 1, currentDoor.Y));
                        //board.DoorsPos.Add(new Position(otherDoor.Y + 1, otherDoor.Y));
                        board.FloorsPos.Remove(new Position(currentDoor.X, currentDoor.Y - 1));
                        board.FloorsPos.Remove(new Position(otherDoor.X, otherDoor.Y + 1));
                        //board.DoorsPos.Remove(currentDoor);
                        //board.DoorsPos.Remove(otherDoor);
                        updatedDoorsPos.Add(currentDoor);
                        updatedDoorsPos.Add(otherDoor);
                        break;
                    }
                }
            }
            board.DoorsPos.Clear();
            board.DoorsPos.AddRange(updatedDoorsPos);
        }
        private void SetPositionables(Board board)
        {
            board.FreeFloorsPos = new List<Position>(board.FloorsPos);

            foreach (var boardPositionable in this.BoardPositionables)
            {
                for (int i = 0; i < boardPositionable.MaxItemCount; i++)
                {
                    int check = BoardFactory.rand.Next(0, 100);

                    if (check < boardPositionable.ItemChance)
                    {
                        int randomFloor = BoardFactory.rand.Next(0, board.FreeFloorsPos.Count);
                        switch (boardPositionable.Name)
                        {
                            case "Gold": AddPositionableToBoard(new Gold(board.FloorsPos[randomFloor]), board, randomFloor); break;
                            case "HealthPotion": AddPositionableToBoard(new HealthPotion(board.FloorsPos[randomFloor]), board, randomFloor); break;
                            case "ManaPotion": AddPositionableToBoard(new ManaPotion(board.FloorsPos[randomFloor]), board, randomFloor); break;
                            case "RogueArmorStrong": AddPositionableToBoard(new RogueArmor(board.FloorsPos[randomFloor], 150, 5), board, randomFloor); break;
                            case "RogueArmorWeak": AddPositionableToBoard(new RogueArmor(board.FloorsPos[randomFloor], 70, 2), board, randomFloor); break;
                            case "WizardArmorStrong": AddPositionableToBoard(new WizardArmor(board.FloorsPos[randomFloor], 150, 5), board, randomFloor); break;
                            case "WizardArmorWeak": AddPositionableToBoard(new WizardArmor(board.FloorsPos[randomFloor], 70, 2), board, randomFloor); break;
                            case "RogueWeaponStrong": AddPositionableToBoard(new RogueWeapon(board.FloorsPos[randomFloor], 100, 5), board, randomFloor); break;
                            case "RogueWeaponWeak": AddPositionableToBoard(new RogueWeapon(board.FloorsPos[randomFloor], 50, 2), board, randomFloor); break;
                            case "WizardWeaponStrong": AddPositionableToBoard(new WizardWeapon(board.FloorsPos[randomFloor], 100, 5), board, randomFloor); break;
                            case "WizardWeaponWeak": AddPositionableToBoard(new WizardWeapon(board.FloorsPos[randomFloor], 50, 2), board, randomFloor); break;
                            case "Trinket": AddPositionableToBoard(new Trinket(board.FloorsPos[randomFloor]) , board, randomFloor); 
                                break;
                            case "ShopKeeper": AddPositionableToBoard(new ShopKeeper("Tayn Eeon", board.FloorsPos[randomFloor - 1], 150, new List<Item> { new Trinket(board.FloorsPos[randomFloor]) } ), board, randomFloor);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        private void AddPositionableToBoard(IPositionable item, Board board, int randomFloor)
        {
            //board.GoldPositionsPos.Add(board.FloorsPos[randomFloor]);
            board.PositionableObjects.Add(item);//////////////////////////////////////////////////////////
            board.FreeFloorsPos.RemoveAt(randomFloor);
        }
    }
}

// TODO: OOP board with no magic numbers