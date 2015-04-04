using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class RogueWeapon : Weapon, IDurable
    {
		
		public RogueWeapon(Position position, int neededLevel)
            : base("Rogue Weapon", position, neededLevel, Image.RogueWeapon, Color.DarkYellow)
		{

		}
		public override string Description
		{
			get
			{
				return string.Format("Damage +{0}",this.Damage);
			}
		}
        public override void Take(Hero hero)
        {
            if (hero is Rogue)
                base.Take(hero);
        }
		
        public int CritChance
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
