using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    
    public class Trinket : Item
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

        public enum trinkets { ring = 'ö', charm = '©', crystal = '♦', pendant = '§', horseshoe = 'Ω' };
        public Trinket(string name, Position position, int value)
            : base(name, position, value)
        {
        }
        public override string Description
        {
            get
            {
                switch ((trinkets)Enum.Parse(typeof(trinkets), this.Name.ToLower(), true))
                {
                    case trinkets.ring: return string.Format("Gold +{0}", ringBonus);
                    case trinkets.charm: return string.Format("Armor +{0}", charmBonus);
                    case trinkets.crystal: return string.Format("Max Mana +{0}", crystalBonus);
                    case trinkets.pendant: return string.Format("XP +{0}", pendantBonus);
                    case trinkets.horseshoe: return string.Format("Weapon +{0}", horseshoeBonus);
                    default: return "";
                }
            }
        }
        public override char Icon
        {
            get
            {
                switch ((trinkets)Enum.Parse(typeof(trinkets), this.Name.ToLower(), true))
                {
                    case trinkets.ring: return (char)trinkets.ring;
                    case trinkets.charm: return (char)trinkets.charm;
                    case trinkets.crystal: return (char)trinkets.crystal;
                    case trinkets.pendant: return (char)trinkets.pendant;
                    case trinkets.horseshoe: return (char)trinkets.horseshoe;
                    default: return ' ';
                }
            }
        }
        public override int NeededLvl
        {
            get
            {
                switch ((trinkets)Enum.Parse(typeof(trinkets), this.Name.ToLower(), true))
                {
                    case trinkets.ring: return ringLvl;
                    case trinkets.charm: return charmLvl;
                    case trinkets.crystal: return crystalLvl;
                    case trinkets.pendant: return pendantLvl;
                    case trinkets.horseshoe: return horseshoeLvl;
                    default: return 0;
                }
            }
        }
        public override ConsoleColor Color { get { return ConsoleColor.Magenta; } }

        public void Take(Hero hero)
        {
            switch (this.Icon)
            {
                case (char)trinkets.ring: hero.Gold += ringBonus; break;
                case (char)trinkets.charm: hero.Armor += charmBonus; break;
                case (char)trinkets.crystal: hero.Mana.Max += crystalBonus; break;
                case (char)trinkets.pendant: hero.Level.CurrentXP += pendantBonus; break;
                case (char)trinkets.horseshoe: hero.Weapon += horseshoeBonus; break;
                default: break;
            }
        }
    }
}
