namespace BattleFieldGame.Playfields
{
    public class LargePlayfield : Playfield
    {
        private const int NumberOfMines = 16;

        public LargePlayfield()
            : base()
        {
            this.Size = 10;
        }

        protected override int GetNumberOfMines()
        {
            return NumberOfMines;
        }
    }
}