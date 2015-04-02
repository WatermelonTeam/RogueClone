namespace RogueClone.Stats
{
    using System;

    using Common;

    public class Level : ILvL
    {
        private const int StartingLevel = 1;
        private const int StartLvLXP = 0;

        private int currentXP;
        private int needXP;
        private int currentLevel;

        public Level(int needXP)
        {
            this.NeedXP = needXP;
            this.CurrentXP = Level.StartLvLXP;
            this.CurrentLevel = Level.StartingLevel;
        }

        public event EventHandler LevelUp;
        private void OnLevelUp(EventArgs args)
        {
            if (this.LevelUp != null)
            {
                this.LevelUp(this, args);
            }
        }

        public int CurrentXP
        {
            get
            {
                return this.currentXP;
            }
            private set
            {
                Validator.IsWithinRange(value, 0, this.NeedXP, "CurrentXP");

                this.currentXP = value;
            }
        }
        public int NeedXP
        {
            get
            {
                return this.needXP;
            }
            set
            {
                Validator.IsPositive(value, "NeedXP");

                this.needXP = value;
            }
        }
        public int CurrentLevel 
        {
            get
            {
                return this.currentLevel;
            }
            private set
            {
                if (value < Level.StartingLevel)
                {
                    throw new ArgumentException(string.Format("Current can't be less than {0}", Level.StartingLevel));
                }

                this.currentLevel = value;
            }
        }

        public void GainXP(int amount)
        {
            int totalXP = this.CurrentXP + amount;

            while (totalXP >= this.NeedXP)
            {
                totalXP -= NeedXP;
                this.CurrentLevel++;
                this.OnLevelUp(EventArgs.Empty);
            }

            this.CurrentXP = totalXP;
        }
    }
}