namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RogueClone.Common;

    public static class ConsoleRenderer
    {
        public const int StatsPanelHeight = 4;
        public const ConsoleColor BScreenColor = ConsoleColor.DarkBlue;
        public const ConsoleColor FScreenColor = ConsoleColor.White;
        public const ConsoleColor BPanelColor = ConsoleColor.Blue;
        public const ConsoleColor FPanelColor = ConsoleColor.White;
        public const ConsoleColor HerolColor = ConsoleColor.White;
        private static int StatsFirstRow = RogueEngine.ConsoleHeight - StatsPanelHeight;
        private static int StatsSecondRow = StatsFirstRow + 1;
        private static int StatsThirdRow = StatsSecondRow + 1;
        private static int StatsFourthRow = StatsThirdRow + 1;
        private static int StatsFirstCol = 3;
        private static int StatsSecondCol = 22;
        private static int StatsThirdCol = 36;
        private static int StatsFourthCol = 55;
        private static int StatsFifthCol = 75;


        // Todo todo todotodotodo .... Just render the heroes,monsters,non player chars and the dungeon ! Much easy much game !

        // Render a stringbuilder or a string array
        public static void RenderDungeon(Board board)
        {
            Console.BackgroundColor = GlobalConstants.outsideColor.ToConsoleColor();
            Console.Clear();
            foreach (var wall in board.HorizontalWallsPos)
            {
                Console.SetCursorPosition(wall.X, wall.Y);
                Console.Write((char)Image.Empty);
            }
            foreach (var wall in board.VerticalWallsPos)
            {
                Console.CursorTop = wall.Y;
                Console.CursorLeft = wall.X;
                Console.Write((char)Image.Empty);
            }
            foreach (var corner in board.CornersPos)
            {
                Console.CursorTop = corner.Y;
                Console.CursorLeft = corner.X;
                Console.Write((char)Image.Empty);
            }
            Console.BackgroundColor = GlobalConstants.roomColor.ToConsoleColor();
            foreach (var door in board.DoorsPos)
            {
                Console.CursorTop = door.Y;
                Console.CursorLeft = door.X;
                Console.Write((char)Image.Empty);
            }
            foreach (var floor in board.FloorsPos)
            {
                Console.CursorTop = floor.Y;
                Console.CursorLeft = floor.X;
                Console.Write((char)Image.Empty);
            }
            foreach (var corridor in board.CorridorsPos)
            {
                Console.CursorTop = corridor.Y;
                Console.CursorLeft = corridor.X;
                Console.Write((char)Image.Empty);
            }

            Console.ForegroundColor = Color.Magenta.ToConsoleColor(); // constant?
            foreach (var item in board.ItemsPos)
            {
                Console.CursorTop = item.Y;
                Console.CursorLeft = item.X;
                Console.Write('?');
            }
            Console.ForegroundColor = Color.Green.ToConsoleColor(); // constant?
            foreach (var pile in board.GoldPositionsPos)
            {
                Console.CursorTop = pile.Y;
                Console.CursorLeft = pile.X;
                Console.Write('$');
            }
            Console.ForegroundColor = Color.Red.ToConsoleColor(); // constant?
            Console.CursorTop = board.EntryStairPos.Y;
            Console.CursorLeft = board.EntryStairPos.X;
            Console.Write('0');

            Console.CursorTop = board.ExitStairPos.Y;
            Console.CursorLeft = board.ExitStairPos.X;
            Console.Write('1');

            Console.ForegroundColor = Color.Yellow.ToConsoleColor(); // constant?
            Console.CursorTop = board.ShopKeeperPos.Y;
            Console.CursorLeft = board.ShopKeeperPos.X;
            Console.Write('%');
            
        }

        // Just print the hero on the map
        public static void RenderHero(Hero hero)
        {
            PrintOnPosition(hero.Position, ((char)hero.CharacterIcon).ToString(), hero.CharacterColor.ToConsoleColor());
        }

        public static void RenderMonster(Monster monster)
        {
            throw new NotImplementedException();
        }

        public static void RenderItem(Item item)
        {
            PrintOnPosition(item.Position, ((char)item.Icon).ToString(), item.ItemColor.ToConsoleColor());
        }
        public static void RenderItemDescription(Item item)
        {
            PrintOnPosition(
                new Position(StatsFifthCol, StatsFirstRow), 
                string.Format("◄ {0} ►", item.Name), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFifthCol + (string.Format("◄ {0} ►", item.Name).Length - string.Format("(LvL {0})", item.NeededLvl).Length) / 2, StatsSecondRow),
                string.Format("(LvL {0})",
                item.NeededLvl), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFifthCol + (string.Format("◄ {0} ►", item.Name).Length - item.Description.Length) / 2, StatsThirdRow), 
                item.Description, 
                FPanelColor, 
                BPanelColor);
        }
        public static void RemoveItemDescription(int nameLength, int descriptionLength)
        {
            PrintOnPosition(
                new Position(StatsFourthCol + "Gold: 123456789".Length, StatsFirstRow),
                "".PadRight(RogueEngine.ConsoleWidth - StatsFourthCol + "Gold: 123456789".Length, ' '), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFourthCol + "Gold: 123456789".Length, StatsSecondRow),
                "".PadRight(RogueEngine.ConsoleWidth - StatsFourthCol + "Gold: 123456789".Length, ' '), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFourthCol + "Gold: 123456789".Length, StatsThirdRow),
                "".PadRight(RogueEngine.ConsoleWidth - StatsFourthCol + "Gold: 123456789".Length, ' '), 
                FPanelColor, 
                BPanelColor);
        }

        // Render the stats at the bottom of the console

        public static void RenderPanel()
        {
            Console.BackgroundColor = BScreenColor;
            Console.ForegroundColor = FScreenColor;
            //Console.Clear();
            Console.BackgroundColor = BPanelColor;
            Console.ForegroundColor = FPanelColor;

            for (int i = 1; i <= ConsoleRenderer.StatsPanelHeight; i++)
            {
                Console.SetCursorPosition(0, RogueEngine.ConsoleHeight - i);
                Console.Write("".PadRight(RogueEngine.ConsoleWidth - 1, ' '));
            }
            Console.BackgroundColor = BScreenColor;
            Console.ForegroundColor = FScreenColor;

        }
        public static void RenderStats(Hero hero)
        {
            //PrintOnPosition(0, StatsFirstRow, new string('─', Game.ConsoleWidth), fPanelColor, bPanelColor);
            PrintOnPosition(new Position(StatsFirstCol, StatsSecondRow), string.Format("HP: {0} \\ {1}", hero.Health.Current.ToString().PadLeft(hero.Health.Max.ToString().Length, ' '), hero.Health.Max), FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsFirstCol, StatsThirdRow), string.Format("MP: {0} \\ {1}", hero.Mana.Current.ToString().PadLeft(hero.Mana.Max.ToString().Length, ' '), hero.Mana.Max), FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsSecondCol, StatsSecondRow), string.Format("Level: {0}", hero.Level.CurrentLevel.ToString().PadRight(3, ' ')), FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsSecondCol, StatsThirdRow), string.Format("XP: {0}", hero.Level.CurrentXP.ToString().PadRight(7, ' ')), FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsThirdCol, StatsSecondRow), string.Format("Armor: {0}", hero.Armor.ToString().PadRight(4, ' ')), FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsThirdCol, StatsThirdRow), string.Format("Damage: {0}", hero.Weapon.ToString().PadRight(4, ' ')), FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsFourthCol, StatsSecondRow), string.Format("Gold: {0}", hero.Gold.ToString().PadRight(9, ' ')), FPanelColor, BPanelColor);
            PrintOnPosition(new Position(83, StatsFourthRow), string.Format("X : {0}, Y : {1}", hero.Position.X.ToString().PadRight(3, ' '), hero.Position.Y.ToString().PadRight(3, ' ')), FPanelColor, BPanelColor);

        }

        public static void RenderMove(Board board, Hero hero, Position newPosition)
        {
            Move move = new Move(hero.Position, newPosition);
            hero.MoveTo(board, newPosition);
            RenderHero(hero);
            Console.SetCursorPosition(hero.Position.X, hero.Position.Y);
            RenderObjectRemoval(move.OldPosition, hero);
            
            
        }
        public static void RenderObjectRemoval(Position position, Hero hero)
        {
            PrintOnPosition(position, ' '.ToString(), GlobalConstants.roomColor.ToConsoleColor(), GlobalConstants.roomColor.ToConsoleColor());
            RenderHero(hero);
        }

        public static void PrintOnPosition(Position position, string text, ConsoleColor foregroundColor = FScreenColor, ConsoleColor backgroundColor = BScreenColor)
        {
            if (IsValidPosition(position))
            {
                var oldForegroundColor = Console.ForegroundColor;
                var oldBackgroundColor = Console.BackgroundColor;
                Console.BackgroundColor = backgroundColor;
                Console.ForegroundColor = foregroundColor;
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write(text);
                Console.BackgroundColor = oldForegroundColor;
                Console.ForegroundColor = oldBackgroundColor;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format("Position ({0},{1}) is out of the valid range [{2},{3})", position, RogueEngine.ConsoleWidth, RogueEngine.ConsoleHeight));
            }
            
        }
        private static bool IsValidPosition(Position position)
        {
            return 0 <= position.X
                && 0 <= position.Y
                && position.X < RogueEngine.ConsoleWidth
                && position.Y < RogueEngine.ConsoleHeight;
        }
    }
}
