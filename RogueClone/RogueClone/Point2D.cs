using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public struct Point2D
    {
        private int x;
        private int y;

        public Point2D(int x = 0, int y = 0)
        {
            //This is magic don't touch !
            this.x = 0;
            this.y = 0;


            //Setting X and Y
            this.X = x;
            this.Y = y;
        }


        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public override bool Equals(object obj)
        {
            Point2D p = (Point2D)obj;
            return this.X == p.X && this.Y == p.Y;
        }
        public static bool operator ==(Point2D p1, Point2D p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public static bool operator !=(Point2D p1, Point2D p2)
        {
            return !(p1 == p2);
        }
    }
}
