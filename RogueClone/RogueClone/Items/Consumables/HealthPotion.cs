using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class HealthPotion : Potion
    {
        //public HealthPotion(string name, int price, int neededLevel, Point2D position, char icon, int amountRestored)
        //    : base("Health Potion", price, neededLevel, position, '♥', amountRestored)
        //{
        //}
        public HealthPotion(Point2D position)
            : base(position)
        {
        }

        public override string Name { get { return "Health Potion"; } }

        public override int Price { get { return 150; } }

        public override int NeededLvl { get { return 2; } }

        public override char Icon { get { return '♥'; } }
        public override ConsoleColor Color { get { return ConsoleColor.Red; } }
        public override int AmountStatsRestored { get { return 100; } }

        public override void Consumed(Hero hero)
        {
            hero.Health.Increase(this.AmountStatsRestored);
        }
    }
}
