namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    public class Playfield
    {
        private char[,] grid;
        private int size;

        public Playfield(int size)
        {
            this.grid = new char[size, size];
            this.Size = size;
        }

        public int Size 
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (Validator.IsPositiveNumber(value))
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.NegativeNumberMessage("Size"));
                }

                if (Validator.IsNumberBetween(GlobalConstants.MinBattleFieldSize, GlobalConstants.MaxBattleFieldSize, value))
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.NumberOutOfRange("Size"));
                }

                this.size = value;
            }
        }

        public char GetCell(IPosition position)
        {
            return this.grid[position.Row, position.Col];
        }

        public void SetCell(IPosition position, char symbol)
        {
            this.grid[position.Row, position.Col] = symbol;
        }
    }
}