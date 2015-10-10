﻿namespace BattleFieldGame.Playfields
{
    public class SmallPlayfield : Playfield
    {
        private const int NumberOfMines = 2;

        public SmallPlayfield()
            : base()
        {
            this.Size = 3;
        }

        protected override int GetNumberOfMines()
        {
            return NumberOfMines;
        }
    }
}