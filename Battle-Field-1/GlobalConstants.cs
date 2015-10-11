namespace BattleFieldGame
{
    /// <summary>
    /// Class that is responsible for all global constants in application
    /// </summary>
    public static class GlobalConstants
    {
        public const int MinBattleFieldSize = 1;
        public const int MaxBattleFieldSize = 10;
        public const int BorderSize = 2;
        public const double MinPercent = 0.15;
        public const double MaxPercent = 0.30;

        public const string EnterCoordinates = "Please enter coordinates/row, col/ stared from zero(0), separated by whitespace: ";
        public const string InvalidMove = "Invalid move!";

        private const string NegativeMessage = " cannot be negative number";
        private const string OutOfRangeMessage = " is out of range";

        /// <summary>
        /// Construct message for negative number message
        /// </summary>
        /// <param name="propertyName">Name of property that is called this method</param>
        /// <returns>Constructed message with name of property and message</returns>
        public static string NegativeNumberMessage(string propertyName)
        {
            return propertyName + NegativeMessage;
        }

        /// <summary>
        /// Construct message for out of range
        /// </summary>
        /// <param name="propertyName">Name of property that is called this method</param>
        /// <returns>Constructed message with name of property and message</returns>
        public static string NumberOutOfRange(string propertyName)
        {
            return propertyName + OutOfRangeMessage;
        }

        /// <summary>
        /// Construct message when number is between two integer numbers
        /// </summary>
        /// <param name="min">Lower boundary</param>
        /// <param name="max">Upper boundary</param>
        /// <returns>Constructed message with lower and upper boundary</returns>
        public static string NumberBetweenMessage(int min, int max)
        {
            return string.Format("Enter a number between {0} and {1}!", min, max);
        }
    }
}