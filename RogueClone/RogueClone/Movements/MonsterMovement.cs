namespace RogueClone.Movements
{
    using System;
    using System.Linq;



    public class MonsterMovement
    {
        public static bool IsValidMovement(Board board, Position newPosition)
        {
            bool isInsideBoard =
                (0 <= newPosition.X
                && 0 <= newPosition.Y
                && newPosition.X < RogueEngine.ConsoleWidth
                && newPosition.Y < RogueEngine.ConsoleHeight - ConsoleRenderer.StatsPanelHeight);
            bool isInsideDungeon = false;
            bool isOnTopOtherNPC = false;
            //So they can move through items and stairs like the hero
            if (!isInsideBoard)
            {
                return isInsideBoard;
            }
            
            if (newPosition == board.EntryStairPos || newPosition == board.ExitStairPos)
            {
                isInsideDungeon = true;
                return isInsideDungeon;
            }
            //Making sure monsters dont follow in corridors
            foreach (var corridorPos in board.CorridorsPos)
            {
                if (newPosition == corridorPos)
                {
                    isInsideDungeon = false;
                    return isInsideDungeon;
                }
            }
            var allWalls = board.HorizontalWallsPos.Concat(board.VerticalWallsPos).ToArray();
            foreach (var wall in allWalls)
            {
                if (newPosition == wall)
                {
                    return false;
                }
            }
            // Don't step on other monsters
            foreach (var positionable in board.PositionableObjects)
            {
                if (positionable is Monster)
                {
                    if (newPosition == positionable.Position)
                    {
                        return isOnTopOtherNPC;
                    }
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