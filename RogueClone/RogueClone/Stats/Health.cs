using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Health : RogueClone.PCs.Interfaces.IStat
    {
        public Health(int max)
        {
            this.Max = max;
            this.Current = max;
        }

        public int Max { get; set; }
        public int Current { get; set; }

        public void Increase(int amount)
        {
            this.Current += amount;
        }


        public void IncreaseMax()
        {
            throw new NotImplementedException();
        }
    }
}
