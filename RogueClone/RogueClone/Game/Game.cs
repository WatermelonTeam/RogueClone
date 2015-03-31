﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace RogueClone
{
    

    public class Game : IGame
    {
        private Point2D initialHeroPosition;
        int gameSpeed;        
        public Point2D InitialHeroPoisition
        {
            get
            {
                return this.initialHeroPosition;
            }

            set // validate
            {
                if (value.X < 0 || value.Y < 0 || ConsoleWidth <= value.X || ConsoleHeight <= value.Y)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The initial position was ({0},{1}). Valid range is ([{2},{3}),[{2},{4}))", value.X, value.Y, 0, ConsoleWidth, ConsoleHeight));
                }
                this.initialHeroPosition = value;
            }
        }

        public static int ConsoleHeight { get; private set; }
        public static int ConsoleWidth { get; private set; }
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
        public Game(int width, int height, int speed, Point2D initialHeroPosition)
        {
            ConsoleWidth = width;
            ConsoleHeight = height;
            // Set the console size and speed
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.SetBufferSize(ConsoleWidth, ConsoleHeight);


            // Set the speed
            this.Speed = speed;
            this.InitialHeroPoisition = initialHeroPosition;
        }

        /// <summary>
        /// Main game logic goes here ? Am I doing this right ? :D WE NEED AN ENGINE !
        /// </summary>
        public void Start()
        {
            Console.CursorVisible = false;
            //Initialise charaters and items on console!

            var gandalf = new Wizard("Gandalf", new Health(100), new Mana(200), new Level(1), 9999, 10, 0, this.InitialHeroPoisition, '☺');
            gandalf.Health.Current = 50;

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
                    if (gandalf.Position == item.Position && item is Potion)
                    {
                        gandalf.UseConsumable(item);
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
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        hero.MoveTo(new Point2D(hero.Position.X + 1, hero.Position.Y)); 
                        break;
                    case ConsoleKey.LeftArrow: hero.MoveTo(new Point2D(hero.Position.X - 1, hero.Position.Y)); 
                        break;
                    case ConsoleKey.UpArrow: hero.MoveTo(new Point2D(hero.Position.X, hero.Position.Y - 1)); 
                        break;
                    case ConsoleKey.DownArrow: hero.MoveTo(new Point2D(hero.Position.X, hero.Position.Y + 1)); 
                        break;
                    default:
                        break;
                }

            //Console.Clear();
        }
    }
}
