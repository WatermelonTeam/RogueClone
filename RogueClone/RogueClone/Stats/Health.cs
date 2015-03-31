using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Health : RogueClone.PCs.Interfaces.IStat
    {
        private int current;
        public Health(int max)
        {
            this.Max = max;
            this.Current = max;
        }

        public int Max { get; set; }
        public int Current 
        {
            get 
            {
                return this.current;
            }
            set 
            {
                if (0 >= value || this.Max < value)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Current health {0} cannot be negative or exceed max health {1}", value, this.Max));
                }
                this.current = value;
            } 
        }

        public void Increase(int amount)
        {
            if (this.Current + amount > this.Max)
            {
                this.Current = this.Max;
            }
            else
            {
                this.Current += amount;
            }
        }


        public void IncreaseMax()
        {
            throw new NotImplementedException();
        }
    }
}
