namespace BattleField
{
    using System;
    using System.Linq;

    public class BattlefieldGameEngine
    {
        private const int MinBattleFieldSize = 1;
        private const int MaxBattleFieldSize = 10;
        private const int BorderSize = 2;

        public static void FillingTheArray(int n, int rows, int cols, string[,] workField)
        {
            int count = 0;
            Random randomNumber = new Random();
            int randomPlaceI;
            int randomPlaceJ;
            int minPercent = Convert.ToInt32(0.15 * (n * n));
            int maxPercent = Convert.ToInt32(0.30 * (n * n));
            int countMines = randomNumber.Next(minPercent, maxPercent);

            while (count <= countMines)
            {
                randomPlaceI = randomNumber.Next(0, n);
                randomPlaceJ = randomNumber.Next(0, n);
                randomPlaceI += 2;
                randomPlaceJ = (2 * randomPlaceJ) + 2;

                while (workField[randomPlaceI, randomPlaceJ] != " " && workField[randomPlaceI, randomPlaceJ] != "-")
                {
                    randomPlaceI = randomNumber.Next(0, n);
                    randomPlaceJ = randomNumber.Next(0, n);
                    randomPlaceI += 2;
                    randomPlaceJ = (2 * randomPlaceJ) + 2;
                }

                string randomDigit = Convert.ToString(randomNumber.Next(1, 6));
                workField[randomPlaceI, randomPlaceJ] = randomDigit;
                workField[randomPlaceI, randomPlaceJ + 1] = " ";
                count++;
            }
        }

        public static void PrintArray(int rows, int cols, string[,] workField)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(workField[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void PlayerTurn(int n, int rows, int cols, string[,] workField, int numberOfTurnsPlayed)
        {
            numberOfTurnsPlayed++;
            Console.WriteLine("Please enter coordinates: ");
            string xy = Console.ReadLine();
            int x = int.Parse(xy.Substring(0, 1));
            int y = int.Parse(xy.Substring(2, 1));

            while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
            {
                Console.WriteLine("Invalid move !");
                Console.WriteLine("Please enter coordinates: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));
            }

            x += 2;
            y = (2 * y) + 2;

            while (workField[x, y] == "-" || workField[x, y] == "X")
            {
                Console.WriteLine("Invalid move! ");
                Console.WriteLine("Please enter coordinates: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));

                while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates: ");
                    xy = Console.ReadLine();
                    x = int.Parse(xy.Substring(0, 1));
                    y = int.Parse(xy.Substring(2, 1));
                }

                x += 2;
                y = (2 * y) + 2;
            }

            int hitCoordinate = Convert.ToInt32(workField[x, y]);

            switch (hitCoordinate)
            {
                case 1: 
                    HitOne(x, y, rows, cols, workField); 
                    break;
                case 2: 
                    PrasniDvama(x, y, rows, cols, workField); 
                    break;
                case 3: 
                    HitThree(x, y, rows, cols, workField); 
                    break;
                case 4: 
                    HitFour(x, y, rows, cols, workField); 
                    break;
                case 5: 
                    HitFive(x, y, rows, cols, workField); 
                    break;
            }

            PrintArray(rows, cols, workField);
            if (!Krai(rows, cols, workField))
            {
                PlayerTurn(n, rows, cols, workField, numberOfTurnsPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + numberOfTurnsPlayed);
            }
        }

        public static void HitOne(int x, int y, int rows, int cols, string[,] workField)
        {
            workField[x, y] = "X";
            if (x - 1 > 1 && y - 2 > 1)
            {
                workField[x - 1, y - 2] = "X";
            }

            if (x - 1 > 1 && y < cols - 2)
            {
                workField[x - 1, y + 2] = "X";
            }

            if (x < rows - 1 && y < cols - 2)
            {
                workField[x + 1, y + 2] = "X";
            }

            if (x < rows - 1 && y - 2 > 1)
            {
                workField[x + 1, y - 2] = "X";
            }
        }

        public static void PrasniDvama(int x, int y, int rows, int cols, string[,] workField)
        {
            workField[x, y] = "X";
            HitOne(x, y, rows, cols, workField);
            if (y - 2 > 1)
            {
                workField[x, y - 2] = "X";
            }

            if (y < cols - 2)
            {
                workField[x, y + 2] = "X";
            }

            if (x - 1 > 1)
            {
                workField[x - 1, y] = "X";
            }

            if (x < rows - 1)
            {
                workField[x + 1, y] = "X";
            }
        }

        public static void HitThree(int x, int y, int rows, int cols, string[,] workField)
        {
            PrasniDvama(x, y, rows, cols, workField);
            if (x - 2 > 1)
            {
                workField[x - 2, y] = "X";
            }

            if (x < rows - 2)
            {
                workField[x + 2, y] = "X";
            }

            if (y - 4 > 1)
            {
                workField[x, y - 4] = "X";
            }

            if (y == 18)
            {
                workField[x, y + 2] = "X";
            }
            else if (y == 20)
            {
                workField[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    workField[x, y + 4] = "X";
                }
            }
        }

        public static void HitFour(int x, int y, int rows, int cols, string[,] workField)
        {
            HitThree(x, y, rows, cols, workField);
            if (x - 2 > 1 && y - 2 > 1)
            {
                workField[x - 2, y - 2] = "X";
            }

            if (x - 1 > 1 && y - 4 > 1)
            {
                workField[x - 1, y - 4] = "X";
            }

            if (x - 2 > 1 && y < cols - 2)
            {
                workField[x - 2, y + 2] = "X";
            }

            if (x < rows - 1 && y - 4 > 1)
            {
                workField[x + 1, y - 4] = "X";
            }

            if (x < rows - 2 && y - 2 > 1)
            {
                workField[x + 2, y - 2] = "X";
            }

            if (x < rows - 2 && y < cols - 2)
            {
                workField[x + 2, y + 2] = "X";
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y] = "X";
                }
            }
            else
            {
                if (x - 1 > 1 && y < cols - 3)
                {
                    workField[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    workField[x + 1, y + 4] = "X";
                }
            }
        }

        public static void HitFive(int x, int y, int rows, int cols, string[,] poleZaRabota)
        {
            HitFour(x, y, rows, cols, poleZaRabota);
            if (x - 2 > 1 && y - 4 > 1)
            {
                poleZaRabota[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                poleZaRabota[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y + 2] = "X";
                }

                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y] = "X";
                }

                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y] = "X";
                }
            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    poleZaRabota[x + 2, y + 4] = "X";
                }

