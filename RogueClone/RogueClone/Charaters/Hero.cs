namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Hero : IDamageable, IPositionable, IMovable, IKillable
    {
        private readonly string heroName;
        private readonly char heroIcon;

        private Health heroHealth;
        private Mana heroMana;
        private Level heroLevel;
        private int heroWeapon;
        private int heroArmor;
        private int heroGold;

        private Point2D position;

        public Hero(string name, Health health, Mana mana, Level level, int weapon, int armor, int gold, Point2D position, char icon)
        {
            this.heroName = name; // readonly does not need Property

            this.Health = health;
            this.Mana = mana;
            this.Level = level;
            this.Weapon = weapon;
            this.Armor = armor;
            this.Gold = gold;
            this.Position = position;
            this.heroIcon = icon;
        }
        public Point2D Position
        {
            get
            {
                return this.position;
            }
            set // validate
            {
                if (!IsValidPosition(value))
                {
                    throw new ArgumentOutOfRangeException(string.Format("The initial position was ({0},{1}). Valid range is ([{2},{3}),[{2},{4}))", value.X, value.Y, 0, Game.ConsoleWidth, (Game.ConsoleHeight - Engine.statsPanelHeight)));
                }
                this.position = value;
            }
        }

        // event before properties !
        public event EventHandler Dead;
        
        public Health Health
        {
            get
            {
                return this.heroHealth;
            }

            set
            {
                ////implement validation !!!
                this.heroHealth = value;
            }
        }

        public char Icon
        {
            get
            {
                return this.heroIcon;
            }
        }

        public Mana Mana
        {
            get
            {
                return this.heroMana;
            }

            set
            {
                ////implement validation !!!
                this.heroMana = value;
            }
        }

        public Level Level
        {
            get
            {
                return this.heroLevel;
            }

            set
            {
                ////implement validation !!!
                this.heroLevel = value;
            }
        }

        public string Name
        {
            get
            {
                return this.heroName;
            }

            // We don't need setter because it is readonly ! Possible change in the future for rewritable name :D
        }

        public int Weapon
        {
            get
            {
                return this.heroWeapon;
            }

            set
            {
                ////implement validation !!!
                this.heroWeapon = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.heroArmor;
            }

            set
            {
                ////implement validation !!!
                this.heroArmor = value;
            }
        }

        public int Gold
        {
            get
            {
                return this.heroGold;
            }

            set
            {
                ////implement validation !!!
                this.heroGold = value;
            }
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }
        
        public void UseConsumable(object consumable)
        {
            if (consumable is IConsumable)
            {
                (consumable as Consumable).Consumed(this);
                consumable = null;
            }
            else
            {
                throw new Exception("Invalid consumable object in UseConsumable method !");
            }
        }
        public void TakeGold(object item)
        {
                (item as Gold).Take(this);
                item = null;
        }
        public void TakeTrinket(object item)
        {
            (item as Trinket).Take(this);
            item = null;
        }
		public void TakeRogueArmor(object item)
		{
			(item as RogueArmor).Take(this);
			item = null;

		}
		public void TakeWizardArmor(object item)
		{
			(item as WizardArmor).Take(this);
			item = null;
		}
        public void Pay(int amount)
        {
            if (amount <= this.Gold)
            {
                this.Gold -= amount;
            }
        }

        //// We should remove MoveTo and make it a static class in the Game class !
        //public void MoveTo(int x, int y)
        //{
        //    // Console.SetCursorPosition(x, y);
        //}

        public abstract void CastSkillOne();

        public abstract void CastSkillTwo();

        public void MoveTo(Point2D newPosition, char steppedOnItem = ' ', ConsoleColor itemColour = ConsoleColor.White)
        {
            if (IsValidPosition(newPosition))
            {
                Engine.PrintOnPosition(this.Position.X, this.Position.Y, steppedOnItem.ToString(), itemColour);
                this.Position = newPosition;
                Console.SetCursorPosition(this.Position.X, this.Position.Y);
            }
        }
        private bool IsValidPosition(Point2D position) // later add validation for walls, monsters etc.
        {
            return 0 <= position.X 
                && 0 <= position.Y 
                && position.X < Game.ConsoleWidth 
                && position.Y < Game.ConsoleHeight - Engine.statsPanelHeight;
        }
    }
}
