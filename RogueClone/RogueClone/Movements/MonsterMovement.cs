namespace RogueClone.Movements
{
    using System;



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
            if (newPosition == board.ShopKeeperPos)
            {
                return false;
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