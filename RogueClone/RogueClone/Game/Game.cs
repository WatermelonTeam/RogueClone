using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace RogueClone
{
    

    public class Game : IGame
    {
        public static int ConsoleHeight { get; private set; }
        public static int ConsoleWidth { get; private set; }
        private char steppedOnItem;
        private ConsoleColor itemColor;
        public Game(int width, int height)
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
            Console.CursorVisible = false;
            //Initialise charaters and items on console!

            var gandalf = new Wizard("Gandalf", new Health(100), new Mana(200), new Level(3), 9999, 10, 0, new Point2D(10, 10), '☻');
            gandalf.Health.Current = 50;
            gandalf.Mana.Current = 70;

            // Just testing an array of items ...
            var items = new List<Item>();
            items.Add(new HealthPotion(new Point2D(20, 20)));
            items.Add(new ManaPotion(new Point2D(25, 23)));
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
            #endregion
            while (true)
            {
                Game.CheckKeyPressingAndSetMovement(gandalf, this.steppedOnItem, this.itemColor);
                this.steppedOnItem = ' ';
                this.itemColor = ConsoleColor.White;

                // GameEngine is alias to Engine.Engine just check the usings              
                Engine.RenderStats(gandalf);
                //Always render the hero at the end so he can be on top on all the items and monsters !
                Engine.RenderHero(gandalf);
                foreach (var item in items)
                {
                    if (gandalf.Position == item.Position)
                    {
                        this.steppedOnItem = item.Icon;
                        this.itemColor = item.Color;
                        if (item is IConsumable && gandalf.Level.CurrentLevel >= item.NeededLvl)
                        {
                            gandalf.UseConsumable(item);
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
