namespace RogueClone
{
    using System;
    using System.Collections.Generic;

    public class Board
    {
        public Board()  
        {
            this.EntryStair = new Point2D();
            this.ExitStair = new Point2D();
            this.ShopKeeper = new Point2D();

            this.Floors = new List<Point2D>();
            this.Doors = new List<Point2D>();
            this.Corners = new List<Point2D>();
            this.HorizontalWalls = new List<Point2D>();
            this.VerticalWalls = new List<Point2D>();
            //this.Paths = new List<Point2D>();
            this.GoldPostions = new List<Point2D>();
            this.Items = new List<Point2D>();
        }

        public Point2D EntryStair { get; set; }
        public Point2D ExitStair { get; set; }
        public Point2D ShopKeeper { get; set; }
        public List<Point2D> Floors { get; private set; }
        public List<Point2D> Doors { get; private set; }
        public List<Point2D> Corners { get; private set; }
        public List<Point2D> HorizontalWalls { get; private set; }
        public List<Point2D> VerticalWalls { get; private set; }
        //public List<Point2D> Paths { get; private set; }
        public List<Point2D> GoldPostions { get; private set; }
        public List<Point2D> Items { get; private set; }
    }
}