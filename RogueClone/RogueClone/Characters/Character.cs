namespace RogueClone
{
    using System;

    using Common;

    public abstract class Character : IDamageable, IKillable
    {
        private Health healthValue;
        private string name;

        protected Character(string name, int maxHealth)
        {
            this.Name = name;
            this.Health = new Health(maxHealth);
        }

        public event EventHandler Dead;
        protected void OnDead(EventArgs args)
        {
            if (this.Dead != null)
            {
                this.Dead(this, args);
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
                return this.healthValue;
            }
            private set
            {
                this.healthValue = value;
            }
        }

        public abstract void TakeDamage();
    }
}