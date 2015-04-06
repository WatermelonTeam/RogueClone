using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Level
    {
        private const int initialNeededXP = 222;
        public Level(int level)
        {
            this.CurrentLevel = level;
            this.NeededXP = initialNeededXP;
        }
        public int CurrentXP { get; set; }

        public int NeededXP { get; private set; }

        public int CurrentLevel { get; private set; }

        public void AddXP( int amount)
        {
            this.CurrentXP += amount;
        }
        public void LevelUp()
        {
            this.CurrentLevel++;
            this.NeededXP += (int)Math.Sqrt(this.NeededXP * 5);
        }
    }
}
