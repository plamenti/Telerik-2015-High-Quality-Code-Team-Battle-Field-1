namespace BattleFieldGame.Factories
{
    using BattleFieldGame.Playfields;

    public class PlayfieldFactory : IPlayfieldFactory
    {
        public Playfield CreatePlayfield(string size)
        {
            switch (size.ToLower())
            {
                case "small":
                    return this.CreateSmallPlayfield();
                case "medium":
                    return this.CreateMediumPlayfield();
                case "large":
                    return this.CreateLargePlayfield();
                default:
                    return null;
            }
        }

        private SmallPlayfield CreateSmallPlayfield()
        {
            return new SmallPlayfield();
        }

        private MediumPlayfield CreateMediumPlayfield()
        {
            return new MediumPlayfield();
        }

        private LargePlayfield CreateLargePlayfield()
        {
            return new LargePlayfield();
        }
    }
}