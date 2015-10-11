namespace BattleFieldGame
{
    /// <summary>
    /// Global validator for all application
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Check if number is negative
        /// </summary>
        /// <param name="number">Number that will be checked</param>
        /// <returns>Returns is the number is negative</returns>
        public static bool IsNegativeNumber(int number)
        {
            if (number < 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if number is negative or zero
        /// </summary>
        /// <param name="number">Number that will be checked</param>
        /// <returns>Returns is the number is negative or zero</returns>
        public static bool IsNegativeOrZeroNumber(int number)
        {
            if (number <= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the number is between two numbers
        /// </summary>
        /// <param name="min">Lower boundary</param>
        /// <param name="max">Upper boundary</param>
        /// <param name="number">Number that will be checked</param>
        /// <returns>Returns if the number is between min and max</returns>
        public static bool IsNumberBetween(int min, int max, int number)
        {
            if (number < min || number > max)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if number is in given range started from zero
        /// </summary>
        /// <param name="number">Number that will be checked</param>
        /// <param name="size">Upper boudary of range</param>
        /// <returns>Returns if the number is between zero and size</returns>
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