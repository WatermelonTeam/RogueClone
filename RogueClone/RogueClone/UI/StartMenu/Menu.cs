namespace RogueClone.UI.StartMenu
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Menu
    {
        protected const ConsoleColor SelectedOptionColor = ConsoleColor.Green;
        protected const ConsoleColor NormalOptionColor = ConsoleColor.White;
        protected const ConsoleColor LogoColor = ConsoleColor.DarkMagenta;

        private int currentSelectionIndex;

        private IList<string> choiceList;

        public Menu(IList<string> optionList)
        {
            this.choiceList = new List<string>();
            this.choiceList = optionList;
            this.currentSelectionIndex = 0;
        }

        public int CurrentSelectionIndex
        {
            get
            {
                return this.currentSelectionIndex;
            }
            set
            {
                if (value < 0)
                {
                    this.currentSelectionIndex = this.choiceList.Count - 1;
                }
                else if (value > this.choiceList.Count - 1)
                {
                    this.currentSelectionIndex = 0;
                }
                else
                {
                    this.currentSelectionIndex = value;
                }
            }
        }

        public void PrintOnScreen()
        {
            this.Print();
            for (int i = 0; i < this.choiceList.Count; i++ )
            {
                Console.SetCursorPosition(
                    (Console.WindowWidth - this.choiceList[i].Length) / 2,
                    (Console.WindowHeight - this.choiceList.Count) / 2 + 2 * i);

                if (i == this.CurrentSelectionIndex)
                {
                    Console.ForegroundColor = SelectedOptionColor;
                    Console.Write(this.choiceList[i]);
                    Console.ForegroundColor = NormalOptionColor;
                }
                else
                {
                    Console.Write(this.choiceList[i]);
                }
                
            }
        }

        //public Menu HandleMenuInput()
        //{
        //    if (Console.KeyAvailable)
        //    {
        //        ConsoleKeyInfo key = Console.ReadKey(true);

        //        switch (key.Key)
        //        {
        //            case ConsoleKey.UpArrow:
        //                this.CurrentSelectionIndex--;
        //                break;
        //            case ConsoleKey.DownArrow:
        //                this.CurrentSelectionIndex++;
        //                break;
        //            case ConsoleKey.Enter:
        //                return this.ApplyChoice();
        //        }
        //    }
        //    return null;
        //}

        public Menu ApplyChoice()
        {
            Console.Clear();

            switch (this.choiceList[this.currentSelectionIndex])
            {
                case GlobalMenuOptions.StartGame:
                    return new StartGame();

                case GlobalMenuOptions.BackToMainMenu:
                    return new MainMenu();

                case GlobalMenuOptions.Options:
                    return new Options();

                case GlobalMenuOptions.Credits:
                    return new Credits();

                case GlobalMenuOptions.TeamName:
                    return new Team();

                case GlobalMenuOptions.Quit:
                    Environment.Exit(1);
                    break;
                default:
                    return null;
            }
            return null;
        }

        protected virtual void Print()
        {
        }
    }
}
