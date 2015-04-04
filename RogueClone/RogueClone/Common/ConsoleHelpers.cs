using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueClone.Common
{
    public static class ConsoleHelpers
    {
        public static ConsoleColor ToConsoleColor(this Color color)
        {

            foreach (ConsoleColor consoleColor in Enum.GetValues(typeof(ConsoleColor)))
            {
                if (string.Compare(consoleColor.ToString(), color.ToString(), true) == 0)
                {
                    return consoleColor;
                }
            }
            return ConsoleColor.Black;
        }
    }
}
