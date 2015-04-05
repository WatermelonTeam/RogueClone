using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Weapon : Item, IPositionable
	{

		private int damage;

        public Weapon(string name, Position position, int neededLevel, Image icon, Color color)
            : base(name, position, neededLevel, icon, color)
		{
			//random damage for every level of the weapon,just like the armorValue
			switch (neededLevel)
			{
				case 1: Damage = rnd.Next(15, 20);
					break;
				case 2:
					Damage = rnd.Next(22, 27);
					break;
				case 3:
					Damage = rnd.Next(28, 35);
					break;
				case 4:
					Damage = rnd.Next(35, 42);
					break;
				case 5:
					Damage = rnd.Next(46, 76);
					break;
			}
		}

		public int Damage
		{
			get
			{
				return this.damage;
			}
			protected set
			{
				this.damage = value;
			}
		}
        public virtual void Take(Hero hero)
        {
            hero.Weapon += this.Damage;
        }
	}
}
