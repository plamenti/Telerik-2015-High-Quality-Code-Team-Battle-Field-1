namespace BattleFieldGame.Playfields
{
    public class MediumPlayfield : Playfield
    {
        private const int NumberOfMines = 5;

        public MediumPlayfield()
            : base()
        {
            this.Size = 5;
        }

        protected override int GetNumberOfMines()
        {
            return NumberOfMines;
        }
    }
}