using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class WizardWeapon : Weapon
    {
		
		public WizardWeapon(int neededLevel,Position position)
			:base(neededLevel,position)
		{

		}
		public override string Description
		{
			get
			{
				return string.Format("Damage +{0}",this.Damage);
			}
		}
		public override string Name
		{
			get
			{
				return "WizardWeapon";
			}
		}
		public override char Icon
		{
			get
			{
				return '?';
			}
		}
		public override ConsoleColor Color
		{
			get
			{
				return ConsoleColor.DarkYellow;
			}
		}
		public void Take(Hero hero)
		{
			if(this.Icon=='?')
			{
				hero.Weapon += this.Damage;
			}
		}
        public int WeaponSpell
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
