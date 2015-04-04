using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class ManaPotion : Potion
    {
        private const int AmountRestored = 50;
        public ManaPotion(int price, int neededLevel, Position position, char icon, int amountRestored)
            : base("Mana Potion", string.Format("Mana +{0}", AmountRestored), price, neededLevel, position, Image.ManaPotion, Color.Cyan, amountRestored)
        {
        }

        public ManaPotion(Position position)
            : base("Mana Potion", string.Format("Mana +{0}", AmountRestored), 150, 2, position, Image.ManaPotion, Color.Cyan, AmountRestored) //≈ ☼ ⌂ 
        {
        }
        public override void Consumed(Hero hero)
        {
            hero.Mana.Increase(this.AmountStatsRestored);
        }
    }
}
