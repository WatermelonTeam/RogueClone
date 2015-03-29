namespace RogueClone.Engine
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
            Console.SetCursorPosition(hero.PositionX,hero.PositionY);
            Console.Write(hero.Icon);
        }

        // Render the stats at the bottom of the console
        public static void RenderStats()
        {
            throw new NotImplementedException();
        }
    }
}
