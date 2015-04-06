namespace RogueClone.Movements
{
    using RogueClone.Common;
    using System;
    public class HeroMovement
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
            if (newPosition == board.EntryStairPos || newPosition == board.ExitStairPos)
            {
                isInsideDungeon = true;
                return isInsideDungeon;
            }
            foreach (var item in board.PositionableObjects)
            {
                if (item is Character && newPosition == item.Position)
                {
                    return false;
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
            return isInsideDungeon;
        }

    }
}
