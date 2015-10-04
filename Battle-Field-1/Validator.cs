namespace BattleFieldGame
{
    public static class Validator
    {
        public static bool IsPositiveNumber(int number)
        {
            if (number <= 0)
            {
                return false;
            }

            return true;
        }

        public static bool IsNumberBetween(int min, int max, int number)
        {
            if (number < min || number > max)
            {
                return false;
            }

            return true;
        }
    }
}