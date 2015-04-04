namespace RogueClone
{
    using System;

    public static class BoardsTest
    {
        private const ConsoleColor roomColour = ConsoleColor.DarkBlue;
        private const ConsoleColor outsideColour = ConsoleColor.Black;
        private const char Floor = ' ';
        private const ConsoleColor corridorColour = ConsoleColor.Blue;
        public static void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(130, 50);
            Console.SetBufferSize(130, 50);
            BoardFactory factory = new BoardFactory(new Position(0 + 10, 0 + 2), new Position(80 - 1, 25 - 1));
            while (true)
            {
                Console.BackgroundColor = outsideColour;
                Console.Clear();          
                Board board = factory.GenerateBoard();
                foreach (var wall in board.HorizontalWallsPos)
                {
                    Console.CursorTop = wall.X;
                    Console.CursorLeft = wall.Y;
                    Console.Write(Floor);
                    //Console.Write('─');
                }
                foreach (var wall in board.VerticalWallsPos)
                {
                    Console.CursorTop = wall.X;
                    Console.CursorLeft = wall.Y;
                    Console.Write(Floor);
                    //Console.Write('│');
                }
                foreach (var corner in board.CornersPos)
                {
                    Console.CursorTop = corner.X;
                    Console.CursorLeft = corner.Y;
                    Console.Write(Floor);
                    //Console.Write('+');
                }
                Console.BackgroundColor = roomColour;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.CursorTop = board.EntryStairPos.X;
                Console.CursorLeft = board.EntryStairPos.Y;
                Console.Write('0');

                Console.CursorTop = board.ExitStairPos.X;
                Console.CursorLeft = board.ExitStairPos.Y;
                Console.Write('1');

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.CursorTop = board.ShopKeeperPos.X;
                Console.CursorLeft = board.ShopKeeperPos.Y;
                Console.Write('%');
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (var item in board.ItemsPos)
                {                
                    Console.CursorTop = item.X;
                    Console.CursorLeft = item.Y;
                    Console.Write('?');
                }
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var pile in board.GoldPositionsPos)
                {
                    Console.CursorTop = pile.X;
                    Console.CursorLeft = pile.Y;
                    Console.Write('$');
                }
                Console.BackgroundColor = roomColour;
                foreach (var door in board.DoorsPos)
                {
                    Console.CursorTop = door.X;
                    Console.CursorLeft = door.Y;
                    Console.Write(Floor);
                    //Console.Write('/');
                }
                foreach (var floor in board.FloorsPos)
                {
                    Console.CursorTop = floor.X;
                    Console.CursorLeft = floor.Y;
                    Console.Write(Floor);
                    //Console.Write(':');
                }
                foreach (var corridor in board.CorridorsPos)
                {
                    Console.CursorTop = corridor.X;
                    Console.CursorLeft = corridor.Y;
                    Console.Write(Floor);
                }
                Console.ReadKey();
            }
        }
    }
}