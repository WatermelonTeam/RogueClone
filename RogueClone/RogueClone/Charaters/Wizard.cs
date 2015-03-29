using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Wizard : Hero
    {
        public Wizard(string name, int health, int mana, int level, int weapon, int armor, int gold, Point2D cords, char icon)
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
