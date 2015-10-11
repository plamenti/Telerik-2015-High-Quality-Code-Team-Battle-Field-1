namespace BattleFieldGame
{
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

        public static string NegativeNumberMessage(string propertyName)
        {
            return propertyName + NegativeMessage;
        }

        public static string NumberOutOfRange(string propertyName)
        {
            return propertyName + OutOfRangeMessage;
        }

        public static string NumberBetweenMessage(int min, int max)
        {
            return string.Format("Enter a number between {0} and {1}!", min, max);
        }
    }
}