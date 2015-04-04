namespace RogueClone.Movement
{
    using RogueClone.Common;
    using System;

    public interface IMovement
    {
        bool ValidateMovement(IMovable character, Board board, Position newPosition);
    }
}
