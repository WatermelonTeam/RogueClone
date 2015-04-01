using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace RogueClone
{
    

    public sealed class Game : IGame
    {
        public static readonly Game Instance = new Game(100,30);
        public static int ConsoleHeight { get; private set; }
        public static int ConsoleWidth { get; private set; }
        private char steppedOnItem;
        private ConsoleColor itemColor;
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
        public void Start()
        {
            Engine.RenderPanel();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            //Initialise charaters and items on console!

            var gandalf = Wizard.Instance;
            gandalf.Health.Current = 50;
            gandalf.Mana.Current = 70;

            // Just testing an array of items ...
            var items = new List<Item>();
            items.Add(new HealthPotion(new Point2D(20, 20)));
            items.Add(new ManaPotion(new Point2D(25, 23)));
            items.Add(new Gold(new Point2D(30, 15), 91));
            items.Add(new Gold(new Point2D(33, 10), 200));
            items.Add(new Gold(new Point2D(40, 11), 150));
            items.Add(new Trinket("Ring", new Point2D(2,4), 200));
            items.Add(new Trinket("Horseshoe", new Point2D(2, 12), 500));
            items.Add(new Trinket("Crystal", new Point2D(50, 20), 200));
            items.Add(new Trinket("Pendant", new Point2D(40, 5), 200));
            items.Add(new Trinket("Charm", new Point2D(10, 20), 200));
            //items.Add(new HealthPotion("small potion", 10, 0, new Point2D(20, 20), '♥', 100));
            Engine.RenderStats(gandalf);
            Engine.RenderHero(gandalf);
            #region Experimental

            //test the potion


            // var testX = potion.Position.X;

            foreach (var item in items)
            {
                Engine.RenderItem(item);
            }
            bool itemStepped = false;
            int itemDescriptionLength = 0;
            int itemNameLength = 0;
            #endregion
            while (true)
            {
                Game.CheckKeyPressingAndSetMovement(gandalf, this.steppedOnItem, this.itemColor);
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
                        hero.MoveTo(new Point2D(hero.Position.X + 1, hero.Position.Y), steppedOnItem, itemColor); 
                        break;
                    case ConsoleKey.LeftArrow: hero.MoveTo(new Point2D(hero.Position.X - 1, hero.Position.Y), steppedOnItem, itemColor); 
                        break;
                    case ConsoleKey.UpArrow: hero.MoveTo(new Point2D(hero.Position.X, hero.Position.Y - 1), steppedOnItem, itemColor); 
                        break;
                    case ConsoleKey.DownArrow: hero.MoveTo(new Point2D(hero.Position.X, hero.Position.Y + 1), steppedOnItem, itemColor); 
                        break;
                    default:
                        break;
                }
        }
    }
}
