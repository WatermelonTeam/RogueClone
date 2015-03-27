using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Health : RogueClone.PCs.Interfaces.IStat
    {
        private int max;
        private int current;

        public int Max
        {
            get
            {
                return this.max;
            }
            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Health can't be less than zero.");
                }

                this.max = value;
            }
        }

        public int Current
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Increase()
        {
            throw new System.NotImplementedException();
        }


        public void IncreaseMax()
        {
            throw new NotImplementedException();
        }
    }
}
