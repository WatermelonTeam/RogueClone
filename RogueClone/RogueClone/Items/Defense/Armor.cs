using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class Armor : Item
    {
        private int armorValue;
        virtual public int ArmorValue
        {
            get
            {
                return this.armorValue;
            }
        }
    }
}
