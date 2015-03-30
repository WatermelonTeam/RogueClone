using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone.Items.Consumables
{
    public class HealthPotion : Potion
    {
        public HealthPotion(string name, int price, int neededLevel, int posX, int posY, string icon, int amountRestored)
            : base(name, price, neededLevel, posX, posY, icon, amountRestored)
        {

        }
    }
}
