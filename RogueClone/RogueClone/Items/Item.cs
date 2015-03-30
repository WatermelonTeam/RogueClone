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

        private int itemPositionX;
        private int itemPositionY;


        public Item()
        {
            // remember to remove this constructor !
        }

        public Item(string name, int price, int neededLevel, int posX, int posY,string icon)
        {
            this.itemName = name; // assign it only once because it is readonly
            this.itemPrice = price;
            this.itemNeededLevel = neededLevel;
            this.itemIcon = icon;

            this.PositionX = posX;
            this.PositionY = posY;
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

        public int PositionX
        {
            get
            {
                return this.itemPositionX;
            }
            set
            {
                this.itemPositionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return this.itemPositionY;
            }
            set
            {
                this.itemPositionY = value;
            }
        }
        public string Icon
        {
            get
            {
                return this.itemIcon;
            }
        }

        public void MoveTo(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
