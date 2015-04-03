namespace RogueClone
{
    using System;

    using Common;

    public abstract class NPC : Character, IDamageable, IKillable
    {
        private const int DefaultXPGain = 0;
        private const int DefaultDamage = 0;

        private int xpGain;
        private int damage;

        protected NPC(string name, int maxHealth)
            : base(name, maxHealth)
        {
            this.XPGain = NPC.DefaultXPGain;
            this.Damage = NPC.DefaultDamage;
        }

        public int XPGain
        {
            get
            {
                return xpGain;
            }
            set
            {
                Validator.IsPositive(value);

                this.xpGain = value;
            }
        }
        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                Validator.IsPositive(value);

                this.damage = value;
            }
        }
    }
}