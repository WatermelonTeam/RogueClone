using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Level
    {
        public Level(int level)
        {
            this.CurrentLevel = level;
        }
        public int CurrentXP { get; set; }

        public int NeededXP { get; set; }

        public int CurrentLevel { get; set; }

        public void LevelUp()
        {
            this.CurrentLevel++;
        }
    }
}
