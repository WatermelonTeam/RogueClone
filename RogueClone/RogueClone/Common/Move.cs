namespace RogueClone.Common
{
    using System;

    public struct Move
    {
        public Move(Position oldPosition, Position newPosition)
            : this()
        {
            this.OldPosition = oldPosition;
            this.NewPosition = newPosition;
        }

        public Position OldPosition { get; private set; }

        public Position NewPosition { get; private set; }
    }
}
