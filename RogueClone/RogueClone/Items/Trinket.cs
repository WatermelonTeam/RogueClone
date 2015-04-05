namespace RogueClone
{
    using RogueClone.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Trinket : Item, IPositionable
    {
        private const int ringBonus = 10000;
        private const int charmBonus = 500;
        private const int crystalBonus = 100;
        private const int pendantBonus = 200;
        private const int horseshoeBonus = 50;
        private const int ringLvl = 3;
        private const int charmLvl = 3;
        private const int crystalLvl = 4;
        private const int pendantLvl = 5;
        private const int horseshoeLvl = 2;

        public Trinket(string name, Position position, int value)
            : base(name, position, value, Image.GeneralItem, Color.Yellow)
        {
        }
        public override string Description
        {
            get
            {
                switch ((Image)Enum.Parse(typeof(Image), this.Name.ToLower(), true))
                {
                    case Image.Ring: return string.Format("Gold +{0}", ringBonus);
                    case Image.Charm: return string.Format("Armor +{0}", charmBonus);
                    case Image.Crystal: return string.Format("Max Mana +{0}", crystalBonus);
                    case Image.Pendant: return string.Format("XP +{0}", pendantBonus);
                    case Image.Horseshoe: return string.Format("Weapon +{0}", horseshoeBonus);
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
                    case Image.Ring: return ringLvl;
                    case Image.Charm: return charmLvl;
                    case Image.Crystal: return crystalLvl;
                    case Image.Pendant: return pendantLvl;
                    case Image.Horseshoe: return horseshoeLvl;
                    default: return 0;
                }
            }
        }
        public void Take(Hero hero)
        {
            switch (this.Icon)
            {
                case Image.Ring: hero.Gold += ringBonus; break;
                case Image.Charm: hero.Armor += charmBonus; break;
                case Image.Crystal: hero.Mana.Max += crystalBonus; break;
                case Image.Pendant: hero.Level.CurrentXP += pendantBonus; break;
                case Image.Horseshoe: hero.Weapon += horseshoeBonus; break;
                default: break;
            }
        }
    }
}
