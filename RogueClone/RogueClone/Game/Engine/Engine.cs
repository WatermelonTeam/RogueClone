namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Engine
    {
        public const int statsPanelHeight = 4;
        public const ConsoleColor bScreenColor = ConsoleColor.DarkBlue;
        public const ConsoleColor fScreenColor = ConsoleColor.White;
        public const ConsoleColor bPanelColor = ConsoleColor.Blue;
        public const ConsoleColor fPanelColor = ConsoleColor.White;
        public const ConsoleColor herolColor = ConsoleColor.White;
        private static int statsFirstRow = Game.ConsoleHeight - statsPanelHeight;
        private static int statsSecondRow = statsFirstRow + 1;
        private static int statsThirdRow = statsSecondRow + 1;
        private static int statsFourthRow = statsThirdRow + 1;
        private static int statsFirstCol = 3;
        private static int statsSecondCol = 22;
        private static int statsThirdCol = 36;
        private static int statsFourthCol = 55;
        private static int statsFifthCol = 75;


        // Todo todo todotodotodo .... Just render the heroes,monsters,non player chars and the dungeon ! Much easy much game !

        // Render a stringbuilder or a string array
        public static void RenderDungeon(string[] dungeon)
        {
            throw new NotImplementedException();
        }

        // Just print the hero on the map
        public static void RenderHero(Hero hero)
        {
            PrintOnPosition(hero.Position.X, hero.Position.Y, hero.Icon.ToString(), herolColor);
        }

        public static void RenderMonster(Monster monster)
        {
            throw new NotImplementedException();
        }

        public static void RenderItem(Item item)
        {
            PrintOnPosition(item.Position.X, item.Position.Y, item.Icon.ToString(), item.Color);
        }
        public static void RenderItemDescription(Item item)
        {
            PrintOnPosition(
                statsFifthCol, 
                statsFirstRow, 
                string.Format("◄ {0} ►", item.Name), 
                fPanelColor, 
                bPanelColor);
            PrintOnPosition(
                statsFifthCol + (string.Format("◄ {0} ►", item.Name).Length - string.Format("(LvL {0})", item.NeededLvl).Length) / 2,
                statsSecondRow,
                string.Format("(LvL {0})",
                item.NeededLvl), 
                fPanelColor, 
                bPanelColor);
            PrintOnPosition(
                statsFifthCol + (string.Format("◄ {0} ►", item.Name).Length - item.Description.Length) / 2,
                statsThirdRow, 
                item.Description, 
                fPanelColor, 
                bPanelColor);
        }
        public static void RemoveItemDescription(int nameLength, int descriptionLength)
        {
            PrintOnPosition(
                statsFourthCol + "Gold: 123456789".Length, 
                statsFirstRow,
                "".PadRight(Game.ConsoleWidth - statsFourthCol + "Gold: 123456789".Length, ' '), 
                fPanelColor, 
                bPanelColor);
            PrintOnPosition(
                statsFourthCol + "Gold: 123456789".Length,  
                statsSecondRow,
                "".PadRight(Game.ConsoleWidth - statsFourthCol + "Gold: 123456789".Length, ' '), 
                fPanelColor, 
                bPanelColor);
            PrintOnPosition(
                statsFourthCol + "Gold: 123456789".Length,  
                statsThirdRow,
                "".PadRight(Game.ConsoleWidth - statsFourthCol + "Gold: 123456789".Length, ' '), 
                fPanelColor, 
                bPanelColor);
        }

        // Render the stats at the bottom of the console

        public static void RenderPanel()
        {
            Console.BackgroundColor = bScreenColor;
            Console.ForegroundColor = fScreenColor;
            Console.Clear();
            Console.BackgroundColor = bPanelColor;
            Console.ForegroundColor = fPanelColor;

            for (int i = 1; i <= Engine.statsPanelHeight; i++)
            {
                Console.SetCursorPosition(0, Game.ConsoleHeight - i);
                Console.WriteLine("".PadRight(Game.ConsoleWidth, ' '));
            }
            Console.BackgroundColor = bScreenColor;
            Console.ForegroundColor = fScreenColor;

        }
        public static void RenderStats(Hero hero)
        {
            //PrintOnPosition(0, statsFirstRow, new string('─', Game.ConsoleWidth), fPanelColor, bPanelColor);
            PrintOnPosition(statsFirstCol, statsSecondRow, string.Format("HP: {0} \\ {1}", hero.Health.Current.ToString().PadLeft(hero.Health.Max.ToString().Length, ' '), hero.Health.Max), fPanelColor, bPanelColor);
            PrintOnPosition(statsFirstCol, statsThirdRow, string.Format("MP: {0} \\ {1}", hero.Mana.Current.ToString().PadLeft(hero.Mana.Max.ToString().Length, ' '), hero.Mana.Max), fPanelColor, bPanelColor);
            PrintOnPosition(statsSecondCol, statsSecondRow, string.Format("Level: {0}", hero.Level.CurrentLevel.ToString().PadRight(3, ' ')), fPanelColor, bPanelColor);
            PrintOnPosition(statsSecondCol, statsThirdRow, string.Format("XP: {0}", hero.Level.CurrentXP.ToString().PadRight(7, ' ')), fPanelColor, bPanelColor);
            PrintOnPosition(statsThirdCol, statsSecondRow, string.Format("Armor: {0}", hero.Armor.ToString().PadRight(4, ' ')), fPanelColor, bPanelColor);
            PrintOnPosition(statsThirdCol, statsThirdRow, string.Format("Weapon: {0}", hero.Weapon.ToString().PadRight(4, ' ')), fPanelColor, bPanelColor);
            PrintOnPosition(statsFourthCol, statsSecondRow, string.Format("Gold: {0}", hero.Gold.ToString().PadRight(9, ' ')), fPanelColor, bPanelColor);
            PrintOnPosition(83, statsFourthRow, string.Format("X : {0}, Y : {1}", hero.Position.X.ToString().PadRight(3, ' '), hero.Position.Y.ToString().PadRight(3, ' ')), fPanelColor, bPanelColor);

        }
        public static void PrintOnPosition(int x, int y, string text, ConsoleColor foregroundColor = fScreenColor, ConsoleColor backgroundColor = bScreenColor)
        {
            if (IsValidPosition(new Point2D(x, y)))
            {
                var oldForegroundColor = Console.ForegroundColor;
                var oldBackgroundColor = Console.BackgroundColor;
                Console.BackgroundColor = backgroundColor;
                Console.ForegroundColor = foregroundColor;
                Console.SetCursorPosition(x, y);
                Console.Write(text);
                Console.BackgroundColor = oldForegroundColor;
                Console.ForegroundColor = oldBackgroundColor;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format("Position ({0},{1}) is out of the valid range [{2},{3})", x, y, Game.ConsoleWidth, Game.ConsoleHeight));
            }
            
        }
        private static bool IsValidPosition(Point2D position)
        {
            return 0 <= position.X
                && 0 <= position.Y
                && position.X < Game.ConsoleWidth
                && position.Y < Game.ConsoleHeight;
        }
    }
}
