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

        protected NPC(string name, int maxHealth, Image icon, Color color)
            : base(name, maxHealth, icon, color)
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
                Validator.IsPositive(value, "XPGain");

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
                Validator.IsPositive(value, "NPC - Damage");

                this.damage = value;
            }
        }

        public override void TakeDamage(int damage)
        {
            int loweredHealth = base.Health.Current - damage;

            if (loweredHealth <= 0)
            {
                base.Die();
            }
            else
            {
                base.Health.Current = loweredHealth;
            }
        }
    }
}