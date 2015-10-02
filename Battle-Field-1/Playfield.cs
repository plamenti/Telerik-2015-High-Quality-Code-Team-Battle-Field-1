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
                // TODO: add validation for min and max field size!
                if (Validator.IsPositiveNumber(value))
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.NegativeNumberMessage("Size"));
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