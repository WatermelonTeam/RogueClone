namespace RogueClone
{
    using RogueClone.Common;
    public interface IMovable : IPositionable
    {
        void MoveTo(Board board, Position newPosition);
    }
}
