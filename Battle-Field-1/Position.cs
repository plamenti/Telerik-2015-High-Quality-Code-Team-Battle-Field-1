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
                    throw new ArgumentOutOfRangeException(GlobalConstants.NegativeNumberMessage("Row"));
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
                    throw new ArgumentOutOfRangeException(GlobalConstants.NegativeNumberMessage("Col"));
                }

                this.col = value;
            }
        }
    }
}