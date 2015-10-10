namespace BattleFieldGame.Factories
{
    using BattleFieldGame.Playfields;

    public class PlayfieldFactory
    {
        public SmallPlayfield CreateSmallPlayfield()
        {
            return new SmallPlayfield();
        }

        public MediumPlayfield CreateMediumPlayfield()
        {
            return new MediumPlayfield();
        }

        public LargePlayfield CreateLargePlayfield()
        {
            return new LargePlayfield();
        }
    }
}