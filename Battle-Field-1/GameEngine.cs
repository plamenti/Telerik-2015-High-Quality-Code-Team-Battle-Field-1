namespace BattleFieldGame
{
    using System;

    public class GameEngine
    {
        // Extract constants in GlobalConstants
        private const int MinBattleFieldSize = 1;
        private const int MaxBattleFieldSize = 10;
        private const int BorderSize = 2;
        private RandomNumberGenerator randomNumber = new RandomNumberGenerator();

        public void FillingTheArray(int gameFieldSize, int rows, int cols, string[,] workField)
        {
            int randomPlaceI;
            int randomPlaceJ;
            int minPercent = Convert.ToInt32(0.15 * (gameFieldSize * gameFieldSize));
            int maxPercent = Convert.ToInt32(0.30 * (gameFieldSize * gameFieldSize));
            int countMines = this.randomNumber.Next(minPercent, maxPercent);

            for (int i = 0; i <= countMines; i++)
            {
                randomPlaceI = this.randomNumber.Next(0, gameFieldSize);
                randomPlaceJ = this.randomNumber.Next(0, gameFieldSize);
                randomPlaceI += 2;
                randomPlaceJ = (2 * randomPlaceJ) + 2;

                while ((workField[randomPlaceI, randomPlaceJ] != " ") && (workField[randomPlaceI, randomPlaceJ] != "-"))
                {
                    randomPlaceI = this.randomNumber.Next(0, gameFieldSize);
                    randomPlaceJ = this.randomNumber.Next(0, gameFieldSize);
                    randomPlaceI += 2;
                    randomPlaceJ = (2 * randomPlaceJ) + 2;
                }

                string randomDigit = Convert.ToString(this.randomNumber.Next(1, 6));
                workField[randomPlaceI, randomPlaceJ] = randomDigit;
                workField[randomPlaceI, randomPlaceJ + 1] = " ";
            }
        }

        public void PrintArray(int rows, int cols, string[,] workField)
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

        public void PlayerTurn(int n, int rows, int cols, string[,] workField, int numberOfTurnsPlayed)
        {
            numberOfTurnsPlayed++;
            Console.WriteLine("Please enter coordinates, separated by whitespace: ");
            string xy = Console.ReadLine();
            int x = int.Parse(xy.Substring(0, 1));
            int y = int.Parse(xy.Substring(2, 1));

            while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
            {
                Console.WriteLine("Invalid move!");
                Console.WriteLine("Please enter coordinates, separated by whitespace: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));
            }

            x += 2;
            y = (2 * y) + 2;

            while (workField[x, y] == "-" || workField[x, y] == "X")
            {
                Console.WriteLine("Invalid move! ");
                Console.WriteLine("Please enter coordinates, separated by whitespace: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));

                while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates, separated by whitespace: ");
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
                    this.HitOne(x, y, rows, cols, workField);
                    break;
                case 2:
                    this.HitTwo(x, y, rows, cols, workField);
                    break;
                case 3:
                    this.HitThree(x, y, rows, cols, workField);
                    break;
                case 4:
                    this.HitFour(x, y, rows, cols, workField);
                    break;
                case 5:
                    this.HitFive(x, y, rows, cols, workField);
                    break;
            }

            this.PrintArray(rows, cols, workField);
            if (!this.HasGameEnded(rows, cols, workField))
            {
                this.PlayerTurn(n, rows, cols, workField, numberOfTurnsPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + numberOfTurnsPlayed);
            }
        }

        public void HitOne(int x, int y, int rows, int cols, string[,] workField)
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

        public void HitTwo(int x, int y, int rows, int cols, string[,] workField)
        {
            workField[x, y] = "X";
            this.HitOne(x, y, rows, cols, workField);
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

        public void HitThree(int x, int y, int rows, int cols, string[,] workField)
        {
            this.HitTwo(x, y, rows, cols, workField);
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

        public void HitFour(int x, int y, int rows, int cols, string[,] workField)
        {
            this.HitThree(x, y, rows, cols, workField);
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

        public void HitFive(int x, int y, int rows, int cols, string[,] workField)
        {
            this.HitFour(x, y, rows, cols, workField);
            if (x - 2 > 1 && y - 4 > 1)
            {
                workField[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                workField[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    workField[x + 2, y + 2] = "X";
                }

                if (x - 2 > 1)
                {
                    workField[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    workField[x + 2, y] = "X";
                }

                if (x - 2 > 1)
                {
                    workField[x - 2, y] = "X";
                }
            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    workField[x + 2, y + 4] = "X";
                }

                if (x - 2 > 1 && y < cols - 3)
                {
                    workField[x - 2, y + 4] = "X";
                }
            }
        }

        public bool HasGameEnded(int rows, int cols, string[,] workField)
        {
            bool isGameOver = true;
            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (workField[i, j] == "1" || workField[i, j] == "2" || workField[i, j] == "3" || workField[i, j] == "4" || workField[i, j] == "5")
                    {
                        isGameOver = false;
                        break;
                    }
                }
            }

            return isGameOver;
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

            this.FillingTheArray(battleFieldSize, fieldHeight, fieldWidth, battleField);
            this.PrintArray(fieldHeight, fieldWidth, battleField);
            int numberOfTurnsPlayed = 0;
            this.PlayerTurn(battleFieldSize, fieldHeight, fieldWidth, battleField, numberOfTurnsPlayed);
        }
    }
}