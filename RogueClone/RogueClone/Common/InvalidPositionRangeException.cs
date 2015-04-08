namespace RogueClone.Common
{
    using System;
    public class InvalidPositionRangeException : ApplicationException
    {
       private const string exMessage = "{0} Valid range is X: [{1} ... {2}) and Y: [{3} ... {4})";
        public int StartX { get; set; }
        public int EndX { get; set; }
        public int StartY { get; set; }
        public int EndY { get; set; }

        public InvalidPositionRangeException(string msg, int startX, int endX, int startY, int endY)
            : base(string.Format(exMessage, msg, startX, endX, startY, endY))
        {
            this.StartX = startX;
            this.EndX = endX;
            this.StartY = startY;
            this.EndY = endY;
        }
        public InvalidPositionRangeException(string msg, int startX, int endX, int startY, int endY, Exception innerEx)
            : base(string.Format(exMessage, msg, startX, endX, startY, endY), innerEx)
        {
            this.StartX = startX;
            this.EndX = endX;
            this.StartY = startY;
            this.EndY = endY;
        }
    }
}
