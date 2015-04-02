using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class RogueArmor : Armor, IDurable
    {
		public RogueArmor(int neededLevel,Point2D position)
			:base(neededLevel,position)
		{

		}
		//all items shall be one color so the player cant possibly know what item he is going to pick !
		public override ConsoleColor Color { get { return ConsoleColor.DarkYellow; } }

		public override string Description
		{
			get
			{
				return string.Format("Armor +{0}",this.ArmorValue);
			}
		}
		public override char Icon
		{
			
			//Items will only be "?" so that the player doesnt know what item is it
			get
			{
				return '?';
			}
		}
		public override string Name
		{
			get
			{
				return "RogueArmor";
			}
		}
		public void Take(Hero hero)
		{
			if(this.Icon =='?')
			{
				hero.Armor += this.ArmorValue;
			}
		}
        public int DodgeChance
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int MaxDurability
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

        public int CurrentDurability
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
