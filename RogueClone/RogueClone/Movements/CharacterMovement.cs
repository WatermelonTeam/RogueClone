namespace RogueClone.Movements
{
    using RogueClone.Common;
    using System;
    public class CharacterMovement
    {
        public static bool IsValidMovement(Board board, Position newPosition)
        {
            bool isInsideBoard = 
                (0 <= newPosition.X
                && 0 <= newPosition.Y
                && newPosition.X < RogueEngine.ConsoleWidth
                && newPosition.Y < RogueEngine.ConsoleHeight - ConsoleRenderer.StatsPanelHeight);
            bool isInsideDungeon = false;
            if (!isInsideBoard)
            {
                return isInsideBoard;
            }
            foreach (var doorPos in board.DoorsPos)
            {
                if (newPosition == doorPos)
                {
                    isInsideDungeon = true;
                    return isInsideDungeon;
                }
            }
            foreach (var corridorPos in board.CorridorsPos)
            {
                if (newPosition == corridorPos)
                {
                    isInsideDungeon = true;
                    return isInsideDungeon;
                }
            }
            foreach (var floorPos in board.FloorsPos)
            {
                if (newPosition == floorPos)
                {
                    isInsideDungeon = true;
                    return isInsideDungeon;
                }
            }
            foreach (var itemPos in board.ItemsPos)
            {
                if (newPosition == itemPos)
                {
                    isInsideDungeon = true;
                    return isInsideDungeon;
                }
            }
            foreach (var goldPos in board.GoldPositionsPos)
            {
                if (newPosition == goldPos)
                {
                    isInsideDungeon = true;
                    return isInsideDungeon;
                }
            }
            return isInsideDungeon;
        }
    }
}
