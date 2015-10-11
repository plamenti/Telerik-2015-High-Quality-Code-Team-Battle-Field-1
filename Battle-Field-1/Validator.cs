﻿namespace BattleFieldGame
{
    public static class Validator
    {
        public static bool IsNegativeNumber(int number)
        {
            if (number < 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsNegativeOrZeroNumber(int number)
        {
            if (number <= 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsNumberBetween(int min, int max, int number)
        {
            if (number < min || number > max)
            {
                return false;
            }

            return true;
        }

        public static bool IsInRange(int number, int size)
        {
            if (number >= 0 && number < size)
            {
                return true;
            }

            return false;
        }
    }
}