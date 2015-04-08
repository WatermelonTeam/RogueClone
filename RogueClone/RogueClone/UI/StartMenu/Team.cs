namespace RogueClone.UI.StartMenu
{
    using RogueClone.Common;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Team : Menu
    {
        public Team()
            : base(new List<string> { 
                GlobalMenuOptions.BackToMainMenu})
        {
            this.CurrentSelectionIndex = 2;
        }

        protected override void Print()
        {
            using (StreamReader reader = new StreamReader("../../UI/ArtAndText/TeamMembers.txt"))
            {
                Console.ForegroundColor = Color.White.ToConsoleColor();
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
        //protected override void PrintGameLogo()
        //{
        //    using (StreamReader reader = new StreamReader("../../UI/ArtAndText/RogueCloneArt.txt"))
        //    {
        //        Console.ForegroundColor = Menu.LogoColor;
        //        int i = 0;
        //        while (!reader.EndOfStream)
        //        {
        //            Console.SetCursorPosition(Console.WindowWidth / 8, i);
        //            Console.Write(reader.ReadLine());
        //            i++;
        //        }
        //        Console.ForegroundColor = Menu.NormalOptionColor;
        //    }
        //}
    }
}
