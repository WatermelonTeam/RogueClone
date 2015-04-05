using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RogueClone.Common;
using RogueClone;
using RogueClone.InputProviders;
namespace RogueClone
{
    

    public sealed class RogueEngine : IEngine
    {
        private readonly ConsoleInputProvider input;

        public static readonly RogueEngine Instance = new RogueEngine(130,50, new ConsoleInputProvider());
        public static int ConsoleHeight { get; private set; }
        public static int ConsoleWidth { get; private set; }
        private char steppedOnItem;
        private ConsoleColor itemColor;
        private RogueEngine(int width, int height, ConsoleInputProvider inputProvider)
        {
            this.input = inputProvider;
            Console.CursorVisible = false;
            ConsoleWidth = width;
            ConsoleHeight = height;
            // Set the console size and speed
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.SetBufferSize(ConsoleWidth, ConsoleHeight);
        }
        private int PlayBoard(Board board, List<Board> boards, Hero hero, int boardLevel)
        {
            bool itemStepped = true;
            bool stairsSteppedOn = true;
            bool isNExtToCharacter = false;
            int itemDescriptionLength = 0;
            int itemNameLength = 0;
            while (true)
            {
                input.SetMovement(board, hero);
                if (hero.Position == board.EntryStairPos && boardLevel > 0)
                {
                    if (boardLevel == boards.Count)
                    {
                        boards.Add(board);
                    }
                    else if (true)
                    {
                        boards[boardLevel] = board;
                    }
                    return -1;
                }
                if (hero.Position == board.ExitStairPos)
                {
                    if (boardLevel == boards.Count)
                    {
                        boards.Add(board);
                    }
                    else if (true)
                    {
                        boards[boardLevel] = board;
                    }
                    return 1;
                }
                if (stairsSteppedOn)
                {
                    ConsoleRenderer.RenderStairs(board);
                    stairsSteppedOn = false;
                }
                if (hero.Position == board.EntryStairPos || hero.Position == board.ExitStairPos)
                {
                    stairsSteppedOn = true;
                }
                if (itemStepped)
                {
                    ConsoleRenderer.RenderAllItems(board.Items);
                    ConsoleRenderer.RemoveDescription(itemNameLength, itemDescriptionLength);
                    itemStepped = false;
                }
                if (isNExtToCharacter)
                {
                    ConsoleRenderer.RenderAllItems(board.Items);
                    ConsoleRenderer.RemoveDescription(itemNameLength, itemDescriptionLength);
                    itemStepped = false;
                }
                // GameEngine is alias to ConsoleRenderer.Engine just check the usings              
                ConsoleRenderer.RenderStats(hero, boardLevel);
                //Always render the hero at the end so he can be on top on all the items and monsters !
                ConsoleRenderer.RenderCharacter(hero);
                foreach (var item in board.Items)
                {
                    if (hero.Position == item.Position)
                    {
                        ConsoleRenderer.RenderItemDescription(item);
                        itemDescriptionLength = item.Description.Length;
                        itemNameLength = item.Name.Length;
                        itemStepped = true;
                        this.steppedOnItem = (char)item.Icon;
                        this.itemColor = item.ItemColor.ToConsoleColor();
                        if (item is IConsumable && hero.Level.CurrentLevel >= item.NeededLvl)
                        {
                            hero.UseConsumable(item);
                            RemoveItemFromBoard(item, board);
                            break;
                        }
                        if (item is Gold)
                        {
                            hero.TakeGold(item);
                            RemoveItemFromBoard(item, board);
                            break;
                        }
                        if (item is Trinket && hero.Level.CurrentLevel >= item.NeededLvl)
                        {
                            hero.TakeTrinket(item);
                            RemoveItemFromBoard(item, board);
                            break;
                        }
						//i made gandalf rouge to try if he can pick armors
						//TODO: have to implement how to do the dodge and durability stuff
                        if (item is RogueArmor && hero is Rogue && hero.Level.CurrentLevel >= item.NeededLvl)
						{
                            hero.TakeRogueArmor(item);
                            RemoveItemFromBoard(item, board);
							break;
						}
						
						//trying to pick rogue weapons(working) :D
                        if (item is RogueWeapon && hero is Rogue && hero.Level.CurrentLevel >= item.NeededLvl)
						{

                            hero.TakeRogueWeapon(item);
                            RemoveItemFromBoard(item, board);
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
                    if (hero.Position.Distance(board.ShopKeeperPos) < 1.5)
                    {
                        ConsoleRenderer.RenderCharacterDescription(new ShopKeeper("Eeldo Tayn", board.ShopKeeperPos, 100, board.Items));
                        isNExtToCharacter = true;
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

        private static void RemoveItemFromBoard(IPositionable item, Board board)
        {
            board.FloorsPos.Add(item.Position);
            board.Items.Remove((Item)item);
        }

        /// <summary>
        /// Main game logic goes here ? Am I doing this right ? :D WE NEED AN ENGINE !
        /// </summary>
        public void Start()
        {
            bool isDead = false;
            BoardFactory factory = new BoardFactory(new Position(0 + 10, 0 + 2), new Position(80 - 1, 25 - 1));
            Board board = factory.GenerateBoard();
            int boardLevel = 0;
            int boardLevelChange = 0;
            var playedBoards = new List<Board>();
            var gandalf = Rogue.Instance;
            gandalf.Health.Current = 50;
            gandalf.Mana.Current = 70;

            while (!isDead)
            {
                if (boardLevelChange >= 0)
                {
                    gandalf.Position = new Position(board.EntryStairPos.X, board.EntryStairPos.Y);
                }
                else
                {
                    gandalf.Position = new Position(board.ExitStairPos.X, board.ExitStairPos.Y);
                }
                ConsoleRenderer.RenderPlayingScreen(gandalf, board, boardLevel);
                boardLevelChange = PlayBoard(board, playedBoards, gandalf, boardLevel);
                boardLevel += boardLevelChange;
                if (boardLevel == playedBoards.Count)
                {
                    board = factory.GenerateBoard();
                }
                else
                {
                    board = playedBoards[boardLevel];
                }
            }
            //Initialise charaters and items on console!
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

            //foreach (var item in board.Items)
            //{
            //    ConsoleRenderer.RenderItem(item);
            //}

            //test the potion


            // var testX = potion.Position.X;
            
            
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
    }
}
