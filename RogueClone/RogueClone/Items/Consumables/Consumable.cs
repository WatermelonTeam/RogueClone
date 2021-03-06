﻿using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class Consumable : Item, IConsumable, IPositionable
    {
        private int amountStatsRestored;
        protected Consumable(string name, string description, int price, int neededLevel, Position position, Image icon, Color color, int amountRestored)
            : base(name, description, price, neededLevel, position, icon, color)
        {
            this.amountStatsRestored = amountRestored;
        }

        public Consumable(string name, Position position)
            : base(name, position)
        {
        }

        virtual public int AmountStatsRestored { get { return this.amountStatsRestored; } }
        public abstract void Consumed(Hero hero);

    }
}
