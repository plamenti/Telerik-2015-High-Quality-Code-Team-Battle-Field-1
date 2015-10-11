namespace BattleFieldGame.Mementos
{
    using System;
    using BattleFieldGame.Playfields;

    /// <summary>
    /// Serializable class that will contains information for playfield in memento design pattern
    /// </summary>
    [Serializable]
    public class Memento
    {
        private string[,] grid;
        private int size;

        /// <summary>
        /// Set size, and copy grid from passed playfield
        /// </summary>
        /// <param name="playfield"></param>
        public Memento(Playfield playfield)
        {
            this.size = playfield.Size;
            this.grid = new string[this.size, this.size];
            this.CopyGrid(playfield);
        }

        public string[,] Grid 
        {
            get
            {
                return this.grid;
            }
        }

        private void CopyGrid(Playfield playfield)
        {
            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    this.grid[row, col] = playfield.GetCell(row, col);
                }
            }
        }
    }
}