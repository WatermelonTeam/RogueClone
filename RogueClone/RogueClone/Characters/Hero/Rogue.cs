using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public sealed class Rogue : Hero
    {
        public static readonly Rogue Instance = new Rogue("BydernIlgenar", 100, new Mana(100), new Level(2), 100, 100, 200, new Position(20, 30), Image.Rogue, Color.White);
        private Rogue(string name, int maxHealth, Mana mana, Level level, int weapon, int armor, int gold, Position cords, Image icon, Color color)
            : base(name, maxHealth, mana, level, weapon, armor, gold, cords, icon, color)
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
