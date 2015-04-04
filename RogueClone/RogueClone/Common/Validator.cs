namespace RogueClone.Common
{
    using System;

    public static class Validator
    {
        private const string UnknownName = "[UnknownName]";

        public static void IsPositive(int value, string name = Validator.UnknownName)
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format("{0} can't be less than zero.", name));
            }
        }
        public static void IsWithinRange(int value, int start, int max, string name = Validator.UnknownName)
        {
            if (value < start || value > max)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} = {1} was out of bounds {2} - {3}.", name, value, start, max));
            }
        }
        public static string ValidateName(string value)
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name can't be empty, null or whitespace.");
            }

            return value;
        }
        public static void IsNotNull(object value, string name = Validator.UnknownName)
        {
            if (value == null)
            {
                throw new NullReferenceException(string.Format("{0} can't be null.", name));
            }
        }
    }
}