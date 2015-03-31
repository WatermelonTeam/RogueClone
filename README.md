# RogueClone
RogueClone by Team Watermelon

##Sample documentation

##API Refference:

###Game
------
Create and start the game :

```C#
var game = new Game(100, 30, 100);
game.Start();
```

Create a hero :
```C#
var gandalf = new Wizard("Gandalf", new Health(100), new Mana(200), new Level(1), 9999, 10, 0, new Point2D(10, 10), '@');
```

####Game.SetHeroPosition(Hero hero, int newX, int newY)
Sets the hero at the newX and newY coordinates - We should use Point2D for this.
```C#
Game.SetHeroPosition(hero, 10, 10);
```
####Game.CheckKeyPressingAndSetMovement(Hero hero);
```C#
Game.CheckKeyPressingAndSetMovement(gandalf);
```


###Engine
------
####?RengerDungeon(string[] dungeon) -- Under Development.
```C#
var dungeon = new Board();
Engine.RengerDungeon(string[] dungeon)
```

####RenderHero(Hero hero) - Prints the hero with his Point2D coordinates.
```C#
Engine.RenderHero(gandalf);
```
####?RenderMonster(Monster monster) -- Under Development.
```C#
var monster = new Monster(); // Under Development
Engine.RenderMonster(monster);
```
####RenderItem(Item item) - Prints the item with his Point2D coordinates.
```C#
var potion = new Potion("small potion", 10, 0, new Point2D(20, 20), "+", 100);
Engine.RenderStats(potion);
```
####RenderStats(Hero hero) - Prints the hero stats on the bottom of the console.
```C#
Engine.RenderStats(gandalf);
```
####PrintOnPosition(int x, int y, string text) - Prints on x and y cordinates the text.
```C#
Engine.PrintOnPosition(3, Console.WindowHeight - 3, string.Format("HP: {0} \\ {1}", hero.Health.Current, hero.Health.Max));
```

Under construction ...

###Hero

###Dungeon

###Consumables

###NPCs

###Stats

...
