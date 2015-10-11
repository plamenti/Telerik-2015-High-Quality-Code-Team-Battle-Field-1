namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    /// <summary>
    /// Class for random numbers based on system class Random, made easier for test
    /// </summary>
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random random = new Random();

        /// <summary>
        /// Return integer number in range
        /// </summary>
        /// <param name="min">Lower boundary for number</param>
        /// <param name="max">Upper boundary for number</param>
        /// <returns>Returns number in range min and max - 1</returns>
        public int Next(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}