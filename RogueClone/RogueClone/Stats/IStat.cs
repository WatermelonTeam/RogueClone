namespace RogueClone.Stats
{
    using System;

    public interface IStat
    {
        int Max { get; set; }
        int Current { get; set; }

        void Regen();
    }
}