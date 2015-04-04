using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public interface IMovable
    {
        void MoveTo(Board board, Position newPosition);
    }
}
