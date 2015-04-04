namespace RogueClone
{
    using System;

    using Common;

    public abstract class Character : IDamageable, IKillable
    {
        private Health health;
        private string name;
        private readonly Image characterIcon;
        public Color characterColor;

        protected Character(string name, int maxHealth, Image icon, Color color)
        {
            this.Name = name;
            this.Health = new Health(maxHealth);
            this.characterIcon = icon;
            this.characterColor = color;
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
        virtual public Image CharacterIcon
        {
            get { return this.characterIcon; }
        }
        virtual public Color CharacterColor
        {
            get { return this.characterColor; }
        }

        public void Die()
        {
            this.Health.Current = 0;
            this.OnDeath(EventArgs.Empty);
        }
        public abstract void TakeDamage(int amount);
    }
}