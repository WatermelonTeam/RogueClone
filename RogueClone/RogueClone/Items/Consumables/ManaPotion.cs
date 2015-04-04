using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class ManaPotion : Potion
    {
        //public ManaPotion(string name, int price, int neededLevel, Point2D position, char icon, int amountRestored)
        //    : base(name, price, neededLevel, position, icon, amountRestored)
        //{
        //}

        public ManaPotion(Position position)
            : base(position)
        {
        }

        public override string Name { get { return "Mana Potion"; } }
        public override string Description
        {
            get
            {
                return string.Format("Mana +{0}", this.AmountStatsRestored);
            }
        }

        public override int Value { get { return 100; } }

        public override int NeededLvl { get { return 3; } }

        public override char Icon { get { return '¤'; } } //≈ ☼ ⌂ 
        public override ConsoleColor Color { get { return ConsoleColor.Cyan; } }
        public override int AmountStatsRestored { get { return 50; } }

        public override void Consumed(Hero hero)
        {
            hero.Mana.Increase(this.AmountStatsRestored);
        }
    }
}
