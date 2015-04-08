using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using RogueClone.UI.StartMenu;
using RogueClone.InputProviders;

namespace RogueClone
{
    class GameMain
    {
        private static ConsoleInputProvider inputProvider = new ConsoleInputProvider();
        static void Main(string[] args)
        {
            #region MENU
            Menu mainMenu = new MainMenu();

            while (true)
            {
                mainMenu.PrintOnScreen();
                var menu = inputProvider.HandleMenuInput(mainMenu);
                if (menu != null)
                {
                    if (menu is StartGame)
                    {
                        menu.PrintOnScreen();
                        Thread.Sleep(1000);
                        break;
                    }
                    mainMenu = menu;
                }
            }
            #endregion

            var game = RogueEngine.Instance; // Dont change the values ! They could be magical !
            game.Start();

            //BoardsTest.Start();
        }
    }
}