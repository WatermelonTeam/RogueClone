using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class RogueArmor : Armor, IDurable
    {
        public int DodgeChance
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
