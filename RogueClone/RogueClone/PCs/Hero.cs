using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public abstract class Hero : IDamagable, IPositionable, IKillable
    {
        public int HeroHealth
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int HeroMana
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int HeroLevel
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

        public int Weapon
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Armor
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

        public void MoveTo()
        {
            throw new NotImplementedException();
        }

        public abstract void CastSkillOne()
        {
            throw new System.NotImplementedException();
        }

        public abstract void CastSkillTwo()
        {
            throw new System.NotImplementedException();
        }

        public event EventHandler Dead;
    }
}
