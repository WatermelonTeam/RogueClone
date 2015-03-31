namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Engine
    {
        // Todo todo todotodotodo .... Just render the heroes,monsters,non player chars and the dungeon ! Much easy much game !

        // Render a stringbuilder or a string array
        public static void RenderDungeon(string[] dungeon)
        {
            throw new NotImplementedException();
        }

        // Just print the hero on the map
        public static void RenderHero(Hero hero)
        {
            PrintOnPosition(hero.Position.X, hero.Position.Y, hero.Icon.ToString());
        }

        public static void RenderMonster(Monsters monster)
        {
            throw new NotImplementedException();
        }

        public static void RenderItem(Item item)
        {
            PrintOnPosition(item.Position.X, item.Position.Y, item.Icon);
        }

        // Render the stats at the bottom of the console
        public static void RenderStats(Hero hero)
        {
            PrintOnPosition(0, Console.WindowHeight - 4, new string('─', Console.WindowWidth));
            PrintOnPosition(3, Console.WindowHeight - 3, string.Format("HP: {0} \\ {1}", hero.Health.Current, hero.Health.Max));
            PrintOnPosition(3, Console.WindowHeight - 2, string.Format("MP: {0} \\ {1}", hero.Mana.Current, hero.Mana.Max));
            PrintOnPosition(25, Console.WindowHeight - 3, string.Format("Level: {0}", hero.Level.CurrentLevel));
            PrintOnPosition(25, Console.WindowHeight - 2, string.Format("XP: {0}", hero.Level.CurrentXP));
            PrintOnPosition(45, Console.WindowHeight - 3, string.Format("Armor: {0}", hero.Armor));
            PrintOnPosition(45, Console.WindowHeight - 2, string.Format("Weapon: {0}", hero.Weapon));
            PrintOnPosition(65, Console.WindowHeight - 3, string.Format("Gold: {0}", hero.Gold));
            PrintOnPosition(85, Console.WindowHeight - 1, string.Format("X : {0}, Y : {1}", hero.Position.X, hero.Position.Y));
        }

        public static void PrintOnPosition(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void PrintOnPosition(int x, int y, string text, ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor foregroundColor = ConsoleColor.Gray)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
