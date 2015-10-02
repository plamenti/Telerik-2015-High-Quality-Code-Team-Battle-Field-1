namespace BattleFieldGame
{
    public static class GlobalConstants
    {
        private const string NegativeMessage = " cannot be negative number";

        public static string NegativeNumberMessage(string propertyName)
        {
            return propertyName + NegativeMessage;
        }
    }
}