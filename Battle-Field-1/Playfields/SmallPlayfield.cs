namespace BattleFieldGame.Playfields
{
    public class SmallPlayfield : Playfield
    {
        private const int NumberOfMines = 3;

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