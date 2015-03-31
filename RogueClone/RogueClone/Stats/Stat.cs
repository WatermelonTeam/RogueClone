using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class Stat : RogueClone.PCs.Interfaces.IStat
    {
        private int current;
        public Stat(int max)
        {
            this.Max = max;
            this.Current = max;
        }

        public int Max { get; private set; }
        public int Current 
        {
            get 
            {
                return this.current;
            }
            set 
            {
                if (0 > value || this.Max < value)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Current {0} {1} cannot be negative or exceed max {0} {2}", this.GetType().Name.ToLower(), value, this.Max));
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


        public void IncreaseMax(int increaseValue)
        {
            this.Max += increaseValue;
        }
    }
}
