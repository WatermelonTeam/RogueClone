namespace RogueClone.UI.StartMenu
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class MainMenu : Menu
    {
        public MainMenu()
            : base(new List<string> { 
                GlobalMenuOptions.StartGame, 
                GlobalMenuOptions.Options, 
                GlobalMenuOptions.Credits, 
                GlobalMenuOptions.Quit })
        {
        }

        protected override void PrintGameLogo()
        {
            using (StreamReader reader = new StreamReader("../../UI/Art/RogueCloneArt.txt"))
            {
                Console.ForegroundColor = Menu.LogoColor;
                int i = 0;
                while (!reader.EndOfStream)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 8, i);
                    Console.Write(reader.ReadLine());
                    i++;
                }
                Console.ForegroundColor = Menu.NormalOptionColor;
            }
        }
    }
}
