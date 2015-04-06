namespace RogueClone
{
    using RogueClone.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public sealed class Wizard : Hero, IPositionable, IKillable, IDamageable
    {
        public static readonly Wizard Instance = new Wizard("Gandalf", new Position(10, 10),  100, new Mana(100), new Level(5), 9999, 10, 0, Image.Wizard, Color.White);
        private Wizard(string name, Position position, int maxHealth, Mana mana, Level level, int weapon, int armor, int gold, Image icon, Color color)
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
