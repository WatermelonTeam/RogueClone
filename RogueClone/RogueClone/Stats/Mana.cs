using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public sealed class Mana : Stat
    {
        public static readonly Mana Instance = new Mana(100);
        private Mana(int max) 
            : base(max)
        {
        }
    }
}
