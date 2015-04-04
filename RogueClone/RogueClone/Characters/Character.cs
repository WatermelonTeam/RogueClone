namespace RogueClone
{
    using System;

    using Common;

    public abstract class Character : IDamageable, IKillable
    {
        private Health health;
        private string name;

        protected Character(string name, int maxHealth)
        {
            this.Name = name;
            this.Health = new Health(maxHealth);
        }

        public event EventHandler Death;
        protected void OnDeath(EventArgs args)
        {
            if (this.Death != null)
            {
                this.Death(this, args);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = Validator.ValidateName(value);
            }
        }
        public Health Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value;
            }
        }

        public void Die()
        {
            this.Health.Current = 0;
            this.OnDeath(EventArgs.Empty);
        }
        public abstract void TakeDamage(int amount);
    }
}