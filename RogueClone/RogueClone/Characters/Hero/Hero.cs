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
            int resultHP = base.Health.Current - (damage - this.Armor);
            if (resultHP <= 0)
            {
                base.Die();
            }
            else
            {
                this.Health.Current = resultHP;
            }
        }
        private void IteractWithItem(Item item)
        {
            if (item is Consumable)
            {
                (item as Consumable).Consumed(this);
            }
            else if (item is Gold)
            {
                (item as Gold).Take(this);
            }
            else if (item is Trinket && this.Level.CurrentLevel >= (item as Trinket).NeededLvl)
            {
                (item as Trinket).Take(this);
            }
            else if (item is Weapon && this.Level.CurrentLevel >= (item as Weapon).NeededLvl)
            {
                if (item is RogueWeapon && this is Rogue)
                {
                    (item as RogueWeapon).Take(this);
                }
                if (item is WizardWeapon && this is Wizard)
                {
                    (item as WizardWeapon).Take(this);
                }
            }
            else if (item is Armor && this.Level.CurrentLevel >= (item as Armor).NeededLvl)
            {
                if (item is RogueArmor && this is Rogue)
                {
                    (item as RogueArmor).Take(this);
                }
                if (item is WizardArmor && this is Wizard)
                {
                    (item as WizardArmor).Take(this);
                }
            }
        }
        public void TakeItem(Item item, Board board)
        {
            this.IteractWithItem(item);
            RemoveItemFromBoard(item, board);
        }
        public void Buy(Item item)
        {
            if (item.Value <= this.Gold)
            {
                this.Gold -= item.Value;
            }
            else
            {
                throw new ArgumentException("Hero doesn't have enough money to buy the item.");
            }

            this.IteractWithItem(item);
        }
        private void RemoveItemFromBoard(IPositionable item, Board board)
        {
            board.FloorsPos.Add(item.Position);
            board.PositionableObjects.Remove((Item)item);
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
