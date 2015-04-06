namespace RogueClone
{
    using Common;
    using System;

    public class Monster : NPC, IDamageable, IKillable, IPositionable, IMovable
    {
        private int level;

        public Monster(string name, Position position, int level, int maxHP, int damage, int xpGain)
            : base(name, position, maxHP, Image.Monster, Color.DarkRed)
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

        public void MoveTo(Board board, Position newPosition)
        {
            throw new NotImplementedException();
        }
    }
}
