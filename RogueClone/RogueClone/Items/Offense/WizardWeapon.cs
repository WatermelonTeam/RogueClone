using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class WizardWeapon : Weapon
    {

        public WizardWeapon(Position position, int neededLevel)
            : base("Wizard Weapon", position, neededLevel, Image.WizardWeapon, Color.DarkYellow)
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
