namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Hero : IDamagable, IMovable, IKillable
    {
        private readonly string heroName;
        private readonly char heroIcon;

        private Health heroHealth;
        private Mana heroMana;
        private Level heroLevel;
        private int heroWeapon;
        private int heroArmor;
        private int heroGold;

        private int heroPositionX;
        private int heroPositionY;

        public Hero(string name, Health health, Mana mana, Level level, int weapon, int armor, int gold, Point2D cords, char icon)
        {
            this.heroName = name; // readonly does not need Property

            this.Health = health;
            this.Mana = mana;
            this.Level = level;
            this.Weapon = weapon;
            this.Armor = armor;
            this.Gold = gold;
            this.PositionX = cords.X;
            this.PositionY = cords.Y;
            this.heroIcon = icon;
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

        public int PositionX
        {
            get
            {
                return this.heroPositionX;
            }

            set
            {
                ////implement validation !!!
                this.heroPositionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return this.heroPositionY;
            }

            set
            {
                ////implement validation !!!
                this.heroPositionY = value;
            }
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }
        
        public void UseConsumable(object consumable)
        {
            if (consumable is Potion)
            {
                this.Health.Increase((consumable as Potion).UsePotion());
                consumable = null;
            }
            else
            {
                throw new Exception("Invalid consumable object in UseConsumable method !");
            }
            
        }

        // We should remove MoveTo and make it a static class in the Game class !
        public void MoveTo(int x, int y)
        {
            // Console.SetCursorPosition(x, y);
        }

        public abstract void CastSkillOne();

        public abstract void CastSkillTwo();
    }
}
