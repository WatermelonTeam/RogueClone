using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class NPC : IDamagable, IKillable
    {
        public int Health
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int XPGain
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Damage
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }

        public event EventHandler Dead;
    }
}
