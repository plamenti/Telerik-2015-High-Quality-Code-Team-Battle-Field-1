namespace BattleFieldGame
{
    using System;
    using System.Linq;
    using BattleFieldGame.Contracts;

    public class GameEngine
    {
        private IRandomNumberGenerator randomNumberGenerator;
        private IReader reader;
        private IRenderer renderer;
        private IPlayfield playfield;
        private int numberOfTurnsPlayed = 0;
        private bool isGameOver = false;
        private IPosition currentHit = new Position(0, 0);

        public GameEngine(IRandomNumberGenerator randomNumberGenerator, IReader reader, IRenderer renderer, IPlayfield playfield)
        {
            this.randomNumberGenerator = randomNumberGenerator;
            this.reader = reader;
            this.renderer = renderer;
            this.playfield = playfield;
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

            this.playfield = new Playfield(playfieldSize);
            this.playfield.FillPlayfield(this.randomNumberGenerator);
            this.renderer.RenderPlayfield(this.playfield);

            while (!this.isGameOver)
            {
                this.PlayTurn();
            }

            this.renderer.RenderMessage("Congratiolations you won in " + this.numberOfTurnsPlayed + " turns!");
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

            this.currentHit.Row = row;
            this.currentHit.Col = col;

            return playfield.GetCell(row, col);
        }

        private void Hit(string symbol)
        {
            switch (symbol)
            {
                case "1":
                    this.OneHitted();
                    break;
                case "2":
                    this.TwoHitted();
                    break;
                case "3":
                    this.ThreeHitted();
                    break;
                case "4":
                    this.FourHitted();
                    break;
                case "5":
                    this.FiveHitted();
                    break;
                default:
                    break;
            }
        }

        private void OneHitted()
        {
            this.playfield.SetCell(this.currentHit, "X");
        }

        private void TwoHitted()
        {
            this.OneHitted();

            // hit rows
            for (int row = this.currentHit.Row - 1; row <= this.currentHit.Row + 1; row++)
            {
                this.HitPositionRow(row, this.currentHit.Col);
            }

            // hit cols
            for (int col = this.currentHit.Col - 1; col <= this.currentHit.Col + 1; col++)
            {
                this.HitPositionCol(this.currentHit.Row, col);
            }
        }

        private void ThreeHitted()
        {
            for (int row = this.currentHit.Row - 1; row <= this.currentHit.Row + 1; row++)
            {
                for (int col = this.currentHit.Col - 1; col <= this.currentHit.Col + 1; col++)
                {
                    if (Validator.IsInRange(row, this.playfield.Size) && Validator.IsInRange(col, this.playfield.Size))
                    {
                        this.playfield.SetCell(row, col, "X");
                    }
                }
            }
        }

        private void FourHitted()
        {
            this.ThreeHitted();

            // hit rows
            for (int row = this.currentHit.Row - 2; row <= this.currentHit.Row + 2; row++)
            {
                this.HitPositionRow(row, this.currentHit.Col);
            }

            // hit cols
            for (int col = this.currentHit.Col - 2; col <= this.currentHit.Col + 2; col++)
            {
                this.HitPositionCol(this.currentHit.Row, col);
            }
        }

        private void FiveHitted()
        {
            for (int row = this.currentHit.Row - 2; row <= this.currentHit.Row + 2; row++)
            {
                for (int col = this.currentHit.Col - 2; col <= this.currentHit.Col + 2; col++)
                {
                    if (Validator.IsInRange(row, this.playfield.Size) && Validator.IsInRange(col, this.playfield.Size))
                    {
                        this.playfield.SetCell(row, col, "X");
                    }
                }
            }
        }

        private void HitPositionRow(int row, int col)
        {
            if (Validator.IsInRange(row, this.playfield.Size))
            {
                this.playfield.SetCell(row, col, "X");
            }
        }

        private void HitPositionCol(int row, int col)
        {
            if (Validator.IsInRange(col, this.playfield.Size))
            {
                this.playfield.SetCell(row, col, "X");
            }
        }

        private void HasGameEnded()
        {
            string[] mineNumbers = { "1", "2", "3", "4", "5" };
            for (int row = 0; row < this.playfield.Size; row++)
            {
                for (int col = 0; col < this.playfield.Size; col++)
                {
                    if (mineNumbers.Contains(this.playfield.GetCell(row, col)))
                    {
                        return;
                    }
                }
            }

            this.isGameOver = true;
        }

        private void PlayTurn()
        {
            this.numberOfTurnsPlayed++;
            string symbol = this.GetSymbolFromField(this.playfield);

            while (symbol == "-" || symbol == "X")
            {
                symbol = this.GetSymbolFromField(this.playfield);
            }

            this.Hit(symbol);

            this.renderer.RenderPlayfield(this.playfield);

            this.HasGameEnded();
        }
    }
}