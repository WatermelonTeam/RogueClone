using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class RogueWeapon : Weapon, IDurable
    {
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
