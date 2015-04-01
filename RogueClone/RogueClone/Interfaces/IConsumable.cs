using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public interface IConsumable
    {
        void Consumed(Hero hero);
    }
}
