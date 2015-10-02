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
    }
}