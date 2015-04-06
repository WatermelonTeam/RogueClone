using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class RogueArmor : Armor, IDurable, IPositionable
    {
		public RogueArmor(Position position, int value, int neededLevel)
            : base("Rogue Armor", position, value, neededLevel, Image.RogueArmor, Color.DarkRed)
		{
		}
		//all items shall be one color so the player cant possibly know what item he is going to pick !

		public override string Description
		{
			get
			{
				return string.Format("Armor +{0}",this.ArmorValue);
			}
		}
        public override void Take(Hero hero)
        {
            if (hero is Rogue)
                base.Take(hero);
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
