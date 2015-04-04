using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public class Gold : Item
    {
        public Gold(Position position, int value)
            : base(position, value)
        {
        }
        public override string Name { get { return "Gold"; } }
        public override string Description
        {
            get
            {
                return string.Format("Gold +{0}", this.Value);
            }
        }
        public override char Icon 
        { 
            get 
            {
                if (this.Value < 100)
                {
                    return '¥'; 
                }
                else if (this.Value < 200)
                {
                    return '$';
                }
                else if (this.Value < 300)
                {
                    return '€';
                }
                else
                {
                    return '£';
                }
            } 
        }
        public override ConsoleColor Color { get { return ConsoleColor.Green; } }
        public void Take(Hero hero)
        {
            hero.Gold += this.Value;
        }
    }
}
