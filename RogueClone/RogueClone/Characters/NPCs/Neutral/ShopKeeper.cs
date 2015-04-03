using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class ShopKeeper : NPC
    {
        ShopKeeper(string name, int maxHP)
            : base(name, maxHP)
        {
            ;
        }

        public int Items
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Gold
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Position
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

        public override void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}
