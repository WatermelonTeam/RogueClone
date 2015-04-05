namespace RogueClone
{
    using Common;
    using RogueClone.Movements;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Hero : Character, IDamageable, IPositionable, IMovable, IKillable
    {
        
        private Mana heroMana;
        private Level heroLevel;
        private int heroWeapon;
        private int heroArmor;
        private int gold;

        protected Hero(string name, Position position, int maxHealth, Mana mana, Level level, int weapon, int armor, int gold, Image icon, Color color)
            : base(name, position, maxHealth, icon, color)
        {
            this.Mana = mana;
            this.Level = level;
            this.Weapon = weapon;
            this.Armor = armor;
            this.Gold = gold;
        }

        // event before properties !

        public int Gold
        {
            get
            {
                return this.gold;
            }
            set
            {
                Validator.IsPositive(value);

                this.gold = value;
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

        public override void TakeDamage(int damage)
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
		public void TakeRogueWeapon(object item)
		{
			(item as RogueWeapon).Take(this);
			item = null;
		}
		public void TakeWizardWeapon(object item)
		{
			(item as WizardWeapon).Take(this);
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

        public void MoveTo(Board board, Position newPosition)
        {
            if (HeroMovement.IsValidMovement(board, newPosition))
            {
                this.Position = newPosition;
            }
        }
        
    }
}
