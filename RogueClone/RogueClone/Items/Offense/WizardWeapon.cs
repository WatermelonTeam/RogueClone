using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class WizardWeapon : Weapon, IPositionable
    {

        public WizardWeapon(Position position, int value, int neededLevel)
            : base("Wizard Weapon", position, value, neededLevel, Image.WizardWeapon, Color.DarkRed)
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
            if (hero is Wizard)
                base.Take(hero);
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
