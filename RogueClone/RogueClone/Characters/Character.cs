namespace RogueClone
{
    using Common;
    using System;

    public abstract class Character : IDamageable, IKillable, IPositionable
    {
        private Health health;
        private string name;
        private readonly Image characterIcon;
        public Color characterColor;
        public event EventHandler Death;
        private RogueClone.Position position;

        protected Character(string name, Position position, int maxHealth, Image icon, Color color)
        {
            this.Name = name;
            this.Health = new Health(maxHealth);
            this.characterIcon = icon;
            this.characterColor = color;
            this.Position = position;

            this.IsAlive = true;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }
            set // validate
            {
                if (!IsValidPosition(value))
                {
                    throw new ArgumentOutOfRangeException(string.Format("The initial position was ({0},{1}). Valid range is ([{2},{3}),[{2},{4}))", value.X, value.Y, 0, RogueEngine.ConsoleWidth, (RogueEngine.ConsoleHeight - ConsoleRenderer.StatsPanelHeight)));
                }
                this.position = value;
            }
        }
        
        protected void OnDeath(EventArgs args)
        {
            if (this.Death != null)
            {
                this.Death(this, args);
            }
        }

        public bool IsAlive { get; protected set; }
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
            this.IsAlive = false;
            this.OnDeath(EventArgs.Empty);
        }
        public abstract void TakeDamage(int amount);
        public override string ToString()
        {
            return base.ToString().Split('.')[1];
        }
        private bool IsValidPosition(Position position) // later add validation for walls, monsters etc.
        {
            return 0 <= position.X
                && 0 <= position.Y
                && position.X < RogueEngine.ConsoleWidth
                && position.Y < RogueEngine.ConsoleHeight - ConsoleRenderer.StatsPanelHeight;
        }
        
    }
}