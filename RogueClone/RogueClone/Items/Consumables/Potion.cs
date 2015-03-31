using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone
{
    public class Potion : Consumable, IPotion
    {
        public Potion(string name, int price, int neededLevel, Point2D position, string icon, int amountRestored)
            : base(name, price, neededLevel, position, icon, amountRestored)
        {

        }


        // add IConsumer to the hero so he can consume potions OO ?
        public int UsePotion()
        {
            var restored = this.AmountStatsRestored;
            this.AmountStatsRestored = 0;
            return restored;
        }
    }
}
