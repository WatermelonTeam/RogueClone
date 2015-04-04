namespace RogueClone.Movements
{
    using RogueClone.Common;
    using RogueClone.Movement;
    using System;
    public class CharacterMovement : IMovement
    {
        public bool ValidateMovement(IMovable character, Board board, Position newPosition)
        {
            bool isInsideBoard = 
                (0 <= newPosition.X
                && 0 <= newPosition.Y
                && newPosition.X < Game.ConsoleWidth
                && newPosition.Y < Game.ConsoleHeight - Engine.statsPanelHeight);
            bool isInsideDungeon = false;
            foreach (var doorPos in board.DoorsPos)
            {
                if (newPosition == doorPos)
                {
                    isInsideDungeon = true;
                    return isInsideBoard && isInsideDungeon;
                }
            }
            foreach (var corridorPos in board.CorridorsPos)
            {
                if (newPosition == corridorPos)
                {
                    isInsideDungeon = true;
                    return isInsideBoard && isInsideDungeon;
                }
            }
            foreach (var floorPos in board.FloorsPos)
            {
                if (newPosition == floorPos)
                {
                    isInsideDungeon = true;
                    return isInsideBoard && isInsideDungeon;
                }
            }
            return isInsideBoard && isInsideDungeon;
        }
    }
}
