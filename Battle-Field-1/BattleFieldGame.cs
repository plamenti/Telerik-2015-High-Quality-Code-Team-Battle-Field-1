﻿namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BattleFieldGame
    {
        private const int MinBattleFieldSize = 1;
        private const int MaxBattleFieldSize = 10;

        public static void Main(string[] argumenti)
        {
            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            int battleFieldSize = Convert.ToInt32(Console.ReadLine());
            while (battleFieldSize < MinBattleFieldSize || battleFieldSize > MaxBattleFieldSize)
            {
                Console.WriteLine("Enter a number between {0} and {1}!", MinBattleFieldSize, MaxBattleFieldSize);
                battleFieldSize = Convert.ToInt32(Console.ReadLine());
            }

            int rows = battleFieldSize + 2;
            int cols = (battleFieldSize * 2) + 2;

            string[,] battleField = new string[rows, cols];

            battleField[0, 0] = " ";
            battleField[0, 1] = " ";
            battleField[1, 0] = " ";
            battleField[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {
                for (int col = 2; col < cols; col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            battleField[0, col] = "0";
                        }
                        else
                        {
                            battleField[0, col] = Convert.ToString((col - 2) / 2);
                        }
                    }
                    else
                    {
                        battleField[0, col] = " ";
                    }

                    if (col < cols - 1)
                    {
                        battleField[1, col] = "-";
                    }

                    battleField[row, 0] = Convert.ToString(row - 2);
                    battleField[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        battleField[row, col] = "-";
                    }
                    else
                    {
                        battleField[row, col] = " ";
                    }
                }
            }

            Methods.FillingTheArray(battleFieldSize, rows, cols, battleField);
            Methods.PrintArray(rows, cols, battleField);
            int countPlayed = 0;
            Methods.VremeEIgrachaDaDeistva(battleFieldSize, rows, cols, battleField, countPlayed);
        }
    }
}