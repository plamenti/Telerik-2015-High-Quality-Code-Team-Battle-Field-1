namespace BattleFieldGame
{
    using System;

    public class RandomNumberGenerator
    {
        private Random random = new Random();

        public int Next(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}