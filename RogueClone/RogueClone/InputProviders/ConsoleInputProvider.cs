using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone.InputProviders
{
    public class ConsoleInputProvider : IConsoleIInputProvider
    {
        public void SetMovement(Board board, IMovable hero)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            switch (pressedKey.Key)
            {
                case ConsoleKey.RightArrow:
                    ConsoleRenderer.RenderMove(board, hero, new Position(hero.Position.X + 1, hero.Position.Y));
                    break;
                case ConsoleKey.LeftArrow:
                    ConsoleRenderer.RenderMove(board, hero, new Position(hero.Position.X - 1, hero.Position.Y));
                    break;
                case ConsoleKey.UpArrow:
                    ConsoleRenderer.RenderMove(board, hero, new Position(hero.Position.X, hero.Position.Y - 1));
                    break;
                case ConsoleKey.DownArrow:
                    ConsoleRenderer.RenderMove(board, hero, new Position(hero.Position.X, hero.Position.Y + 1));
                    break;
                default:
                    break;
            }
        }
    }
}
