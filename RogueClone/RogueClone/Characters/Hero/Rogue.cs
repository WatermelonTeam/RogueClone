﻿
namespace RogueClone
{
    using RogueClone.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public sealed class Rogue : Hero, IPositionable, IKillable, IDamageable
    {
        public static readonly Rogue Instance = new Rogue("Bydern Ilgenar", new Position(20, 30), 100, new Mana(100), new Level(2), 100, 100, 200, Image.Rogue, Color.White);
        private Rogue(string name, Position position, int maxHealth, Mana mana, Level level, int weapon, int armor, int gold, Image icon, Color color)
            : base(name, position, maxHealth, mana, level, weapon, armor, gold, icon, color)
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
