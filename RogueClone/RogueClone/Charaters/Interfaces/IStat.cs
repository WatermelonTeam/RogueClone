namespace RogueClone.PCs.Interfaces
{
    using System;

    interface IStat
    {
        int Max { get; }
        int Current { get; set; }

        void Increase(int amount);
        void IncreaseMax(int increasedValue);
    }
}