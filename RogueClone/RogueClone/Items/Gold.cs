using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Gold : Item, IPositionable
    {
        private static Random rand = new Random();
        private static int random = rand.Next(1, 10);
        public Gold(Position position)
            : base("Gold", "", 0, 1, position, Image.Gold, Color.Green)
        {
        }
        public override string Description
        {
            get
            {
                return string.Format("Gold +{0}", this.Value);
            }
        }
        public override int Value
        {
            get
            {
                switch (random)
                {
                    case 1: return 100;
                    case 2: return 200;
                    case 3: return 300;
                    case 4: return 400;
                    case 5: return 500;
                    default: return 50;
                }
            }
        }
        //public override Image Icon 
        //{ 
        //    get 
        //    {
        //        if (this.Value < 100)
        //        {
        //            return '¥'; 
        //        }
        //        else if (this.Value < 200)
        //        {
        //            return '$';
        //        }
        //        else if (this.Value < 300)
        //        {
        //            return '€';
        //        }
        //        else
        //        {
        //            return '£';
        //        }
        //    } 
        //}
        //public override Color ItemColor { get { return Color.Green; } }
        public void Take(Hero hero)
        {
            hero.Gold += this.Value;
        }
    }
}
