namespace RogueClone
{
    using System;

    public class Monster : NPC, IPositionable, IMovable
    {
        protected Monster(string name, int maxHP)
            : base(name, maxHP)
        {
            ;
        }

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

        public override void TakeDamage()
        {
            throw new NotImplementedException();
        }

        public Position Position
        {
            get { throw new NotImplementedException(); }
        }

        public void MoveTo(Position newPosition, char steppedOnItem, ConsoleColor color)
        {
            throw new NotImplementedException();
        }
    }
}
