namespace BattleFieldGame
{
    using System;

    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get 
            { 
                return this.row; 
            }

            private set
            {
                if (Validator.IsPositiveNumber(value))
                {
                    throw new ArgumentOutOfRangeException("Row cannot be negative number");
                }

                this.row = value;
            }
        }

        public int Col 
        {
            get
            {
                return this.col;
            }

            private set
            {
                if (Validator.IsPositiveNumber(value))
                {
                    throw new ArgumentOutOfRangeException("Col cannot be negative number");
                }

                this.col = value;
            }
        }
    }
}