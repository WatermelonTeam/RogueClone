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
            //Initialise charaters !

            var cords = new Point2D(10, 10);
            var gandalf = new Wizard("Gandalf", 1337, 9999, 10, 3, 127, 500, cords, '@');

            while (true)
            {
                Console.Clear();

                Game.CheckKeyPressingAndSetMovement(gandalf);

                Engine.Engine.RenderHero(gandalf);

                Thread.Sleep(this.Speed);
            }
        }


        // Set the new X and Y of the hero ! Lets hope that this static method is worth ! :D
        public static void SetHeroPosition(Hero hero, int newX, int newY)
        {
            //Save the old position for no reason !
            int heroOldX = hero.PositionX;
            int heroOldY = hero.PositionY;

            //Set the new positions !
            hero.PositionX = newX;
            hero.PositionY = newY;
        }



        // This method checks for key pressing and sets the hero X and Y positions(This should be made by the engine. Must optimize !).
        public static void CheckKeyPressingAndSetMovement(Hero hero)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                //while (Console.KeyAvailable) Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    Game.SetHeroPosition(hero, hero.PositionX += 1, hero.PositionY);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    Game.SetHeroPosition(hero, hero.PositionX -= 1, hero.PositionY);
                }
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    Game.SetHeroPosition(hero, hero.PositionX, hero.PositionY -= 1);
                }
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    Game.SetHeroPosition(hero, hero.PositionX, hero.PositionY += 1);
                }
            }

            //Game.MoveHero(gandalf, 5 + i++, 5);
            Console.Clear();
            Console.WriteLine("X : {0}, Y : {1} - Use the arrow keys to change values !", hero.PositionX, hero.PositionY);
        }

        // Print the player in the dungeon ! This should be in the engine !

    }
}
