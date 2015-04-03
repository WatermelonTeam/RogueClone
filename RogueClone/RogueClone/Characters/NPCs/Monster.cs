namespace RogueClone
{
    using System;

    public class Monster : NPC, IPositionable
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

        public Point2D Position
        {
            get { throw new NotImplementedException(); }
        }
    }
}
