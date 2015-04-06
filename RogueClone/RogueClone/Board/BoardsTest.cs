namespace RogueClone
{
    using RogueClone.Common;
    using System.Linq;
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
                Console.CursorVisible = false;
                Console.OutputEncoding = System.Text.Encoding.Unicode;

                Console.Title = "░░░░ ROGUECLONE ░░░░";

                //foreach (var wall in board.HorizontalWallsPos)
                //{
                //    Console.SetCursorPosition(wall.X, wall.Y);
                //    Console.Write(' ');
                //}
                //foreach (var wall in board.VerticalWallsPos)
                //{
                //    Console.CursorTop = wall.Y;
                //    Console.CursorLeft = wall.X;
                //    Console.Write(' ');
                //}
                //foreach (var corner in board.CornersPos)
                //{
                //    Console.CursorTop = corner.Y;
                //    Console.CursorLeft = corner.X;
                //    Console.Write(' ');
                //}
                Console.BackgroundColor = GlobalConstants.RoomColor.ToConsoleColor();
                var commonWalkableDungeon = board.FloorsPos.Concat(board.CorridorsPos).ToArray();
                for (int i = 0; i < commonWalkableDungeon.Length; i++)
                {
                    Console.SetCursorPosition(commonWalkableDungeon[i].X, commonWalkableDungeon[i].Y);
                    Console.Write(' ');
                }
                //foreach (var door in board.DoorsPos)
                //{
                //    Console.CursorTop = door.Y;
                //    Console.CursorLeft = door.X;
                //    Console.Write(' ');
                //}
                //foreach (var floor in board.FloorsPos)
                //{
                //    Console.CursorTop = floor.Y;
                //    Console.CursorLeft = floor.X;
                //    Console.Write(' ');
                //}
                //foreach (var corridor in board.CorridorsPos)
                //{
                //    Console.CursorTop = corridor.Y;
                //    Console.CursorLeft = corridor.X;
                //    Console.Write(' ');
                //}

                Console.ForegroundColor = Color.Magenta.ToConsoleColor(); // constant?
                foreach (var item in board.PositionableObjects) ///////////////////////// fix remnant of an item at (0,0)
                {
                    Console.CursorTop = item.Position.Y;
                    Console.CursorLeft = item.Position.X;
                    Console.Write('?');
                }
                Console.ForegroundColor = Color.Green.ToConsoleColor(); // constant?
                foreach (var pile in board.GoldPositionsPos)
                {
                    Console.CursorTop = pile.Y;
                    Console.CursorLeft = pile.X;
                    Console.Write('$');
                }
                Console.BackgroundColor = Color.Black.ToConsoleColor();
                Console.ForegroundColor = Color.Red.ToConsoleColor(); // constant?
                Console.SetCursorPosition(board.EntryStairPos.X, board.EntryStairPos.Y);
                Console.Write('≡');
                Console.ForegroundColor = Color.Green.ToConsoleColor();
                Console.SetCursorPosition(board.ExitStairPos.X, board.ExitStairPos.Y);
                Console.Write('≡');
                Console.BackgroundColor = GlobalConstants.RoomColor.ToConsoleColor();
                Console.ForegroundColor = Color.Yellow.ToConsoleColor(); // constant?
                Console.SetCursorPosition(board.ShopKeeperPos.X, board.ShopKeeperPos.Y);
                Console.Write('%');
                Console.ReadKey();
            }
        }
    }
}