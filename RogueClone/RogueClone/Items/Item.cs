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
        private readonly char itemIcon;
        private readonly ConsoleColor itemColor;
        private readonly string itemDescription;
        private Position position;

        public Item()
        {
            // remember to remove this constructor !
        }
        public Item(Position position)
        {
            this.position = position;
        }
		//added new constructor so i can randomize the armorvalue and the damage :)
		public Item(int neededLevel, Position position)
			:this(position)
		{
			this.itemNeededLevel = neededLevel;
		}
        public Item(Position position, int value)
            : this(position)
        {
            this.itemValue = value;
        }
        public Item(string name, Position position, int value)
            : this(position, value)
        {

            this.itemName = name; // assign it only once because it is readonly
        }

        public Item(string name, string description, int value, int neededLevel, Position position, char icon, ConsoleColor color)
            : this(name, position, value)
        {
            this.itemDescription = description;
            this.itemNeededLevel = neededLevel;
            this.itemIcon = icon;
            this.itemColor = color;
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

        virtual public char Icon 
        {
            get { return this.itemIcon; } 
        }
        virtual public ConsoleColor Color
        {
            get { return this.itemColor; }
        }

        Position IPositionable.Position
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
