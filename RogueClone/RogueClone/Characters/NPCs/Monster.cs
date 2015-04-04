namespace RogueClone
{
    using System;
    using Common;

    public class Monster : NPC, IDamageable, IKillable, IPositionable
    {
        private int level;

        public Monster(string name, int level, int maxHP, int damage, int xpGain, Position position)
            : base(name, maxHP, Image.Monster, Color.DarkRed)
        {
            base.Damage = damage;
            base.XPGain = xpGain;

            this.Level = level;
            this.Position = position;
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                Validator.IsPositive(value, "Level");

                this.level = value;
            }
        }
        public Position Position { get; set; }
    }
}
