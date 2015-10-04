namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    public class ConsoleReader : IReader
    {
        public int ReadSingleNumber()
        {
            string input = Console.ReadLine();
            int number = 0;

            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(GlobalConstants.NumberBetweenMessage(GlobalConstants.MinBattleFieldSize, GlobalConstants.MaxBattleFieldSize));
                input = Console.ReadLine();
            }

            return number;
        }
    }
}