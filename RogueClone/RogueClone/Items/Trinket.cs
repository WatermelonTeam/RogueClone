namespace RogueClone
{
    using RogueClone.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Trinket : Item, IPositionable
    {
        private static Random rand = new Random();
        private static int randomTrinket = rand.Next(1, NumberofTrinketTypes + 1);
        private static int randomDevaluation = rand.Next(1, 7);
        private const int NumberofTrinketTypes = 5;
        private static int RingBonus = 10000 / randomDevaluation;
        private static int CharmBonus = 500 / randomDevaluation;
        private static int CrystalBonus = 100 / randomDevaluation;
        private static int PendantBonus = 200 / randomDevaluation;
        private static int HorseshoeBonus = 100 / randomDevaluation;
        private const int RingLvl = 3;
        private const int CharmLvl = 3;
        private const int CrystalLvl = 4;
        private const int PendantLvl = 5;
        private const int HorseshoeLvl = 2;
        private static int RingValue = 300 / randomDevaluation;
        private static int CharmValue = 200 / randomDevaluation;
        private static int CrystalValue = 150 / randomDevaluation;
        private static int PendantValue = 100 / randomDevaluation;
        private static int HorseshoeValue = 800 / randomDevaluation;

        public Trinket(Position position)
            : base("Trinket", position, 100, Image.GeneralItem, Color.Yellow)
        {
        }
        public override string Name
        {
            get
            {
                switch (randomTrinket)
                {
                    case 1: return "Ring";
                    case 2: return "Charm";
                    case 3: return "Crystal";
                    case 4: return "Pendant";
                    case 5: return "Horseshoe";
                    default: return "Trinket";
                }
            }
        }

        public override string Description
        {
            get
            {
                switch ((Image)Enum.Parse(typeof(Image), this.Name.ToLower(), true))
                {
                    case Image.Ring: return string.Format("Gold +{0}", RingBonus);
                    case Image.Charm: return string.Format("Armor +{0}", CharmBonus);
                    case Image.Crystal: return string.Format("Max Mana +{0}", CrystalBonus);
                    case Image.Pendant: return string.Format("XP +{0}", PendantBonus);
                    case Image.Horseshoe: return string.Format("Weapon +{0}", HorseshoeBonus);
                    default: return "";
                }
            }
        }
        public override Image Icon
        {
            get
            {
                switch ((Image)Enum.Parse(typeof(Image), this.Name.ToLower(), true))
                {
                    case Image.Ring: return Image.Ring;
                    case Image.Charm: return Image.Charm;
                    case Image.Crystal: return Image.Crystal;
                    case Image.Pendant: return Image.Pendant;
                    case Image.Horseshoe: return Image.Horseshoe;
                    default: return Image.GeneralItem;
                }
            }
        }
        public override int NeededLvl
        {
            get
            {
                switch ((Image)Enum.Parse(typeof(Image), this.Name.ToLower(), true))
                {
                    case Image.Ring: return RingLvl;
                    case Image.Charm: return CharmLvl;
                    case Image.Crystal: return CrystalLvl;
                    case Image.Pendant: return PendantLvl;
                    case Image.Horseshoe: return HorseshoeLvl;
                    default: return 0;
                }
            }
        }
        public override int Value
        {
            get
            {
                switch ((Image)Enum.Parse(typeof(Image), this.Name.ToLower(), true))
                {
                    case Image.Ring: return RingValue;
                    case Image.Charm: return CharmValue;
                    case Image.Crystal: return CrystalValue;
                    case Image.Pendant: return PendantValue;
                    case Image.Horseshoe: return HorseshoeValue;
                    default: return 0;
                }
            }
        }
        public void Take(Hero hero)
        {
            switch (this.Name.ToLower())
            {
                case "ring": hero.Gold += RingBonus; break;
                case "charm": hero.Armor += CharmBonus; break;
                case "crystal": hero.Mana.Max += CrystalBonus; break;
                case "pendant": hero.Level.CurrentXP += PendantBonus; break;
                case "horseshoe": hero.Weapon += HorseshoeBonus; break;
                default: break;
            }
        }
    }
}
