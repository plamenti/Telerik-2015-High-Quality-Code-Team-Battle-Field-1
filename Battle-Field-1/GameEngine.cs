namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    public class GameEngine
    {
        private IRandomNumberGenerator randomNumberGenerator;
        private IReader reader;
        private IRenderer renderer;
        private int numberOfTurnsPlayed = 0;
        private bool isGameOver = false;

        public GameEngine(IRandomNumberGenerator randomNumberGenerator, IReader reader, IRenderer renderer)
        {
            this.randomNumberGenerator = randomNumberGenerator;
            this.reader = reader;
            this.renderer = renderer;
        }
        
        //public void HitOne(int x, int y, int rows, int cols, string[,] workField)
        //{
        //    workField[x, y] = "X";
        //    if (x - 1 > 1 && y - 2 > 1)
        //    {
        //        workField[x - 1, y - 2] = "X";
        //    }

        //    if (x - 1 > 1 && y < cols - 2)
        //    {
        //        workField[x - 1, y + 2] = "X";
        //    }

        //    if (x < rows - 1 && y < cols - 2)
        //    {
        //        workField[x + 1, y + 2] = "X";
        //    }

        //    if (x < rows - 1 && y - 2 > 1)
        //    {
        //        workField[x + 1, y - 2] = "X";
        //    }
        //}

        //public void HitTwo(int x, int y, int rows, int cols, string[,] workField)
        //{
        //    workField[x, y] = "X";
        //    this.HitOne(x, y, rows, cols, workField);
        //    if (y - 2 > 1)
        //    {
        //        workField[x, y - 2] = "X";
        //    }

        //    if (y < cols - 2)
        //    {
        //        workField[x, y + 2] = "X";
        //    }

        //    if (x - 1 > 1)
        //    {
        //        workField[x - 1, y] = "X";
        //    }

        //    if (x < rows - 1)
        //    {
        //        workField[x + 1, y] = "X";
        //    }
        //}

        //public void HitThree(int x, int y, int rows, int cols, string[,] workField)
        //{
        //    this.HitTwo(x, y, rows, cols, workField);
        //    if (x - 2 > 1)
        //    {
        //        workField[x - 2, y] = "X";
        //    }

        //    if (x < rows - 2)
        //    {
        //        workField[x + 2, y] = "X";
        //    }

        //    if (y - 4 > 1)
        //    {
        //        workField[x, y - 4] = "X";
        //    }

        //    if (y == 18)
        //    {
        //        workField[x, y + 2] = "X";
        //    }
        //    else if (y == 20)
        //    {
        //        workField[x, y] = "X";
        //    }
        //    else
        //    {
        //        if (y < cols - 3)
        //        {
        //            workField[x, y + 4] = "X";
        //        }
        //    }
        //}

        //public void HitFour(int x, int y, int rows, int cols, string[,] workField)
        //{
        //    this.HitThree(x, y, rows, cols, workField);
        //    if (x - 2 > 1 && y - 2 > 1)
        //    {
        //        workField[x - 2, y - 2] = "X";
        //    }

        //    if (x - 1 > 1 && y - 4 > 1)
        //    {
        //        workField[x - 1, y - 4] = "X";
        //    }

        //    if (x - 2 > 1 && y < cols - 2)
        //    {
        //        workField[x - 2, y + 2] = "X";
        //    }

        //    if (x < rows - 1 && y - 4 > 1)
        //    {
        //        workField[x + 1, y - 4] = "X";
        //    }

        //    if (x < rows - 2 && y - 2 > 1)
        //    {
        //        workField[x + 2, y - 2] = "X";
        //    }

        //    if (x < rows - 2 && y < cols - 2)
        //    {
        //        workField[x + 2, y + 2] = "X";
        //    }

        //    if (y == 18)
        //    {
        //        if (x - 1 > 1)
        //        {
        //            workField[x - 1, y + 2] = "X";
        //        }

        //        if (x < rows - 1)
        //        {
        //            workField[x + 1, y + 2] = "X";
        //        }
        //    }
        //    else if (y == 20)
        //    {
        //        if (x - 1 > 1)
        //        {
        //            workField[x - 1, y] = "X";
        //        }

        //        if (x < rows - 1)
        //        {
        //            workField[x + 1, y] = "X";
        //        }
        //    }
        //    else
        //    {
        //        if (x - 1 > 1 && y < cols - 3)
        //        {
        //            workField[x - 1, y + 4] = "X";
        //        }

        //        if (x < rows - 1 && y < cols - 3)
        //        {
        //            workField[x + 1, y + 4] = "X";
        //        }
        //    }
        //}

        //public void HitFive(int x, int y, int rows, int cols, string[,] workField)
        //{
        //    this.HitFour(x, y, rows, cols, workField);
        //    if (x - 2 > 1 && y - 4 > 1)
        //    {
        //        workField[x - 2, y - 4] = "X";
        //    }

        //    if (x < rows - 2 && y - 4 > 1)
        //    {
        //        workField[x + 2, y - 4] = "X";
        //    }

        //    if (y == 18)
        //    {
        //        if (x < rows - 2)
        //        {
        //            workField[x + 2, y + 2] = "X";
        //        }

        //        if (x - 2 > 1)
        //        {
        //            workField[x - 2, y + 2] = "X";
        //        }
        //    }
        //    else if (y == 20)
        //    {
        //        if (x < rows - 2)
        //        {
        //            workField[x + 2, y] = "X";
        //        }

        //        if (x - 2 > 1)
        //        {
        //            workField[x - 2, y] = "X";
        //        }
        //    }
        //    else
        //    {
        //        if (x < rows - 2 && y < cols - 3)
        //        {
        //            workField[x + 2, y + 4] = "X";
        //        }

        //        if (x - 2 > 1 && y < cols - 3)
        //        {
        //            workField[x - 2, y + 4] = "X";
        //        }
        //    }
        //}

        //public bool HasGameEnded(int rows, int cols, string[,] workField)
        //{
        //    bool isGameOver = true;
        //    for (int i = 2; i < rows; i++)
        //    {
        //        for (int j = 2; j < cols; j++)
        //        {
        //            if (workField[i, j] == "1" || workField[i, j] == "2" || workField[i, j] == "3" || workField[i, j] == "4" || workField[i, j] == "5")
        //            {
        //                isGameOver = false;
        //                break;
        //            }
        //        }
        //    }

        //    return isGameOver;
        //}

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
            this.renderer.RenderPlayfield(playfield);

            while (!this.isGameOver)
	        {
                this.PlayTurn(playfield);	         
	        }
        }

        private string GetSymbolFromField(IPlayfield playfield)
        {
            Console.WriteLine(GlobalConstants.EnterCoordinates);

            int[] coordinates = this.reader.ReadCoordinates();

            while (!(coordinates[0] >= 0 && coordinates[0] < playfield.Size
                    && coordinates[1] >= 0 && coordinates[1] < playfield.Size))
            {
                coordinates = this.reader.ReadCoordinates();
            }

            int row = coordinates[0];
            int col = coordinates[1];

            return playfield.GetCell(row, col);
        }

        private void Hit(string symbol)
        {
            throw new NotImplementedException();
        }

        private void PlayTurn(IPlayfield playfield)
        {
            this.numberOfTurnsPlayed++;
            string symbol = this.GetSymbolFromField(playfield);

            while (symbol == "-" || symbol == "X")
            {
                symbol = this.GetSymbolFromField(playfield);
            }

            this.Hit(symbol);

            //switch (hitCoordinate)
            //{
            //    case 1:
            //        this.HitOne(x, y, rows, cols, workField);
            //        break;

            //    case 2:
            //        this.HitTwo(x, y, rows, cols, workField);
            //        break;

            //    case 3:
            //        this.HitThree(x, y, rows, cols, workField);
            //        break;

            //    case 4:
            //        this.HitFour(x, y, rows, cols, workField);
            //        break;

            //    case 5:
            //        this.HitFive(x, y, rows, cols, workField);
            //        break;
            //}

            ////this.PrintArray(rows, cols, workField);
            //if (!this.HasGameEnded(rows, cols, workField))
            //{
            //    this.PlayTurn(n, rows, cols, workField);
            //}
            //else
            //{
            //    Console.WriteLine("Game over. Detonated mines: " + numberOfTurnsPlayed);
            //}
        }
    }
}