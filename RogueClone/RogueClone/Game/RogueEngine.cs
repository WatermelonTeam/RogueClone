using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RogueClone.Common;
using RogueClone;
namespace RogueClone
{
    

    public sealed class RogueEngine : IEngine
    {
        public static readonly RogueEngine Instance = new RogueEngine(130,50);
        public static int ConsoleHeight { get; private set; }
        public static int ConsoleWidth { get; private set; }
        private char steppedOnItem;
        private ConsoleColor itemColor;
        private RogueEngine(int width, int height)
        {
            Console.CursorVisible = false;
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
            BoardFactory factory = new BoardFactory(new Position(0 + 10, 0 + 2), new Position(80 - 1, 25 - 1));
            Board board = factory.GenerateBoard();
            ConsoleRenderer.RenderDungeon(board);

            ConsoleRenderer.RenderPanel();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            //Initialise charaters and items on console!

            var gandalf = Rogue.Instance;
            gandalf.Position = new Position(board.EntryStairPos.X, board.EntryStairPos.Y + 1);
            gandalf.Health.Current = 50;
            gandalf.Mana.Current = 70;

            // Just testing an array of items ...
            //var items = new List<Item>();
            //items.Add(new HealthPotion(new Position(20, 20)));
            //items.Add(new ManaPotion(new Position(25, 23)));
            //items.Add(new Gold(new Position(30, 15), 91));
            //items.Add(new Gold(new Position(33, 10), 200));
            //items.Add(new Gold(new Position(40, 11), 150));
            //items.Add(new Trinket("Ring", new Position(2,4), 200));
            //items.Add(new Trinket("Horseshoe", new Position(2, 12), 500));
            //items.Add(new Trinket("Crystal", new Position(50, 20), 200));
            //items.Add(new Trinket("Pendant", new Position(40, 5), 200));
            //items.Add(new Trinket("Charm", new Position(10, 20), 200));
            //items.Add(new RogueArmor(new Position(20, 21), 2));
            //items.Add(new WizardArmor(new Position(30, 13), 2));
            //items.Add(new RogueWeapon(new Position(50, 21), 2));
            //items.Add(new RogueWeapon(new Position(50, 22), 3));
            //items.Add(new RogueWeapon(new Position(50, 23), 4));
            //items.Add(new WizardWeapon(new Position(20, 22), 2));
            //items.Add(new HealthPotion("small potion", 10, 0, new Point2D(20, 20), '♥', 100));

            foreach (var item in board.Items)
            {
                ConsoleRenderer.RenderItem(item);
            }
            ConsoleRenderer.RenderStats(gandalf);
            ConsoleRenderer.RenderHero(gandalf);
            #region Experimental

            //test the potion


            // var testX = potion.Position.X;

            bool itemStepped = true;
            int itemDescriptionLength = 0;
            int itemNameLength = 0;
            #endregion
            while (true)
            {
                RogueEngine.CheckKeyPressingAndSetMovement(board, gandalf);
                if (itemStepped)
                {
                    foreach (var item in board.Items)
                    {
                        ConsoleRenderer.RenderItem(item);
                    }

                    ConsoleRenderer.RemoveItemDescription(itemNameLength, itemDescriptionLength);
                    itemStepped = false;
                }

                // GameEngine is alias to ConsoleRenderer.Engine just check the usings              
                ConsoleRenderer.RenderStats(gandalf);
                //Always render the hero at the end so he can be on top on all the items and monsters !
                ConsoleRenderer.RenderHero(gandalf);
                foreach (var item in board.Items)
                {
                    if (gandalf.Position == item.Position)
                    {
                        ConsoleRenderer.RenderItemDescription(item);
                        itemDescriptionLength = item.Description.Length;
                        itemNameLength = item.Name.Length;
                        itemStepped = true;
                        this.steppedOnItem = (char)item.Icon;
                        this.itemColor = item.ItemColor.ToConsoleColor();
                        if (item is IConsumable && gandalf.Level.CurrentLevel >= item.NeededLvl)
                        {
                            gandalf.UseConsumable(item);
                            board.Items.Remove(item);
                            ConsoleRenderer.RenderObjectRemoval(item.Position, gandalf);
                            break;
                        }
                        if (item is Gold)
                        {
                            gandalf.TakeGold(item);
                            board.Items.Remove(item);
                            ConsoleRenderer.RenderObjectRemoval(item.Position, gandalf);
                            break;
                        }
                        if (item is Trinket && gandalf.Level.CurrentLevel >= item.NeededLvl)
                        {
                            gandalf.TakeTrinket(item);
                            board.Items.Remove(item);
                            ConsoleRenderer.RenderObjectRemoval(item.Position, gandalf);
                            break;
                        }
						//i made gandalf rouge to try if he can pick armors
						//TODO: have to implement how to do the dodge and durability stuff
						if(item is RogueArmor && gandalf is Rogue && gandalf.Level.CurrentLevel>= item.NeededLvl)
						{
							gandalf.TakeRogueArmor(item);
							board.Items.Remove(item);
                            ConsoleRenderer.RenderObjectRemoval(item.Position, gandalf);
							break;
						}
						
						//trying to pick rogue weapons(working) :D
						if(item is RogueWeapon && gandalf is Rogue && gandalf.Level.CurrentLevel>=item.NeededLvl)
						{
							
							gandalf.TakeRogueWeapon(item);
							board.Items.Remove(item);
                            ConsoleRenderer.RenderObjectRemoval(item.Position, gandalf);
							break;
						}
						//trying if gandalf is wizard :)

						//if (item is WizardWeapon && gandalf is Wizard && gandalf.Level.CurrentLevel >= item.NeededLvl)
						//{
						//
						//	gandalf.TakeWizardWeapon(item);
						//	items.Remove(item);
						//	this.steppedOnItem = ' ';
						//	this.itemColor = ConsoleColor.White;
						//	break;
						//}

						//tell me what shall i implement for the wizard armor ...please "ArmorSpell" WTF ?! :D
						//if(item is WizardArmor && gandalf is Wizard && gandalf.Level.CurrentLevel>=item.NeededLvl)
						//{
						//	gandalf.TakeWizardArmor(item);
						//	items.Remove(item);
						//	this.steppedOnItem = ' ';
						//	this.itemColor = ConsoleColor.White;
						//	break;
						//}
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



        // This method checks for key pressing and sets the hero X and Y positions(This should be made by the ConsoleRenderer. Must optimize !).
        private static void CheckKeyPressingAndSetMovement(Board board, Hero hero)
        {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        ConsoleRenderer.RenderMove(board, hero, new Position(hero.Position.X + 1, hero.Position.Y));
                        break;
                    case ConsoleKey.LeftArrow:
                        ConsoleRenderer.RenderMove(board, hero, new Position(hero.Position.X - 1, hero.Position.Y));
                        break;
                    case ConsoleKey.UpArrow:
                        ConsoleRenderer.RenderMove(board, hero, new Position(hero.Position.X, hero.Position.Y - 1));
                        break;
                    case ConsoleKey.DownArrow:
                        ConsoleRenderer.RenderMove(board, hero, new Position(hero.Position.X, hero.Position.Y + 1));
                        break;
                    default:
                        break;
                }
        }
    }
}
