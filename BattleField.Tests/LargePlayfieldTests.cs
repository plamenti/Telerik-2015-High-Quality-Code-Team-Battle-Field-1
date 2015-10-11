namespace BattleField.Tests
{
    using BattleFieldGame;
    using BattleFieldGame.Contracts;
    using BattleFieldGame.Playfields;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LargePlayfieldTests
    {
        [TestMethod]
        public void TestLargePlayfieldGetCellMethodShouldProperlyReturnSymbol()
        {
            var playfield = new LargePlayfield();
            var rng = new RandomNumberGenerator();
            playfield.FillPlayfield(rng);

            playfield.SetCell(0, 0, "@");
            string actual = playfield.GetCell(0, 0);
            string expected = "@";

            Assert.AreEqual(expected, actual, "At position 0,0 the symbol should be @");
        }

        [TestMethod]
        public void TestLargePlayfieldGetCellMethodShouldProperlyReturnSymbolUsingPosition()
        {
            var playfield = new LargePlayfield();
            IPosition position = new Position(0, 0);

            var rng = new RandomNumberGenerator();
            playfield.FillPlayfield(rng);

            playfield.SetCell(position.Row, position.Col, "@");
            string actual = playfield.GetCell(position.Row, position.Col);
            string expected = "@";

            Assert.AreEqual(expected, actual, "At position 0,0 the symbol should be @");
        }

        [TestMethod]
        public void TestLargePlayfieldSetCellMethodShouldProperlySetSymbolInGridAndGetMEthodShouldReturnIt()
        {
            var playfield = new LargePlayfield();

            var rng = new RandomNumberGenerator();
            playfield.FillPlayfield(rng);

            playfield.SetCell(0, 0, "@");
            string actual = playfield.GetCell(0, 0);
            string expected = "@";

            Assert.AreEqual(expected, actual, "At position 0,0 the symbol should be @");
        }

        [TestMethod]
        public void TestLargePlayfieldSetCellMethodUsingIPositionShouldProperlySetSymbolInGridAndGetMethodShouldReturnIt()
        {
            var playfield = new LargePlayfield();
            IPosition position = new Position(0, 0);

            var rng = new RandomNumberGenerator();
            playfield.FillPlayfield(rng);

            playfield.SetCell(position.Row, position.Col, "@");
            string actual = playfield.GetCell(position.Row, position.Col);
            string expected = "@";

            Assert.AreEqual(expected, actual, "At position 0,0 the symbol should be @");
        }
    }
}