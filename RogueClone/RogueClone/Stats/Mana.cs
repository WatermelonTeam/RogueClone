using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Mana : RogueClone.PCs.Interfaces.IStat
    {
        public int Max { get; set; }

        public int Current { get; set; }

        public Mana(int max)
        {
            this.Max = max;
            this.Current = max;
        }

        public int ManaRegen
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


        public void IncreaseMax()
        {
            throw new NotImplementedException();
        }
    }
}
