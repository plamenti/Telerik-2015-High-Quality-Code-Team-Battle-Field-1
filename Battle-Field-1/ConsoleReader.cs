namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    /// <summary>
    /// Class that read user's input from Console
    /// </summary>
    public class ConsoleReader : IReader
    {
        /// <summary>
        /// Read single number from console and parse it to integer
        /// </summary>
        /// <returns>Parsed single number as integer</returns>
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

        /// <summary>
        /// Reads coordinates separated by space from Console
        /// </summary>
        /// <returns>Returns array with 2 values - first is row of position and second is col of position</returns>
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