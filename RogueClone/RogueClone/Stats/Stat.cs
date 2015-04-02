namespace RogueClone.Stats
{
    using System;

    using Common;

    public class Stat : IStat
    {
        private int current;
        private int max;
        private int regenAmount;

        public Stat(int max)
        {
            this.Max = max;
            this.Current = this.Max;
            this.RegenAmount = 0;
        }

        public int Max
        {
            get
            {
                return this.current;
            }
            set
            {
                Validator.IsPositive(value, "Stat - Max");

                this.max = value;
            }
        }
        public int Current 
        {
            get 
            {
                return this.current;
            }
            set 
            {
                Validator.IsWithinRange(value, 0, this.Max, "Stat - Current");

                this.current = value;
            } 
        }
        public int RegenAmount
        {
            get
            {
                return this.regenAmount;
            }
            set
            {
                Validator.IsPositive(value, "RegenAmount");

                this.regenAmount = value;
            }
        }

        public void Regen()
        {
            int totalAmount = this.Current + this.RegenAmount;

            if (totalAmount > this.Max)
            {
                this.Current = this.Max;
            }
            else
            {
                this.Current = totalAmount;
            }
        }
    }
}