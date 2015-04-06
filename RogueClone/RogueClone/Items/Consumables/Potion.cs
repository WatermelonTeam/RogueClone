using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone
{
    public abstract class Potion : Consumable, IConsumable, IPositionable
    {
        protected Potion(string name, string description, int price, int neededLevel, Position position, Image icon, Color color, int amountRestored)
            : base(name, description, price, neededLevel, position, icon, color, amountRestored)
        { 
        }
        public Potion(string name, Position position)
            : base(name, position)
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
