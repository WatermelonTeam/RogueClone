using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
	public class WizardArmor : Armor
	{
		public WizardArmor(int neededLevel, Position position)
			: base(neededLevel, position)
		{

		}
		public override ConsoleColor Color { get { return ConsoleColor.DarkYellow; } }
		public override string Description
		{
			get
			{
				return string.Format("Armor +{0}", this.ArmorValue);
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
				return "WizardArmor";
			}
		}
		public void Take(Hero hero)
		{
			if (this.Icon == '?')
			{
				hero.Armor += this.ArmorValue;
			}
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
