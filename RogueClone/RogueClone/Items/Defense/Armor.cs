using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class Armor : Item
    {

		private int armorValue;

		public Armor(int neededLevel, Point2D position)
			: base(neededLevel, position)
		{
			//random armorValue for every level
			switch (neededLevel)
			{
				case 1:
					armorValue = rnd.Next(10, 16);
					break;
				case 2:
					armorValue = rnd.Next(14, 22);
					break;
				case 3:
					armorValue = rnd.Next(20, 28);
					break;
				case 4:
					armorValue = rnd.Next(25, 31);
					break;
				case 5:
					armorValue = rnd.Next(28, 37);
					break;
			}
		}

        virtual public int ArmorValue
        {
            get
            {
                return this.armorValue;
            }
			set
			{
				this.armorValue = value;
			}
        }
    }
}
