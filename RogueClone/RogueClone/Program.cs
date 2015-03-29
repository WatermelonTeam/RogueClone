using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(80, 40, 100);
            game.Start();
            
        }
    }
}