                if (x - 2 > 1 && y < cols - 3)
                {
                    poleZaRabota[x - 2, y + 4] = "X";
                }
            }
        }

        public static bool Krai(int rows, int cols, string[,] poleto)
        {
            bool край = true;
            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (poleto[i, j] == "1" || poleto[i, j] == "2" || poleto[i, j] == "3" || poleto[i, j] == "4" || poleto[i, j] == "5")
                    {
                        край = false;
                        break;
                    }
                }
            }

            return край;
        }

        public void Run()
        {
            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            int battleFieldSize = Convert.ToInt32(Console.ReadLine());
            while (battleFieldSize < MinBattleFieldSize || battleFieldSize > MaxBattleFieldSize)
            {
                Console.WriteLine("Enter a number between {0} and {1}!", MinBattleFieldSize, MaxBattleFieldSize);
                battleFieldSize = Convert.ToInt32(Console.ReadLine());
            }

            int fieldHeight = battleFieldSize + BorderSize;
            int fieldWidth = (battleFieldSize * 2) + BorderSize;

            string[,] battleField = new string[fieldHeight, fieldWidth];

            battleField[0, 0] = " ";
            battleField[0, 1] = " ";
            battleField[1, 0] = " ";
            battleField[1, 1] = " ";

            for (int row = 2; row < fieldHeight; row++)
            {
                for (int col = 2; col < fieldWidth; col++)
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

                    if (col < fieldWidth - 1)
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

            BattlefieldGameEngine.FillingTheArray(battleFieldSize, fieldHeight, fieldWidth, battleField);
            BattlefieldGameEngine.PrintArray(fieldHeight, fieldWidth, battleField);
            int numberOfTurnsPlayed = 0;
            BattlefieldGameEngine.PlayerTurn(battleFieldSize, fieldHeight, fieldWidth, battleField, numberOfTurnsPlayed);
        }
    }
}
