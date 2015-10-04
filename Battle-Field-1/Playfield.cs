namespace BattleFieldGame
{
    using System;
    using System.Collections.Generic;
    using BattleFieldGame.Contracts;

    public class Playfield
    {
        private string[,] grid;
        private int size;

        public Playfield(int size, IRandomNumberGenerator rng)
        {
            this.Size = size;
            this.grid = new string[size, size];
            this.FillPlayfield(rng);
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (Validator.IsNegativeOrZeroNumber(value))
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.NegativeNumberMessage("Size"));
                }

                if (!Validator.IsNumberBetween(GlobalConstants.MinBattleFieldSize, GlobalConstants.MaxBattleFieldSize, value))
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.NumberOutOfRange("Size"));
                }

                this.size = value;
            }
        }

        public string GetCell(IPosition position)
        {
            return this.grid[position.Row, position.Col];
        }

        public string GetCell(int row, int col)
        {
            return this.grid[row, col];
        }

        public void SetCell(IPosition position, string symbol)
        {
            this.grid[position.Row, position.Col] = symbol;
        }

        public void SetCell(int row, int col, string symbol)
        {
            this.grid[row, col] = symbol;
        }

        private void FillPlayfield(IRandomNumberGenerator rng)
        {
            int minPercent = Convert.ToInt32(GlobalConstants.MinPercent * (this.size * this.size));
            int maxPercent = Convert.ToInt32(GlobalConstants.MaxPercent * (this.size * this.size));
            int minesCount = rng.Next(minPercent, maxPercent);

            var mines = this.GenerateMines(rng, minesCount);

            foreach (var mine in mines)
            {
                int mineNumber = rng.Next(1, this.size);
                this.SetCell(mine, mineNumber.ToString());
            }

            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    if (this.GetCell(row, col) == null)
                    {
                        this.SetCell(row, col, "-");
                    }
                }
            }
        }

        private HashSet<IPosition> GenerateMines(IRandomNumberGenerator rng, int minesCount)
        {
            var mines = new HashSet<IPosition>();

            while (mines.Count != minesCount)
            {
                int row = rng.Next(0, this.size);
                int col = rng.Next(0, this.size);
                var position = new Position(row, col);
                mines.Add(position);
            }

            return mines;
        }
    }
}