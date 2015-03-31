using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone
{
    class GameMain
    {
        static void Main(string[] args)
        {
            var game = new Game(100, 30, 100, new Point2D(10,10)); // Dont change the values ! They could be magical !
            game.Start();
        }
    }
}