using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class HealthPotion : Potion
    {
        private const int AmountRestored = 100;
        public HealthPotion(string name, int price, int neededLevel, Point2D position, char icon, int amountRestored)
            : base("Health Potion", string.Format("Health +{0}", amountRestored), price, neededLevel, position, '╬', ConsoleColor.Red, amountRestored)
        {
        }
        public HealthPotion(Point2D position)
            : base("Health Potion", string.Format("Health +{0}", AmountRestored), 150, 2, position, '╬', ConsoleColor.Red, AmountRestored)
        {
        }

        //public override string Name { get { return "Health Potion"; } }
        //public override string Description
        //{
        //    get
        //    {
        //        return string.Format("Health +{0}", this.AmountStatsRestored);
        //    }
        //}

        //public override int Value { get { return 150; } }

        //public override int NeededLvl { get { return 2; } }

        //public override char Icon { get { return '╬'; } }
        //public override ConsoleColor Color { get { return ConsoleColor.Red; } }
        //public override int AmountStatsRestored { get { return 100; } }

        public override void Consumed(Hero hero)
        {
            hero.Health.Increase(this.AmountStatsRestored);
        }
    }
}
