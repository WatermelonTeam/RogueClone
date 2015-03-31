namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class Game : IGame
    {
        int gameSpeed;
        public Game(int width, int height, int speed)
        {
            // Set the console size and speed
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            // Set the speed
            this.Speed = speed;
        }


        public int Speed
        {
            get
            {
                return this.gameSpeed;
            }

            set
            {
                this.gameSpeed = value;
            }
        }

        /// <summary>
        /// Main game logic goes here ? Am I doing this right ? :D WE NEED AN ENGINE !
        /// </summary>
        public void Start()
        {
            Console.CursorVisible = false;
            //Initialise charaters and items on console!

            var gandalf = new Wizard("Gandalf", new Health(100), new Mana(200), new Level(1), 9999, 10, 0, new Point2D(10, 10), '☺');


            // Just testing an array of items ...
            var items = new List<Item>();
            items.Add(new Potion("small potion", 10, 0, new Point2D(20, 20), "+", 100));
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
                //Console.Clear();

                Game.CheckKeyPressingAndSetMovement(gandalf);

                // GameEngine is alias to Engine.Engine just check the usings              
                Engine.RenderStats(gandalf);
                //Always render the hero at the end so he can be on top on all the items and monsters !
                Engine.RenderHero(gandalf);
                foreach (var item in items)
                {
                    if (item is Potion)
                    {
                        gandalf.UseConsumable(items[0]);
                    }

                    /*
                    Implement later :   
                    
                    if weapon
                    if trinket
                    if armor
                      
                    */
                }
                

                //Thread.Sleep(this.Speed);

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
        private static void CheckKeyPressingAndSetMovement(Hero hero)
        {
            //while (Console.KeyAvailable)
            //{
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                //while (Console.KeyAvailable) Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    //if (hero.PositionX >= Console.WindowWidth - 1) { break; }
                    hero.MoveTo(new Point2D(hero.Position.X + 1, hero.Position.Y));
                    //hero.MoveTo(hero.Position.X += 1, hero.Position.Y);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    //if (hero.PositionX <= 0) { break; }
                    hero.MoveTo(new Point2D(hero.Position.X - 1, hero.Position.Y));
                    //Game.SetHeroPosition(hero, hero.Position.X -= 1, hero.Position.Y);
                }
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    //if (hero.PositionY <= 0) { break; }
                    hero.MoveTo(new Point2D(hero.Position.X, hero.Position.Y - 1));
                    //Game.SetHeroPosition(hero, hero.Position.X, hero.Position.Y -= 1);
                }
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    //if (hero.PositionY >= Console.WindowHeight - 5) { break; }
                    hero.MoveTo(new Point2D(hero.Position.X, hero.Position.Y + 1));
                    //Game.SetHeroPosition(hero, hero.Position.X, hero.Position.Y += 1);
                }
            //}

            //Console.Clear();
        }
    }
}
