namespace RogueClone.Items.Consumables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPotion
    {
        int amount { get; } // set it true the constructor and decrease it with the UsePotion method !
        void UsePotion();
    }
}
