namespace BattleFieldGame.Playfields
{
    using System;
    using System.Collections.Generic;
    using BattleFieldGame.Contracts;
    using BattleFieldGame.Mementos;
    
    /// <summary>
    /// Abstract class for playfield in game
    /// </summary>
    public abstract class Playfield : IPlayfield
    {
        private const int MaxMineNumber = 5;
        private string[,] grid;
        private int size;

        /// <summary>
        /// Constructor set the grid by the size of playfield
        /// </summary>
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

        /// <summary>
        /// Get the symbol of grir by position
        /// </summary>
        /// <param name="position">Defines which position of grid should be returned</param>
        /// <returns>Returns string representaion of the symbol of this position in grid</returns>
        public string GetCell(IPosition position)
        {
            return this.grid[position.Row, position.Col];
        }

        /// <summary>
        /// Get the symbol of grir by position
        /// </summary>
        /// <param name="row">Defines row in the grid</param>
        /// <param name="col">Defines col in the grid</param>
        /// <returns>Returns string representaion of the symbol of this position in grid</returns>
        public string GetCell(int row, int col)
        {
            return this.grid[row, col];
        }
        
        /// <summary>
        /// Set new symbol for this position in the grid
        /// </summary>
        /// <param name="position">Defines on which position of grid should be set new symbol</param>
        /// <param name="symbol">Defines the new symbol</param>
        public void SetCell(IPosition position, string symbol)
        {
            this.grid[position.Row, position.Col] = symbol;
        }

        /// <summary>
        /// Set new symbol for this position in the grid
        /// </summary>
        /// <param name="row">Defines row in the grid</param>
        /// <param name="col">Defines col in the grid</param>
        /// <param name="symbol">Defines the new symbol</param>
        public void SetCell(int row, int col, string symbol)
        {
            this.grid[row, col] = symbol;
        }

        /// <summary>
        /// Fill grid with '-' and numbers for bombs
        /// </summary>
        /// <param name="rng">Random number generator for random generate positions of mines</param>
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

        /// <summary>
        /// Method that saves current state of playfield in memento object
        /// </summary>
        /// <returns>New memento object with current state of playfield</returns>
        public Memento SaveMemento()
        {
            return new Memento(this);
        }

        /// <summary>
        /// Restote previous saved state of playfield
        /// </summary>
        /// <param name="memento">Memento object that will restore previous state of playfield</param>
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