using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone
{
    public abstract class Potion : Consumable
    {
        public Potion(string name, int price, int neededLevel, Point2D position, char icon, ConsoleColor color, int amountRestored)
            : base(name, price, neededLevel, position, icon, color, amountRestored)
        { 
        }
        public Potion(Point2D position)
            : base(position)
        {
        }

        // add IConsumer to the hero so he can consume potions OO ?
        //public int UsePotion()
        //{
        //    var restored = this.AmountStatsRestored;
        //    this.AmountStatsRestored = 0;
        //    return restored;
        //}
    }
}
