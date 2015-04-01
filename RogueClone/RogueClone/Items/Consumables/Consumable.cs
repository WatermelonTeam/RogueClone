using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class Consumable : Item, IConsumable
    {
        private int amountStatsRestored;
        public Consumable(string name, string description, int price, int neededLevel, Point2D position, char icon, ConsoleColor color, int amountRestored)
            : base(name, description, price, neededLevel, position, icon, color)
        {
            this.amountStatsRestored = amountRestored;
        }

        public Consumable(Point2D position)
            : base(position)
        {
        }

        virtual public int AmountStatsRestored { get { return this.amountStatsRestored; } }
        public abstract void Consumed(Hero hero);

    }
}
