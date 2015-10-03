﻿namespace BattleFieldGame
{
    public static class GlobalConstants
    {
        public const int MinBattleFieldSize = 1;
        public const int MaxBattleFieldSize = 10;
        public const int BorderSize = 2;

        private const string NegativeMessage = " cannot be negative number";
        private const string OutOfRangeMessage = " is out of range";

        public static string NegativeNumberMessage(string propertyName)
        {
            return propertyName + NegativeMessage;
        }

        public static string NumberOutOfRange(string propertyName)
        {
            return propertyName + OutOfRangeMessage;
        }
    }
}