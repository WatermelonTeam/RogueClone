using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Rogue : Hero
    {
        public Rogue(string name, int health, int mana, int level, int weapon, int armor, int gold, int positionX, int positionY)
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
