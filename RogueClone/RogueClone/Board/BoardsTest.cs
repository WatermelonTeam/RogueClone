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
                    Console.SetCursorPosition(wall.X, wall.Y);
                    Console.Write(Floor);
                    //Console.Write('─');
                }
                foreach (var wall in board.VerticalWallsPos)
                {
                    Console.SetCursorPosition(wall.X, wall.Y);
                    Console.Write(Floor);
                    //Console.Write('│');
                }
                foreach (var corner in board.CornersPos)
                {
                    Console.SetCursorPosition(corner.X, corner.Y);
                    Console.Write(Floor);
                    //Console.Write('+');
                }
                Console.BackgroundColor = roomColour;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(board.EntryStairPos.X, board.EntryStairPos.Y);
                Console.Write('0');


                Console.SetCursorPosition(board.ExitStairPos.X, board.ExitStairPos.Y);
                Console.Write('1');

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(board.ShopKeeperPos.X, board.ShopKeeperPos.Y);
                Console.Write('%');
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (var item in board.ItemsPos)
                {
                    Console.SetCursorPosition(item.X, item.Y);
                    Console.Write('?');
                }
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var pile in board.GoldPositionsPos)
                {
                    Console.SetCursorPosition(pile.X, pile.Y);
                    Console.Write('$');
                }
                Console.BackgroundColor = roomColour;
                foreach (var door in board.DoorsPos)
                {
                    Console.SetCursorPosition(door.X, door.Y);
                    Console.Write(Floor);
                    //Console.Write('/');
                }
                foreach (var floor in board.FloorsPos)
                {
                    Console.SetCursorPosition(floor.X, floor.Y);
                    Console.Write(Floor);
                    //Console.Write(':');
                }
                foreach (var corridor in board.CorridorsPos)
                {
                    Console.SetCursorPosition(corridor.X, corridor.Y);
                    Console.Write(Floor);
                }
                Console.ReadKey();
            }
        }
    }
}