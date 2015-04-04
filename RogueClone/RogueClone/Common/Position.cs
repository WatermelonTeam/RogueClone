using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public struct Position 
    {
        private int x;
        private int y;

        public Position(int x = 0, int y = 0)
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

        public double Distance(Position p1, Position p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y)); 
        }

        public override bool Equals(object obj)
        {
            Position p = (Position)obj;
            return this.X == p.X && this.Y == p.Y;
        }
        public static bool operator ==(Position p1, Position p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }
}
