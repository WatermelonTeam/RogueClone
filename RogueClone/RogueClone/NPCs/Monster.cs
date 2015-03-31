using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Monster : NPC, IMovable
    {
        public int Level
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        public void MoveTo(Point2D newPosition, char steppedOnItem, ConsoleColor itemColor)
        {
            throw new NotImplementedException();
        }
    }
}
