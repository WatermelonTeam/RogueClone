using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Wizard : Hero
    {
        public Wizard(string name, int health, int mana, int level, int weapon, int armor, int gold, int positionX, int positionY)
            : base(name, health, mana, level, weapon, armor, gold, positionX, positionY)
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
