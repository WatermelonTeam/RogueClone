using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public interface IMovable
    {
        void MoveTo(Position newPosition, char steppedOnItem, ConsoleColor color);
    }
}
