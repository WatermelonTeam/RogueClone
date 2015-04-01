namespace RogueClone
{
    using System;

    public static class BoardsTest
    {
        public static void Start()
        {
            Console.CursorVisible = false;
            BoardFactory factory = new BoardFactory(new Point2D(0, 0), new Point2D(25, 80));
            while (true)
            {
                Console.Clear();          
                Board board = factory.GenerateBoard();
                foreach (var corner in board.Corners)
                {
                    Console.CursorTop = corner.X;
                    Console.CursorLeft = corner.Y;
                    Console.Write('+');
                }
                foreach (var wall in board.HorizontalWalls)
                {
                    Console.CursorTop = wall.X;
                    Console.CursorLeft = wall.Y;
                    Console.Write('-');
                }
                foreach (var wall in board.VerticalWalls)
                {
                    Console.CursorTop = wall.X;
                    Console.CursorLeft = wall.Y;
                    Console.Write('|');
                }

                Console.CursorTop = board.EntryStair.X;
                Console.CursorLeft = board.EntryStair.Y;
                Console.Write('0');

                Console.CursorTop = board.ExitStair.X;
                Console.CursorLeft = board.ExitStair.Y;
                Console.Write('1');

                Console.CursorTop = board.ShopKeeper.X;
                Console.CursorLeft = board.ShopKeeper.Y;
                Console.Write('%');
                foreach (var item in board.Items)
                {                
                    Console.CursorTop = item.X;
                    Console.CursorLeft = item.Y;
                    Console.Write('?');
                }
                foreach (var pile in board.GoldPostions)
                {
                    Console.CursorTop = pile.X;
                    Console.CursorLeft = pile.Y;
                    Console.Write('$');
                }
                foreach (var door in board.Doors)
                {
                    Console.CursorTop = door.X;
                    Console.CursorLeft = door.Y;
                    Console.Write('/');
                }
                foreach (var door in board.Doors)
                {
                    Console.CursorTop = door.X;
                    Console.CursorLeft = door.Y;
                    Console.Write('/');
                }
                foreach (var floor in board.Floors)
                {
                    Console.CursorTop = floor.X;
                    Console.CursorLeft = floor.Y;
                    Console.Write(':');
                }
                Console.ReadKey();
            }
        }
    }
}