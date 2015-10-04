namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random random = new Random();

        public int Next(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}