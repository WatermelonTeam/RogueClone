using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Monsters : NPC, IPositionable
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

        public int PositionX
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int PositionY
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public void MoveTo(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
