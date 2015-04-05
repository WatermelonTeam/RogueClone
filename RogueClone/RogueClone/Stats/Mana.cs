namespace RogueClone
{
    using RogueClone.PCs.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public sealed class Mana : Stat, IStat
    {
        public Mana(int max) 
            : base(max)
        {
        }
    }
}
