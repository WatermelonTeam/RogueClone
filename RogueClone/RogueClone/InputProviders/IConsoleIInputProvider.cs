namespace RogueClone.InputProviders
{
    using RogueClone.Common;
    using System;

    public interface IConsoleIInputProvider
    {
        Position SetMovement(Board board, Position position);
    }
}
