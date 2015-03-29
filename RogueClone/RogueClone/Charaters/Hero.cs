namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Hero : IDamagable, IMovable, IKillable
    {
        private readonly string heroName;
        private int heroHealth;
        private int heroMana;
        private int heroLevel;
        private int heroWeapon;
        private int heroArmor;
        private int heroGold;

        private int heroPositionX;
        private int heroPositionY;

        public Hero(string name, int health, int mana, int level, int weapon, int armor, int gold, int positionX, int positionY)
        {

            this.heroName = name; // readonly does not need Property

            this.Health = health;
            this.Mana = mana;
            this.Level = level;
            this.Weapon = weapon;
            this.Armor = armor;
            this.Gold = gold;
            this.PositionX = positionX;
            this.PositionY = positionY;

        }

        // event before properties !
        public event EventHandler Dead;

        public int Health
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

        public int Mana
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

        public int Level
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


        // We should remove MoveTo and make it a static class in the Game class !
        public void MoveTo(int x, int y)
        {
            //Console.SetCursorPosition(x, y);
        }

        public abstract void CastSkillOne();

        public abstract void CastSkillTwo();
    }
}
