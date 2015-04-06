using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class Item : IPositionable
    {
		//static random variable so we can generate random damage for weapons and armorValue for armors
		protected static readonly Random rnd = new Random();

        private readonly string itemName;
        private readonly int itemValue;
        private readonly int itemNeededLevel;
        private readonly Image itemIcon;
        public Color itemColor;
        private readonly string itemDescription;
        private Position position;

        public Item()
        {
            // remember to remove this constructor !
        }
        protected Item(string name, Position position)
        {
            this.itemName = name;
            this.position = position;
        }
		//added new constructor so i can randomize the armorvalue and the damage :)
        protected Item(string name, int neededLevel, Position position)
			:this(name, position)
		{
			this.itemNeededLevel = neededLevel;
		}
        protected Item(string name, Position position, int value)
            : this(name, position)
        {
            this.itemValue = value;
        }
        protected Item(string name, Position position, int value, Image icon, Color color)
            : this(name, position, value)
        {
            this.itemIcon = icon;
            this.itemColor = color;
        }
        protected Item(string name, Position position, int value, int neededLevel, Image icon, Color color)
            : this(name, position, value, icon, color)
        {
            this.itemNeededLevel = neededLevel;
        }

        protected Item(string name, string description, int value, int neededLevel, Position position, Image icon, Color color)
            : this(name, position, value, neededLevel, icon, color)
        {
            this.itemDescription = description;
            this.itemNeededLevel = neededLevel;
        }
        public Position Position
        {
            get { return this.position; }
        }

        virtual public string Name
        { 
            get { return this.itemName; }
        }
        virtual public string Description
        {
            get { return this.itemDescription; }
        }

        virtual public int Value
        {
            get { return this.itemValue; }
        }

        virtual public int NeededLvl
        {
            get 
            {
                if (this.itemNeededLevel == 0) 
                { 
                    return 1; 
                } 
                return this.itemNeededLevel; 
            }
        }

        virtual public Image Icon 
        {
            get { return this.itemIcon; } 
        }
        virtual public Color ItemColor
        {
            get { return this.itemColor; }
        }
    }
}
