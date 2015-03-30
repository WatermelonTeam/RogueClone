using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone.Items.Consumables
{
    public abstract class Potion : Item
    {
        private int potionStatsRestored;

        public Potion(string name, int price, int neededLevel, int posX, int posY, string icon, int amountRestored)
            : base(name, price, neededLevel, posX, posY, icon)
        {
            this.potionStatsRestored = amountRestored;
        }

        public int AmountStatsRestored
        {
            get
            {
                return this.potionStatsRestored;
            }
        }

        public void RestoreHealth(Hero hero)
        {
            hero.Health.Increase(this.potionStatsRestored);
        }


    }
}
