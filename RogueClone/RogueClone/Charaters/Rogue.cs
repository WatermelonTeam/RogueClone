using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public sealed class Rogue : Hero
    {
        public static readonly Rogue Instance = new Rogue("BydernIlgenar", Health.Instance, Mana.Instance, new Level(2), 100, 100, 200, new Point2D(10, 10), '☺');
        private  Rogue(string name, Health health, Mana mana, Level level, int weapon, int armor, int gold, Point2D cords, char icon)
            : base(name, health, mana, level, weapon, armor, gold, cords, icon)
        {
        }
        public override void CastSkillOne()
        {
            throw new NotImplementedException();
        }

        public override void CastSkillTwo()
        {
            throw new NotImplementedException();
        }
    }
}
