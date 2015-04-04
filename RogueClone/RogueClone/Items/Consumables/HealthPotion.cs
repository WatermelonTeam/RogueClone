using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class HealthPotion : Potion
    {
        private const int AmountRestored = 100;
        public HealthPotion(int price, int neededLevel, Position position, char icon, int amountRestored)
            : base("Health Potion", string.Format("Health +{0}", amountRestored), price, neededLevel, position, Image.HealthPotion, Color.Red, amountRestored)
        {
        }
        public HealthPotion(Position position)
            : base("Health Potion", string.Format("Health +{0}", AmountRestored), 150, 2, position, Image.HealthPotion, Color.Red, AmountRestored)
        {
        }
        public override void Consumed(Hero hero)
        {
            hero.Health.Increase(this.AmountStatsRestored);
        }
    }
}
