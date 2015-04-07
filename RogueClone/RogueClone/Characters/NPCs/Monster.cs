namespace RogueClone
{
    using Common;
    using System;
    using RogueClone.Movements;
    public class Monster : NPC, IDamageable, IKillable, IPositionable, IMovable
    {
        private int level;
        //used to know when to damage the hero
        private bool isNextToHero;
        //used to know when to start chasing the hero
        private bool heroInSight;
        public Monster(string name, Position position, int level, int maxHP, int damage, int xpGain)
            : base(name, position, maxHP, Image.Monster, Color.DarkRed)
        {
            base.Damage = damage;
            base.XPGain = xpGain;
            this.isNextToHero = false;
            this.heroInSight = false;
            this.Level = level;
            this.Position = position;
        }
        public bool HeroInSight
        {
            get
            {
                return this.heroInSight;
            }
            set
            {
                this.heroInSight = value;
            }
        }
        public bool IsNextToHero
        {
            get
            {
                return this.isNextToHero;
            }
            set
            {
                this.isNextToHero = value;
            }
        }
        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                Validator.IsPositive(value, "Level");

                this.level = value;
            }
        }
        public Position NextMovingPosition(Board board, Position heroPosition)
        {
            //should implement find next point in a closest path algorithm
            return heroPosition;
        }
        public void MoveTo(Board board, Position newPosition)
        {
            if (MonsterMovement.IsValidMovement(board, newPosition))
            {
               
                this.Position = newPosition;
            }
        }
    }
}

