namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    public class GameEngine
    {
        private IRandomNumberGenerator randomNumberGenerator;
        private IReader reader;
        private IRenderer renderer;

        public GameEngine(IRandomNumberGenerator randomNumberGenerator, IReader reader, IRenderer renderer)
        {
            this.randomNumberGenerator = randomNumberGenerator;
            this.reader = reader;
            this.renderer = renderer;
        }

        public void PlayerTurn(int n, int rows, int cols, string[,] workField, int numberOfTurnsPlayed)
        {
            numberOfTurnsPlayed++;
            Console.WriteLine(GlobalConstants.EnterCoordinates);
            string xy = Console.ReadLine();
            int x = int.Parse(xy.Substring(0, 1));
            int y = int.Parse(xy.Substring(2, 1));

            while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
            {
                Console.WriteLine(GlobalConstants.InvalidMove);
                Console.WriteLine(GlobalConstants.EnterCoordinates);
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));
            }

            x += 2;
            y = (2 * y) + 2;

            while (workField[x, y] == "-" || workField[x, y] == "X")
            {
                Console.WriteLine(GlobalConstants.InvalidMove);
                Console.WriteLine(GlobalConstants.EnterCoordinates);
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));

                while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
                {
                    Console.WriteLine(GlobalConstants.InvalidMove);
                    Console.WriteLine(GlobalConstants.EnterCoordinates);
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

            //this.PrintArray(rows, cols, workField);
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
            Console.Write(GlobalConstants.WelcomeMessage);

            int playfieldSize = this.reader.ReadSingleNumber();

            while (playfieldSize < GlobalConstants.MinBattleFieldSize || playfieldSize > GlobalConstants.MaxBattleFieldSize)
            {
                Console.WriteLine(GlobalConstants.NumberBetweenMessage(GlobalConstants.MinBattleFieldSize, GlobalConstants.MaxBattleFieldSize));
                playfieldSize = this.reader.ReadSingleNumber();
            }

            var playfield = new Playfield(playfieldSize, this.randomNumberGenerator);
            renderer.RenderPlayfield(playfield);

            int numberOfTurnsPlayed = 0;
            //this.PlayerTurn(playfieldFieldSize, fieldHeight, fieldWidth, battleField, numberOfTurnsPlayed);
        }
    }
}