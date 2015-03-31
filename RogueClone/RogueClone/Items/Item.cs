using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class Item : IPositionable
    {
        private readonly string itemName;
        private readonly int itemPrice;
        private readonly int itemNeededLevel;
        private readonly char itemIcon;
        private readonly ConsoleColor itemColor;
        private Point2D position;

        public Item()
        {
            // remember to remove this constructor !
        }
        public Item(Point2D position)
        {
            this.position = position;
        }

        public Item(string name, int price, int neededLevel, Point2D position, char icon, ConsoleColor color)
            : this(position)
        {
            this.itemName = name; // assign it only once because it is readonly
            this.itemPrice = price;
            this.itemNeededLevel = neededLevel;
            this.itemIcon = icon;
            this.itemColor = color;
        }
        public Point2D Position
        {
            get { return this.position; }
        }

        virtual public string Name
        { 
            get { return this.itemName; } 
        }

        virtual public int Price
        {
            get
            {
                return this.itemPrice;
            }
        }

        virtual public int NeededLvl
        {
            get
            {
                return this.itemNeededLevel;
            }
        }

        virtual public char Icon 
        { 
            get 
            { 
                return this.itemIcon; 
            } 
        }
        virtual public ConsoleColor Color
        {
            get
            {
                return this.itemColor;
            }
        }

        void Pick()
        {
 
        }

        
    }
}
