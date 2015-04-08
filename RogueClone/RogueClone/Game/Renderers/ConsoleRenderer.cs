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
        public const int StatsPanelHeight = 5;
        public const ConsoleColor BScreenColor = ConsoleColor.DarkBlue;
        public const ConsoleColor FScreenColor = ConsoleColor.White;
        public const ConsoleColor BPanelColor = ConsoleColor.Blue;
        public const ConsoleColor FPanelColor = ConsoleColor.White;
        public const ConsoleColor HerolColor = ConsoleColor.White;
        private static int StatsFirstRow = RogueEngine.ConsoleHeight - StatsPanelHeight;
        private static int StatsSecondRow = StatsFirstRow + 1;
        private static int StatsThirdRow = StatsSecondRow + 1;
        private static int StatsFourthRow = StatsThirdRow + 1;
        private static int StatsFifthRow = StatsFourthRow + 1;
        private static int StatsFirstCol = 3;
        private static int StatsSecondCol = 22;
        private static int StatsThirdCol = 40;
        private static int StatsFourthCol = 55;
        private static int StatsFifthCol = 75;
        private static int StatsSixthCol = RogueEngine.ConsoleWidth - 31;


        // Todo todo todotodotodo .... Just render the heroes,monsters,non player chars and the dungeon ! Much easy much game !

        // Render a stringbuilder or a string array

        public static void RenderPlayingScreen(Hero hero, Board board, int boardLevel)
        {
            RenderPanelAndBackground(hero);
            RenderStaticPanelStats(hero);
            RenderStats(hero, boardLevel);
            RenderDungeon(board);
            RenderAllItems(board.PositionableObjects);
            RenderCharacter(hero);
        }
        public static void RenderDungeon(Board board)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.Title = "████ ROGUECLONE ████";

            Console.BackgroundColor = GlobalConstants.RoomColor.ToConsoleColor();
            var commonWalkableDungeon = board.FloorsPos.Concat(board.CorridorsPos).ToArray();
            // exception test
            // commonWalkableDungeon[commonWalkableDungeon.Length - 1] = new Position(-1, 1);
            for (int i = 0; i < commonWalkableDungeon.Length; i++)
            {
                if (IsValidPosition(commonWalkableDungeon[i]))
                {
                    Console.SetCursorPosition(commonWalkableDungeon[i].X, commonWalkableDungeon[i].Y);
                    Console.Write(' ');
                }
                else
                {
                    throw new InvalidPositionRangeException(string.Format("Tried to print on {0}.", commonWalkableDungeon[i]), 0, RogueEngine.ConsoleWidth, 0, RogueEngine.ConsoleHeight);
                }
                
            }
            RenderStairs(board);
        }
        
        public static void RenderStairs(Board board)
        {
            Console.BackgroundColor = Color.Black.ToConsoleColor();
            Console.ForegroundColor = Color.Red.ToConsoleColor(); // constant?
            Console.SetCursorPosition(board.EntryStairPos.X, board.EntryStairPos.Y);
            Console.Write('≡');
            Console.ForegroundColor = Color.Green.ToConsoleColor(); // constant?
            Console.SetCursorPosition(board.ExitStairPos.X, board.ExitStairPos.Y);
            Console.Write('≡');
        }
        public static void RenderCharacter(Character character)
        {
                PrintOnPosition(character.Position, ((char)character.CharacterIcon).ToString(), character.CharacterColor.ToConsoleColor());
        }
        public static void RenderShopKeeperMenu(ShopKeeper shopKeeper, Hero hero)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleRenderer.Clear();
            int startingTop = (Console.BufferHeight / 2) - 2;
            int startingLeft = 47;
            Console.SetCursorPosition(startingLeft, startingTop);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The ShopKeeper {0} offers these items:", shopKeeper.Name);
            Console.CursorLeft = startingLeft;

            for (int i = 0; i < shopKeeper.Items.Length; i++)
            {
                if (shopKeeper.Items[i] != null)
                {
                    if (hero.Gold >= shopKeeper.Items[i].Value)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                    }
                    Console.WriteLine("{0}. {1} - {2} Price: {3}", i + 1, shopKeeper.Items[i].Name, shopKeeper.Items[i].Description, shopKeeper.Items[i].Value);
                    Console.CursorLeft = startingLeft;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Esc: Exit.");
        }
        public static void RenderItem(IPositionable item)
        {
            PrintOnPosition(item.Position, ((char)(item as Item).Icon).ToString(), (item as Item).ItemColor.ToConsoleColor());
            
        }
        public static void RenderAllItems(ICollection<IPositionable> items)
        {
            foreach (var item in items)
            {
                if (item is Item)
                {
                    RenderItem(item);
                }
                else if (item is Character)
                {
                    RenderCharacter(item as Character);
                }
                
            }
        }
        public static void Clear()
        {
            Console.Clear();
        }
       
        public static void RenderCharacterDescription(Character character)
        {
            PrintOnPosition(
                new Position(StatsFifthCol, StatsFirstRow),
                character.Name,
                FPanelColor,
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFifthCol + (character.Name.Length - string.Format("{0}", character).Length) / 2, StatsSecondRow),
                string.Format("{0}", character),
                FPanelColor,
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFifthCol + (character.Name.Length - character.Health.Current.ToString().Length) / 2, StatsThirdRow),
                character.Health.Current.ToString(),
                FPanelColor,
                BPanelColor);
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
        public static void RemoveDescription(int nameLength, int descriptionLength)
        {
            PrintOnPosition(
                new Position(StatsFourthCol + "Gold: 123456789".Length, StatsFirstRow),
                "".PadRight(StatsSixthCol - (StatsFourthCol + "Gold: 123456789".Length), ' '), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFourthCol + "Gold: 123456789".Length, StatsSecondRow),
                "".PadRight(StatsSixthCol - (StatsFourthCol + "Gold: 123456789".Length), ' '), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFourthCol + "Gold: 123456789".Length, StatsThirdRow),
                "".PadRight(StatsSixthCol - (StatsFourthCol + "Gold: 123456789".Length), ' '), 
                FPanelColor, 
                BPanelColor);
        }
        public static void RenderPanelAndBackground(Hero hero)
        {
            Console.BackgroundColor = GlobalConstants.OutsideColor.ToConsoleColor();
            Console.Clear();
            Console.BackgroundColor = BPanelColor;
            Console.ForegroundColor = FPanelColor;

            for (int i = 1; i <= ConsoleRenderer.StatsPanelHeight; i++)
            {
                Console.SetCursorPosition(0, RogueEngine.ConsoleHeight - i);
                Console.Write(' ');
                Console.SetCursorPosition(1, RogueEngine.ConsoleHeight - i);
                Console.Write("".PadRight(RogueEngine.ConsoleWidth - 1, ' '));
            }
        }
        public static void RenderStaticPanelStats(Hero hero)
        {
            PrintOnPosition(new Position(StatsFirstCol, StatsSecondRow), "HP: ", FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsFirstCol, StatsThirdRow), "MP: ", FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsFirstCol, StatsFourthRow), "XP: ", FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsSecondCol, StatsSecondRow), "Armor: ", FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsSecondCol, StatsThirdRow), "Damage: ", FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsThirdCol, StatsSecondRow), "Gold: ", FPanelColor, BPanelColor);
            PrintOnPosition(new Position(RogueEngine.ConsoleWidth - hero.Name.Length - 3, StatsSecondRow), hero.Name, FPanelColor, BPanelColor);
            PrintOnPosition(new Position(RogueEngine.ConsoleWidth - hero.Name.Length - 3 + (hero.Name.Length - (hero.ToString().Length + "Lvl   ".Length)) / 2, StatsThirdRow), string.Format("{0} LvL {1}", hero.ToString(), hero.Level.CurrentLevel), FPanelColor, BPanelColor);
            PrintOnPosition(new Position(StatsSixthCol + "Dungeon Level ".Length, StatsFifthRow), "Dungeon Level ", FPanelColor, BPanelColor);
        }
        public static void RenderStats(Hero hero, int boardLevel)
        {
            //PrintOnPosition(0, StatsFirstRow, new string('─', Game.ConsoleWidth), fPanelColor, bPanelColor);
            PrintOnPosition(
                new Position(StatsFirstCol + "HP: ".Length, StatsSecondRow), string.Format("{0} \\ {1}", hero.Health.Current.ToString().PadLeft(hero.Health.Max.ToString().Length, ' '), hero.Health.Max), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFirstCol + "MP: ".Length, StatsThirdRow), string.Format("{0} \\ {1}", hero.Mana.Current.ToString().PadLeft(hero.Mana.Max.ToString().Length, ' '), hero.Mana.Max), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsFirstCol + "XP: ".Length, StatsFourthRow), string.Format("{0} \\ {1}", hero.Level.CurrentXP.ToString().PadLeft(hero.Level.NeededXP.ToString().Length, ' '), hero.Level.NeededXP), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsSecondCol + "Armor: ".Length, StatsSecondRow), string.Format("{0}", hero.Armor.ToString().PadRight(4, ' ')), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsSecondCol + "Damage: ".Length, StatsThirdRow), string.Format("{0}", hero.Weapon.ToString().PadRight(4, ' ')), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsThirdCol + "Gold: ".Length, StatsSecondRow), string.Format("{0}", hero.Gold.ToString().PadRight(9, ' ')), 
                FPanelColor, 
                BPanelColor);
            PrintOnPosition(
                new Position(StatsSixthCol + "Dungeon Level ".Length * 2, StatsFifthRow), string.Format("{0}", boardLevel), 
                FPanelColor, 
                BPanelColor);
            //PrintOnPosition(new Position(83, StatsFourthRow), string.Format("X : {0}, Y : {1}", hero.Position.X.ToString().PadRight(3, ' '), hero.Position.Y.ToString().PadRight(3, ' ')), FPanelColor, BPanelColor);
        }

        public static void RenderMove(Board board, IMovable character, Position newPosition)
        {
            Move move = new Move(character.Position, newPosition);
            character.MoveTo(board, newPosition);
            RenderCharacter((Character)character);
            Console.SetCursorPosition(character.Position.X, character.Position.Y);
            RenderObjectRemoval(move.OldPosition);
        }
        public static void RenderObjectRemoval(Position position)
        {
            PrintOnPosition(position, ' '.ToString(), GlobalConstants.RoomColor.ToConsoleColor(), GlobalConstants.RoomColor.ToConsoleColor());
        }

        public static void PrintOnPosition(Position position, string text, ConsoleColor foregroundColor = FScreenColor, ConsoleColor backgroundColor = BScreenColor)
        {
            if (IsValidPosition(position))
            {
                Console.BackgroundColor = backgroundColor;
                Console.ForegroundColor = foregroundColor;
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write(text);
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
