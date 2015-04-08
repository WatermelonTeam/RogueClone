using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using RogueClone.UI.StartMenu;

namespace RogueClone
{
    class GameMain
    {
        static void Main(string[] args)
        {
            #region MENU
            Menu mainMenu = new MainMenu();

            while (true)
            {
                mainMenu.PrintOnScreen();
                var menu = mainMenu.HandleMenuInput();
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
                Thread.Sleep(50);
            }
            #endregion

            var game = RogueEngine.Instance; // Dont change the values ! They could be magical !
            game.Start();

            //BoardsTest.Start();
        }
    }
}