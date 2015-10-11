namespace BattleField.Tests
{
    using BattleFieldGame.Factories;
    using BattleFieldGame.Playfields;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayfieldFactoryTests
    {
        [TestMethod]
        public void TestCreatePlayfieldWithSmallAsParameterShouldCreateNewSmallPlayfieldObject()
        {
            string typeOfPlayfield = "small";
            IPlayfieldFactory factory = new PlayfieldFactory();
            var playfield = factory.CreatePlayfield(typeOfPlayfield);
            var actual = playfield.GetType() == typeof(SmallPlayfield);

            Assert.IsTrue(actual, "CreatePlayfield with small as argument should create new SmallPlayfield Object");
        }

        [TestMethod]
        public void TestCreatePlayfieldWithMediumAsParameterShouldCreateNewMediumPlayfieldObject()
        {
            string typeOfPlayfield = "medium";
            IPlayfieldFactory factory = new PlayfieldFactory();
            var playfield = factory.CreatePlayfield(typeOfPlayfield);
            var actual = playfield.GetType() == typeof(MediumPlayfield);

            Assert.IsTrue(actual, "CreatePlayfield with medium as argument should create new MediumPlayfield Object");
        }

        [TestMethod]
        public void TestCreatePlayfieldWithLargeAsParameterShouldCreateNewLargePlayfieldObject()
        {
            string typeOfPlayfield = "large";
            IPlayfieldFactory factory = new PlayfieldFactory();
            var playfield = factory.CreatePlayfield(typeOfPlayfield);
            var actual = playfield.GetType() == typeof(LargePlayfield);

            Assert.IsTrue(actual, "CreatePlayfield with large as argument should create new LargePlayfield Object");
        }

        [TestMethod]
        public void TestCreatePlayfieldWithSomeDifferentAsParameterShouldCreateNull()
        {
            string typeOfPlayfield = "wrong";
            IPlayfieldFactory factory = new PlayfieldFactory();
            var playfield = factory.CreatePlayfield(typeOfPlayfield);

            Assert.IsNull(playfield, "CreatePlayfield with wrong argument should create null ");
        }
    }
}