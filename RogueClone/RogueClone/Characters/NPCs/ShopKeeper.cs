namespace RogueClone
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Common;

    public class ShopKeeper : NPC, IDamageable, IKillable
    {
        private ICollection<Item> items;

        public ShopKeeper(string name, int maxHealth, ICollection<Item> items) // maxHealth can be set as a constant for the shopkeeper class
            : base(name, maxHealth, Image.ShopKeeper, Color.Magenta)
        {
            this.Items = items;
        }

        public ICollection<Item> Items
        {
            get
            {
                return this.items.ToArray();
            }
            private set
            {
                Validator.IsNotNull(value, "Shopkeeper items");

                this.items = value;
            }
        }

        public void SellItem(Item item)
        {
            this.items.Remove(item);
        }
    }
}