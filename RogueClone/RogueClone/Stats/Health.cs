namespace RogueClone
{
    using RogueClone.PCs.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public sealed class Health : Stat, IStat
    {
        public Health(int max) 
            : base(max)
        {
        }
    }
}
