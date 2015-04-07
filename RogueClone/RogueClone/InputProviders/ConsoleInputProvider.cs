using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone.InputProviders
{
    public class ConsoleInputProvider : IConsoleIInputProvider
    {
        public Position SetMovement(Board board, Position position)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            switch (pressedKey.Key)
            {
                case ConsoleKey.RightArrow: return new Position(position.X + 1, position.Y);
                case ConsoleKey.LeftArrow: return new Position(position.X - 1, position.Y);
                case ConsoleKey.UpArrow: return new Position(position.X, position.Y - 1);
                case ConsoleKey.DownArrow: return new Position(position.X, position.Y + 1);
                default: return position;
            }
        }
    }
}
