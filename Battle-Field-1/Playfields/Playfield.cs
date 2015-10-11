namespace BattleFieldGame.Playfields
{
    using System;
    using System.Collections.Generic;
    using BattleFieldGame.Contracts;
    using BattleFieldGame.Mementos;
    
    public abstract class Playfield : IPlayfield
    {
        private const int MaxMineNumber = 5;
        private string[,] grid;
        private int size;

        public Playfield()
        {
            this.grid = new string[this.size, this.size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            protected set
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

        public void FillPlayfield(IRandomNumberGenerator rng)
        {
            this.grid = new string[this.size, this.size];

            int minesCount = this.GetNumberOfMines();

            var mines = this.GenerateMines(rng, minesCount);

            foreach (var mine in mines)
            {
                int mineNumber = rng.Next(1, this.size);

                if (mineNumber > MaxMineNumber)
                {
                    mineNumber = MaxMineNumber;
                }

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

        public Memento SaveMemento()
        {
            return new Memento(this);
        }

        public void RestoreMemento(Memento memento)
        {
            this.grid = new string[this.size, this.size];

            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    this.grid[row, col] = memento.Grid[row, col];
                }
            }
        }

        protected abstract int GetNumberOfMines();

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