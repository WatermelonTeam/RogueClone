namespace RogueClone.UI.StartMenu
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Credits : Menu
    {
        public Credits()
            : base(new List<string> { 
                GlobalMenuOptions.ReasonForCreation, 
                GlobalMenuOptions.TeamName,
                GlobalMenuOptions.BackToMainMenu})
        {
            this.CurrentSelectionIndex = 2;
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
