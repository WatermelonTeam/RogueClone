namespace RogueClone.InputProviders
{
    using RogueClone.Common;
    using System;

    public interface IConsoleIInputProvider
    {
        void SetMovement(Board board, IMovable hero);
    }
}
