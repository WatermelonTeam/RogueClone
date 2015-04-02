namespace RogueClone.Stats
{
    using System;

    public interface ILvL
    {
        event EventHandler LevelUp;

        int CurrentXP { get; private set; }
        int NeedXP { get; set; }
        int CurrentLevel { get; private set; }

        void GainXP(int amount);
    }
}