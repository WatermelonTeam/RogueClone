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
        public ShopKeeperOptions ShopKeeperInteraction()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            switch (pressedKey.Key)
            {
                case ConsoleKey.Escape:
                    return ShopKeeperOptions.Escape;
                case ConsoleKey.D1:
                    return ShopKeeperOptions.BuyItemOne;
                case ConsoleKey.D2:
                    return ShopKeeperOptions.BuyItemTwo;
                case ConsoleKey.D3:
                    return ShopKeeperOptions.BuyItemThree;
                case ConsoleKey.D4:
                    return ShopKeeperOptions.BuyItemFour;
                case ConsoleKey.D5:
                    return ShopKeeperOptions.BuyItemFive;
                default:
                    return ShopKeeperOptions.InvalidOption;
            }
        }
    }
}
