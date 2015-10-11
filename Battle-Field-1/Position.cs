namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    /// <summary>
    /// Class that holds information for row and col of position
    /// </summary>
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

            set
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

            set
            {
                if (Validator.IsNegativeNumber(value))
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.NegativeNumberMessage("Col"));
                }

                this.col = value;
            }
        }

        /// <summary>
        /// Use Equals method of Position for compare two positions
        /// </summary>
        /// <param name="p1">First position</param>
        /// <param name="p2">Second position</param>
        /// <returns>Are this two positions are equal</returns>
        public static bool operator ==(Position p1, Position p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        /// Use Equals method of Position for compare two positions
        /// </summary>
        /// <param name="p1">First position</param>
        /// <param name="p2">Second position</param>
        /// <returns>Are this two positions are different</returns>
        public static bool operator !=(Position p1, Position p2)
        {
            return !p1.Equals(p2);
        }

        /// <summary>
        /// Check if two positions are equal based on their row and col
        /// </summary>
        /// <param name="obj">Object that is compared with this position</param>
        /// <returns>Are this two positions are equal</returns>
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

        /// <summary>
        /// Check if two positions are equal based on their row and col
        /// </summary>
        /// <param name="p">Position that is compared with this position</param>
        /// <returns>Are this two positions are equal</returns>
        public bool Equals(Position p)
        {
            if ((object)p == null)
            {
                return false;
            }

            return (this.row == p.row) && (this.col == p.col);
        }

        /// <summary>
        /// Get 'unique' hash code based on row xor col
        /// </summary>
        /// <returns>Hash code of this position</returns>
        public override int GetHashCode()
        {
            return this.row ^ this.col;
        }
    }
}