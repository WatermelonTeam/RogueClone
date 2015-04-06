using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone
{
    public class BoardPositionable
    {
        private int itemChance;
        private int maxItemCount;

        public BoardPositionable(string name, int itemChance, int maxItemCount)
        {
            this.Name = name;
            this.ItemChance = itemChance;
            this.MaxItemCount = maxItemCount;
        }

        public string Name { get; set; }
        public int ItemChance
        {
            get
            {
                return this.itemChance;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Chance must be between 0 and 100.");
                }

                this.itemChance = value;
            }
        }

        public int MaxItemCount
        {
            get
            {
                return this.maxItemCount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MaxItemCount can't be less than zero.");
                }

                this.maxItemCount = value;
            }
        }
        public override string ToString()
        {
            return base.ToString().Split('.')[1];
        }
    }
}
