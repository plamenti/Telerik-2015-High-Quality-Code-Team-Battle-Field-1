namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    public class ConsoleReader : IReader
    {
        public int ReadSingleNumber()
        {
            string input = Console.ReadLine();
            int number;

            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(GlobalConstants.NumberBetweenMessage(GlobalConstants.MinBattleFieldSize, GlobalConstants.MaxBattleFieldSize));
                input = Console.ReadLine();
            }

            return number;
        }

        public int[] ReadCoordinates()
        {
            int[] coordinates = new int[2];
            string input = Console.ReadLine();

            while (input.Length != 3)
            {
                Console.WriteLine(GlobalConstants.EnterCoordinates);
                input = Console.ReadLine();
            }

            coordinates[0] = int.Parse(input[0].ToString());
            coordinates[1] = int.Parse(input[2].ToString());

            return coordinates;
        }
    }
}