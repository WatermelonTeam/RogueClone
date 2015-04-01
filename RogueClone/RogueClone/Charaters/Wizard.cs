using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public sealed class Wizard : Hero
    {
        public static readonly Wizard Instance = new Wizard("Gandalf", Health.Instance, Mana.Instance, new Level(2), 9999, 10, 0, new Point2D(10, 10), '☻');
        private Wizard(string name, Health health, Mana mana, Level level, int weapon, int armor, int gold, Point2D cords, char icon)
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
