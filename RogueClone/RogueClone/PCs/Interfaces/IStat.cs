namespace RogueClone.PCs.Interfaces
{
    using System;

    interface IStat
    {
        int Max { get; set; }
        int Current { get; set; }

        void IncreaseMax();
    }
}