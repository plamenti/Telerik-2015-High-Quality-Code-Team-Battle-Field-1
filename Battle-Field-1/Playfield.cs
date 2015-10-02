namespace BattleFieldGame
{
    using System;

    public class Playfield
    {
        private char[,] grid;
        private int size;

        public Playfield(int size)
        {
            this.grid = new char[size, size];
            this.size = size;
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
                    throw new ArgumentOutOfRangeException("Size cannot be negative number");
                }

                this.size = value;
            }
        }
    }
}