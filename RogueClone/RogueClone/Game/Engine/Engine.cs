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
        private static int statsFirstRow = Game.ConsoleHeight - statsPanelHeight;
        private static int statsSecondRow = statsFirstRow + 1;
        private static int statsThirdRow = statsSecondRow + 1;
        private static int statsFourthRow = statsThirdRow + 1;

        // Todo todo todotodotodo .... Just render the heroes,monsters,non player chars and the dungeon ! Much easy much game !

        // Render a stringbuilder or a string array
        public static void RenderDungeon(string[] dungeon)
        {
            throw new NotImplementedException();
        }

        // Just print the hero on the map
        public static void RenderHero(Hero hero)
        {
            PrintOnPosition(hero.Position.X, hero.Position.Y, hero.Icon.ToString(), ConsoleColor.Yellow);
        }

        public static void RenderMonster(Monster monster)
        {
            throw new NotImplementedException();
        }

        public static void RenderItem(Item item)
        {
            PrintOnPosition(item.Position.X, item.Position.Y, item.Icon.ToString(), item.Color);
        }

        // Render the stats at the bottom of the console


        public static void RenderStats(Hero hero)
        {
            PrintOnPosition(0, statsFirstRow, new string('─', Game.ConsoleWidth));
            PrintOnPosition(3, statsSecondRow, string.Format("HP: {0} \\ {1}", hero.Health.Current.ToString().PadLeft(hero.Health.Max.ToString().Length, ' '), hero.Health.Max));
            PrintOnPosition(3, statsThirdRow, string.Format("MP: {0} \\ {1}", hero.Mana.Current.ToString().PadLeft(hero.Mana.Max.ToString().Length, ' '), hero.Mana.Max));
            PrintOnPosition(25, statsSecondRow, string.Format("Level: {0}", hero.Level.CurrentLevel.ToString().PadRight(3, ' ')));
            PrintOnPosition(25, statsThirdRow, string.Format("XP: {0}", hero.Level.CurrentXP.ToString().PadRight(7, ' ')));
            PrintOnPosition(45, statsSecondRow, string.Format("Armor: {0}", hero.Armor.ToString().PadRight(4, ' ')));
            PrintOnPosition(45, statsThirdRow, string.Format("Weapon: {0}", hero.Weapon.ToString().PadRight(4, ' ')));
            PrintOnPosition(65, statsSecondRow, string.Format("Gold: {0}", hero.Gold.ToString().PadRight(9, ' ')));
            PrintOnPosition(83, statsFourthRow, string.Format("X : {0}, Y : {1}", hero.Position.X.ToString().PadRight(3, ' '), hero.Position.Y.ToString().PadRight(3, ' ')));
        }
        public static void PrintOnPosition(int x, int y, string text, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
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
    }
}
