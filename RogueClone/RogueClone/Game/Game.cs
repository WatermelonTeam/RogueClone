using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace RogueClone
{


    public sealed class Game : IGame
    {
        public static readonly Game Instance = new Game(100, 30);
        public static int ConsoleHeight { get; private set; }
        public static int ConsoleWidth { get; private set; }
        private char steppedOnItem;
        private ConsoleColor itemColor;

        public bool IsPaused { get; private set; }

        private Game(int width, int height)
        {
            ConsoleWidth = width;
            ConsoleHeight = height;
            // Set the console size and speed
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.SetBufferSize(ConsoleWidth, ConsoleHeight);
        }

        /// <summary>
        /// Main game logic goes here ? Am I doing this right ? :D WE NEED AN ENGINE !
        /// </summary>
        /// 
        private List<Item> items;

        public void Start()
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            //Initialise charaters and items on console!

            var gandalf = Wizard.Instance;
            gandalf.Health.Current = 50;
            gandalf.Mana.Current = 70;

            // Just testing an array of items ...
            items = new List<Item>();
            this.items.Add(new HealthPotion(new Point2D(20, 20)));
            this.items.Add(new ManaPotion(new Point2D(25, 23)));
            this.items.Add(new Gold(new Point2D(30, 15), 91));
            this.items.Add(new Gold(new Point2D(33, 10), 200));
            this.items.Add(new Gold(new Point2D(40, 11), 150));
            this.items.Add(new Trinket("Ring", new Point2D(2, 4), 200));
            this.items.Add(new Trinket("Horseshoe", new Point2D(2, 12), 500));
            this.items.Add(new Trinket("Crystal", new Point2D(50, 20), 200));
            this.items.Add(new Trinket("Pendant", new Point2D(40, 5), 200));
            this.items.Add(new Trinket("Charm", new Point2D(10, 20), 200));
            //items.Add(new HealthPotion("small potion", 10, 0, new Point2D(20, 20), '♥', 100));



            #region Render

            Engine.RenderPanel();
            Engine.RenderStats(gandalf);
            Engine.RenderHero(gandalf);

            Engine.RenderItems(items);


            #endregion

            bool itemStepped = false;
            int itemDescriptionLength = 0;
            int itemNameLength = 0;

            while (true)
            {

                Game.CheckKeyPressingAndSetMovement(gandalf, this.steppedOnItem, this.itemColor);

                if (!IsPaused)
                {
                    this.steppedOnItem = ' ';
                    if (itemStepped)
                    {
                        Engine.RemoveItemDescription(itemNameLength, itemDescriptionLength);
                        itemStepped = false;
                    }

                    // GameEngine is alias to Engine.Engine just check the usings              
                    Engine.RenderStats(gandalf);
                    //Always render the hero at the end so he can be on top on all the items and monsters !
                    Engine.RenderHero(gandalf);
                    foreach (var item in items)
                    {
                        if (gandalf.Position == item.Position)
                        {
                            Engine.RenderItemDescription(item);
                            itemDescriptionLength = item.Description.Length;
                            itemNameLength = item.Name.Length;
                            itemStepped = true;
                            this.steppedOnItem = item.Icon;
                            this.itemColor = item.Color;
                            if (item is IConsumable && gandalf.Level.CurrentLevel >= item.NeededLvl)
                            {
                                gandalf.UseConsumable(item);
                                items.Remove(item);
                                this.steppedOnItem = ' ';
                                this.itemColor = ConsoleColor.White;
                                break;
                            }
                            if (item is Gold)
                            {
                                gandalf.TakeGold(item);
                                items.Remove(item);
                                this.steppedOnItem = ' ';
                                this.itemColor = ConsoleColor.White;
                                break;
                            }
                            if (item is Trinket && gandalf.Level.CurrentLevel >= item.NeededLvl)
                            {
                                gandalf.TakeTrinket(item);
                                items.Remove(item);
                                this.steppedOnItem = ' ';
                                this.itemColor = ConsoleColor.White;
                                break;
                            }
                        }

                        /*
                        Implement later :   
                    
                        if weapon
                        if trinket
                        if armor
                      
                        */
                    }
                }
                else
                {

                }

            }
        }
        public void Pause()
        {
            if (this.IsPaused == true)
            {
                //Console.Clear();

                this.IsPaused = false;

                //Re-render 
                Engine.RenderStats(Wizard.Instance);
                Engine.RenderPanel();
                Engine.RenderItems(this.items);
                //Instance.Start();
            }
            else
            {
                //Simple window
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                WritePauseBackgroundAndSettings();

                ConsoleKeyInfo pressedKey = Console.ReadKey(true);


                int x = 8;
                int y = 40;

                bool done = true;
                while (done)
                {
                    switch (pressedKey.Key)
                    {

                        case ConsoleKey.UpArrow:
                            WritePauseBackgroundAndSettings();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            if (!(x <= 8))
                            {
                                x -= 1;
                            }
                            Console.SetCursorPosition(y, x);
                            Console.Write("->");
                            break;
                        case ConsoleKey.DownArrow:
                            WritePauseBackgroundAndSettings();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            if (!(x >= 19))
                            {
                                x += 1;
                            }
                            Console.SetCursorPosition(y, x);
                            Console.Write("->");
                            break;
                        case ConsoleKey.Escape:
                            done = false;
                            break;
                    }
                    Console.SetCursorPosition(y + 18, 5);
                    Console.Write(x - 5);
                    Console.SetCursorPosition(y + 3, 20);
                    Console.Write("Spam Esc to exit!");

                    pressedKey = Console.ReadKey(true);
                }

                //Console.WriteLine(done);
                this.IsPaused = true;
            }

        }

        private static void WritePauseBackgroundAndSettings()
        {
            var settings = new List<string>();
            int startPosition = Console.WindowWidth / 2 - 10;
            settings.Add("Save");
            settings.Add("Inventory");
            settings.Add("Pokemons");
            settings.Add("Spells");
            settings.Add("Please");
            settings.Add("Insert");
            settings.Add("Sample");
            settings.Add("Text");
            settings.Add("Here");
            settings.Add("Save and Exit");
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 5; i <= 20; i++)
            {
                Console.SetCursorPosition(startPosition, i);
                Console.Write(new string(' ', 20));
            }
            int counter = 8;
            Console.SetCursorPosition(startPosition + 3, 6);
            Console.Write("Game paused !");
            foreach (var item in settings)
            {
                Console.SetCursorPosition(startPosition + 3, counter);
                counter++;
                Console.Write(item);
            }
        }


        // Set the new X and Y of the hero ! Lets hope that this static method is worth ! :D
        //public static void SetHeroPosition(Hero hero, int newX, int newY)
        //{
        //    //Save the old position for no reason !
        //    int heroOldX = hero.PositionX;
        //    int heroOldY = hero.PositionY;

        //    //Set the new positions !
        //    hero.PositionX = newX;
        //    hero.PositionY = newY;
        //}



        // This method checks for key pressing and sets the hero X and Y positions(This should be made by the engine. Must optimize !).
        private static void CheckKeyPressingAndSetMovement(Hero hero, char steppedOnItem, ConsoleColor itemColor)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            switch (pressedKey.Key)
            {

                case ConsoleKey.RightArrow:
                    //Checking for paused is required because the hero will disappear
                    if (!Instance.IsPaused) { hero.MoveTo(new Point2D(hero.Position.X + 1, hero.Position.Y), steppedOnItem, itemColor); }
                    break;
                case ConsoleKey.LeftArrow:
                    if (!Instance.IsPaused) { hero.MoveTo(new Point2D(hero.Position.X - 1, hero.Position.Y), steppedOnItem, itemColor); }
                    break;
                case ConsoleKey.UpArrow:
                    if (!Instance.IsPaused) { hero.MoveTo(new Point2D(hero.Position.X, hero.Position.Y - 1), steppedOnItem, itemColor); }
                    break;
                case ConsoleKey.DownArrow:
                    if (!Instance.IsPaused) { hero.MoveTo(new Point2D(hero.Position.X, hero.Position.Y + 1), steppedOnItem, itemColor); }
                    break;
                case ConsoleKey.Escape:

                    Instance.Pause();

                    break;
                default:
                    break;
            }
        }
    }
}
