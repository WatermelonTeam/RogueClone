using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
	public class WizardArmor : Armor
	{
		public WizardArmor(Position position, int neededLevel)
            : base("Wizard Armor", position, neededLevel, Image.WizardArmor, Color.DarkYellow)
		{

		}
		public override string Description
		{
			get
			{
				return string.Format("Armor +{0}", this.ArmorValue);
			}

		}
        public override void Take(Hero hero)
        {
            if (hero is Wizard)
                base.Take(hero);
        }
		public int ArmorSpell
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
