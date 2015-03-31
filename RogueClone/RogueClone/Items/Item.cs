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
        private readonly string itemIcon;
        private Point2D position;

        public Item()
        {
            // remember to remove this constructor !
        }

        public Item(string name, int price, int neededLevel, Point2D position, string icon)
        {
            this.itemName = name; // assign it only once because it is readonly
            this.itemPrice = price;
            this.itemNeededLevel = neededLevel;
            this.itemIcon = icon;
            this.position = position;
        }
        public Point2D Position
        {
            get { return this.position; }
        }

        public string Name
        {
            get
            {
                return this.itemName;
            }
        }

        public int Price
        {
            get
            {
                return this.itemPrice;
            }
        }

        public int NeededLvl
        {
            get
            {
                return this.itemNeededLevel;
            }
        }

        public string Icon
        {
            get
            {
                return this.itemIcon;
            }
        }

        void Pick()
        {
 
        }

        
    }
}
