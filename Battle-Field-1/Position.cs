namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    public class Position : IPosition
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
                if (Validator.IsNegativeNumber(value))
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
                if (Validator.IsNegativeNumber(value))
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.NegativeNumberMessage("Col"));
                }

                this.col = value;
            }
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !p1.Equals(p2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Position p = obj as Position;
            if ((object)p == null)
            {
                return false;
            }

            return (this.row == p.row) && (this.col == p.col);
        }

        public bool Equals(Position p)
        {
            if ((object)p == null)
            {
                return false;
            }

            return (this.row == p.row) && (this.col == p.col);
        }

        public override int GetHashCode()
        {
            return this.row ^ this.col;
        }
    }
}