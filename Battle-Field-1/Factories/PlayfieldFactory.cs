namespace BattleFieldGame.Factories
{
    using BattleFieldGame.Playfields;

    /// <summary>
    /// PlayfieldFactory is class for making new instance of different playfields
    /// </summary>
    public class PlayfieldFactory : IPlayfieldFactory
    {
        /// <summary>
        /// Create new instance of playfield depend of size that is passed to constructor
        /// </summary>
        /// <param name="size">Sizes are small, medium and large</param>
        /// <returns>Returns new instance of SmallPlayfield, MediumPlayfield or LargePlayfield depend of size parameter</returns>
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