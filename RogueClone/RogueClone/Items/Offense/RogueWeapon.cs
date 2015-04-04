using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class RogueWeapon : Weapon, IDurable
    {
		
		public RogueWeapon(int neededLevel, Position position)
			:base(neededLevel,position)
		{

		}
		public override ConsoleColor Color
		{
			get
			{
				return ConsoleColor.DarkYellow;
			}
		}
		public override string Description
		{
			get
			{
				return string.Format("Damage +{0}",this.Damage);
			}
		}
		public override char Icon
		{
			get
			{
				return '?';
			}
		}
		public override string Name
		{
			get
			{
				return "RogueWeapon";
			}
		}
		public void Take(Hero hero)
		{
			if (this.Icon == '?')
			{
				hero.Weapon += this.Damage;
			}
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
