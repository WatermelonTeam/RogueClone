using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public interface IMovable
    {
        int PositionX
        {
            get;
            set;
        }
        int PositionY
        {
            get;
            set;
        }

        void MoveTo(int x, int y);
    }
}
