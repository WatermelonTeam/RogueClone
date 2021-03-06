﻿namespace RogueClone.Movements
{
    using RogueClone.Common;
    using System;
    using System.Linq;
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
            var allWalls = board.HorizontalWallsPos.Concat(board.VerticalWallsPos).ToArray();
            foreach (var wall in allWalls)
            {
                if (newPosition == wall)
                {
                    return false;
                }
            }
            foreach (var item in board.PositionableObjects)
            {
                if (item is Character && newPosition == item.Position)
                {
                    return false;
                }
                else if (newPosition == item.Position)
                {
                    return true;
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
