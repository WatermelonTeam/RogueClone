using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public sealed class Health : Stat
    {
        public static readonly Health Instance = new Health(100);
        private Health(int max) 
            : base(max)
        {
        }
    }
}
