using RogueClone.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Gold : Item, IPositionable
    {
        public Gold(Position position, int value)
            : base("Gold", string.Format("Gold +{0}", value), value, 1, position, Image.Gold, Color.Green)
        {
        }
        public override string Name { get { return "Gold"; } }
        //public override string Description
        //{
        //    get
        //    {
        //        return string.Format("Gold +{0}", this.Value);
        //    }
        //}
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
