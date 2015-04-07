namespace RogueClone
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShopKeeper : NPC, IDamageable, IKillable, IPositionable
    {
        private const int ShopKeeperItemsCount = 5;
        private static readonly Random rand = new Random();

        private Item[] items;

        public ShopKeeper(string name, Position position, int maxHealth) // maxHealth can be set as a constant for the shopkeeper class
            : base(name, position, maxHealth, Image.ShopKeeper, Color.Yellow)
        {
            this.Items = new Item[ShopKeeper.ShopKeeperItemsCount];
        }

        public Item[] Items
        {
            get
            {
                return this.items;
            }
            private set
            {
                Validator.IsNotNull(value, "Shopkeeper items");

                this.items = value;
            }
        }

        public static ShopKeeper GetShopKeeper(Position position)
        {
            const string ShopKeeperName = "Tayn Eeon";
            const int ShopKeeperHealth = 1024;
            const int ShopKeeperDamage = 1024;
            const int ShopKeeperXP = 1024;

            ShopKeeper shopKeeper = new ShopKeeper(ShopKeeperName, position, ShopKeeperHealth)
            {
                Damage = ShopKeeperDamage, XPGain = ShopKeeperXP
            };

            for (int i = 0; i < shopKeeper.items.Length; i++)
            {
                int randomItem = ShopKeeper.rand.Next(0, 5);
                int randomItemLevel = ShopKeeper.rand.Next(1, 6);
                int itemValue = randomItemLevel * 1000;

                switch (randomItem)
                {
                    case 0:
                        shopKeeper.items[i] = new RogueArmor(new Position(), itemValue, randomItemLevel);
                        break;
                    case 1:
                        shopKeeper.items[i] = new WizardArmor(new Position(), itemValue, randomItemLevel);
                        break;
                    case 2:
                        shopKeeper.items[i] = new RogueWeapon(new Position(), itemValue, randomItemLevel);
                        break;
                    case 3:
                        shopKeeper.items[i] = new WizardWeapon(new Position(), itemValue, randomItemLevel);
                        break;
                    case 4:
                        shopKeeper.items[i] = new Trinket(new Position());
                        break;
                    default:
                        throw new ArgumentException("Invalid random item.");
                }
            }

            return shopKeeper;
        }
    }
}