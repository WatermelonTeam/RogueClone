using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Consumable : Item
    {
        private int potionStatsRestored;


        public Consumable(string name, int price, int neededLevel, Point2D position, string icon, int amountRestored)
            : base(name, price, neededLevel, position, icon)
        {
            this.potionStatsRestored = amountRestored;
        }

        public int AmountStatsRestored
        {
            get
            {
                return this.potionStatsRestored;
            }
            set
            {
                this.potionStatsRestored = value;
            }
        }

        public void RestoreHealth(Hero hero)
        {
            hero.Health.Increase(this.potionStatsRestored);
        }
    }
}
