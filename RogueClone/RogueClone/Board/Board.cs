namespace RogueClone
{
    using System;
    using System.Collections.Generic;

    public class Board
    {
        public Board()  
        {
            this.EntryStairPos = new Position();
            this.ExitStairPos = new Position();
            this.ShopKeeperPos = new Position();

            this.FloorsPos = new List<Position>();
            this.DoorsPos = new List<Position>();
            this.CornersPos = new List<Position>();
            this.HorizontalWallsPos = new List<Position>();
            this.VerticalWallsPos = new List<Position>();
            this.CorridorsPos = new List<Position>();
            this.GoldPositionsPos = new List<Position>();
            this.ItemsPos = new List<Position>();
            this.Items = new List<Item>();
        }

        public List<Item> Items { get; private set; } // return copy instead?
        public Position EntryStairPos { get; set; }
        public Position ExitStairPos { get; set; }
        public Position ShopKeeperPos { get; set; }
        public List<Position> FloorsPos { get; private set; }
        public List<Position> DoorsPos { get; private set; }
        public List<Position> CornersPos { get; private set; }
        public List<Position> HorizontalWallsPos { get; private set; }
        public List<Position> VerticalWallsPos { get; private set; }
        public List<Position> CorridorsPos { get; private set; }
        public List<Position> GoldPositionsPos { get; private set; }
        public List<Position> ItemsPos { get; private set; }
    }
}