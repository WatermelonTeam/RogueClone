namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IGame
    {
        int Speed
        {
            get;
            set;
        }

        void Start();
    }
}
