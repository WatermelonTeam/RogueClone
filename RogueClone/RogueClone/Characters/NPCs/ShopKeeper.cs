namespace RogueClone
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShopKeeper : NPC, IDamageable, IKillable, IPositionable
    {
        private ICollection<Item> items;

        public ShopKeeper(string name, Position position, int maxHealth, ICollection<Item> items) // maxHealth can be set as a constant for the shopkeeper class
            : base(name, position, maxHealth, Image.ShopKeeper, Color.Yellow)
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