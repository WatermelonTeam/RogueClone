﻿namespace RogueClone
{
    using RogueClone;
    using RogueClone.Common;
    using System.Linq;
    using RogueClone.InputProviders;
    using System;
    using System.Collections.Generic;
    using RogueClone.Movements;

    public sealed class RogueEngine : IEngine
    {
        private readonly ConsoleInputProvider input;

        public static readonly RogueEngine Instance = new RogueEngine(130, 50, new ConsoleInputProvider());
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
        private int PlayBoard(Board board, List<Board> boards, Hero hero, int boardLevel, List<Monster> monsters)
        {
            bool itemSteppedByHero = true;
            bool itemSteppedByMonster = false;
            bool stairsSteppedOnByHero = true;
            bool stairsSteppedOnByMonster = false;
            bool isNextToCharacter = false;
            int itemDescriptionLength = 0;
            int itemNameLength = 0;

            foreach (var monster in monsters)
            {
                monster.Death += (sender, args) =>
                {
                    Monster mnstr = sender as Monster;
                    hero.Level.AddXP(mnstr.XPGain);
                };
            }
            
            ConsoleRenderer.RenderAllItems(board.PositionableObjects);
            while (hero.IsAlive)
            {
                Position desiredPos = input.SetMovement(board, hero.Position);
                ConsoleRenderer.RenderMove(board, hero, desiredPos);
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
                if (stairsSteppedOnByHero)
                {
                    ConsoleRenderer.RenderStairs(board);
                    stairsSteppedOnByHero = false;
                }
                if (hero.Position == board.EntryStairPos || hero.Position == board.ExitStairPos)
                {
                    stairsSteppedOnByHero = true;
                }
                if (itemSteppedByHero)
                {
                    ConsoleRenderer.RenderAllItems(board.PositionableObjects);
                    ConsoleRenderer.RemoveDescription(itemNameLength, itemDescriptionLength);
                    itemSteppedByHero = false;
                }
                if (isNextToCharacter)
                {
                    ConsoleRenderer.RenderAllItems(board.PositionableObjects);
                    ConsoleRenderer.RemoveDescription(itemNameLength, itemDescriptionLength);
                    itemSteppedByHero = false;
                }
                // GameEngine is alias to ConsoleRenderer.Engine just check the usings              
                ConsoleRenderer.RenderStats(hero, boardLevel);
                //Always render the hero at the end so he can be on top on all the items and monsters !
                ConsoleRenderer.RenderCharacter(hero);
                foreach (var monster in monsters)
                {

                    if (hero.Position.Distance(monster.Position) < 1.5)
                    {
                        hero.TakeDamage(monster.Damage);
                    }
                    else if (hero.Position.Distance(monster.Position) < 5.5 && hero.Position.Distance(monster.Position) >= 1.5)
                    {
                        Position newPos = monster.NextMovingPosition(board, hero.Position);
                        if (MonsterMovement.IsValidMovement(board, newPos))
                        {
                            ConsoleRenderer.RenderMove(board, monster, newPos);
                            if (stairsSteppedOnByMonster)
                            {
                                ConsoleRenderer.RenderStairs(board);
                                stairsSteppedOnByMonster = false;
                            }
                            if (itemSteppedByMonster)
                            {
                                ConsoleRenderer.RenderAllItems(board.PositionableObjects);
                                itemSteppedByMonster = false;
                            }
                        }

                        if (monster.Position == board.EntryStairPos || monster.Position == board.ExitStairPos)
                        {
                            stairsSteppedOnByMonster = true;
                        }
                        foreach (var positionable in board.PositionableObjects)
                        {
                            if (monster.Position == positionable.Position)
                            {
                                if (positionable is Item)
                                {
                                    itemSteppedByMonster = true;
                                }
                            }
                        }

                        ConsoleRenderer.RenderCharacter(monster);

                    }

                    if (desiredPos == monster.Position)
                    {
                        monster.TakeDamage(hero.Weapon);
                    }

                }

                if (monsters.Any(mnstr => mnstr.IsAlive == false))
                {
                    var deadMonsters = monsters.Where(mnstr => mnstr.IsAlive == false).ToArray();
                    foreach (var monster in deadMonsters)
                    {
                        monsters.Remove(monster);
                        board.PositionableObjects.Remove(monster);
                        board.FreeFloorsPos.Add(monster.Position);
                        ConsoleRenderer.RenderObjectRemoval(monster.Position);
                    }
                }

                foreach (var positionable in board.PositionableObjects)
                {
                    if (positionable is Character)
                    {
                        if (hero.Position.Distance(positionable.Position) < 1.5)
                        {
                            ConsoleRenderer.RenderCharacterDescription(positionable as Character);
                            isNextToCharacter = true;
                        }

                        if (positionable is ShopKeeper && desiredPos == positionable.Position)
                        {
                            ShopKeeper shopKeeper = positionable as ShopKeeper;

                            do
                            {
                                ConsoleRenderer.RenderShopKeeperMenu(shopKeeper, hero);
                                ShopKeeperOptions option = input.ShopKeeperInteraction();
                                if (option == ShopKeeperOptions.Escape)
                                {
                                    break;
                                }
                                else if (option == ShopKeeperOptions.InvalidOption)
                                {
                                    ConsoleRenderer.Clear();
                                }
                                else
                                {
                                    int index = (int)option;

                                    if (shopKeeper.Items[index] != null && hero.Gold >= shopKeeper.Items[index].Value)
                                    {
                                        hero.Buy(shopKeeper.Items[index]);
                                        shopKeeper.Items[index] = null;
                                        break;
                                    }
                                }
                            } while (true);
                            ConsoleRenderer.Clear();
                            ConsoleRenderer.RenderPlayingScreen(hero, board, boardLevel);
                            ConsoleRenderer.RenderAllItems(board.PositionableObjects);
                        }
                    }


                    if (hero.Position == positionable.Position)
                    {
                        if (positionable is Item)
                        {
                            Item item = positionable as Item;
                            ConsoleRenderer.RenderItemDescription(item);
                            itemDescriptionLength = item.Description.Length;
                            itemNameLength = item.Name.Length;
                            itemSteppedByHero = true;
                            this.steppedOnItem = (char)item.Icon;
                            this.itemColor = item.ItemColor.ToConsoleColor();
                            hero.TakeItem(item, board);
                            break;
                        }

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
                    if armor
                      
                    */
                }
                
            }
            return 0;
        }

        //public static void RemoveItemFromBoard(IPositionable item, Board board)
        //{
        //    board.FloorsPos.Add(item.Position);
        //    board.PositionableObjects.Remove((Item)item);
        //}

        /// <summary>
        /// Main game logic goes here ? Am I doing this right ? :D WE NEED AN ENGINE !
        /// </summary>
        public void Start()
        {
            //bool isDead = false;
            BoardFactory factory = new BoardFactory(new Position(0 + 10, 0 + 2), new Position(80 - 1, 25 - 1));
            Board board = factory.GenerateBoard();
            int boardLevel = 0;
            int boardLevelChange = 0;
            var playedBoards = new List<Board>();
            var hero = Wizard.Instance;
            hero.Name = "Nathan Rahl";
            hero.Health.Current = 50;
            hero.Mana.Current = 70;

            while (hero.IsAlive)
            {
                MonsterFactory mFactory = new MonsterFactory(boardLevel);
                mFactory.SpawnMonstersOnBoard(board);
                if (boardLevelChange >= 0)
                {
                    hero.Position = new Position(board.EntryStairPos.X, board.EntryStairPos.Y);
                }
                else
                {
                    hero.Position = new Position(board.ExitStairPos.X, board.ExitStairPos.Y);
                }
                ConsoleRenderer.RenderPlayingScreen(hero, board, boardLevel);
                
                boardLevelChange = PlayBoard(board, playedBoards, hero, boardLevel,mFactory.MonsterList);
                foreach (var monster in mFactory.MonsterList)
                    board.PositionableObjects.Remove(monster);
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
