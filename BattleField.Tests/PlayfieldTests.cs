namespace BattleField.Tests
{
    using BattleFieldGame;
    using BattleFieldGame.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Telerik.JustMock;

    [TestClass]
    public class PlayfieldTests
    {
        [TestMethod]
        public void TestFillPlayfieldMethodShouldProperlyFillTheField()
        {
            IRandomNumberGenerator fakeRandomNumberGenerator = Mock.Create<IRandomNumberGenerator>();
            Mock.Arrange(() => fakeRandomNumberGenerator.Next(Arg.IsAny<int>(), Arg.IsAny<int>())).Returns(1);
            int PlayFieldSize = 2;
            Playfield playfield = new Playfield(PlayFieldSize);
            string[,] expected = new string[2, 2];
            expected[0, 0] = "-";
            expected[0, 1] = "-";
            expected[1, 0] = "-";
            expected[1, 1] = "1";
            playfield.FillPlayfield(fakeRandomNumberGenerator);
            string[,] actual = new string[2, 2];
            actual[0, 0] = playfield.GetCell(0, 0);
            actual[0, 1] = playfield.GetCell(0, 1);
            actual[1, 0] = playfield.GetCell(1, 0);
            actual[1, 1] = playfield.GetCell(1, 1);

            Assert.AreEqual(expected[1, 1], actual[1, 1], "At the position 1,1 in field should be 1 as string");
        }

        [TestMethod]
        public void TestGetCellMethodShouldProperlyReturnSymbol()
        {
            int PlayFieldSize = 4;
            Playfield playfield = new Playfield(PlayFieldSize);

            playfield.SetCell(0, 0, "@");
            string actual = playfield.GetCell(0, 0);
            string expected = "@";

            Assert.AreEqual(expected, actual, "At position 0,0 the symbol should be @");
        }

        [TestMethod]
        public void TestGetCellMethodShouldProperlyReturnSymbolUsingPosition()
        {
            int PlayFieldSize = 4;
            Playfield playfield = new Playfield(PlayFieldSize);
            IPosition position = new Position(0, 0);

            playfield.SetCell(position.Row, position.Col, "@");
            string actual = playfield.GetCell(position.Row, position.Col);
            string expected = "@";

            Assert.AreEqual(expected, actual, "At position 0,0 the symbol should be @");
        }

        [TestMethod]
        public void TestSetCellMethodShouldProperlySetSymbolInGridAndGetMEthodShouldReturnIt()
        {
            int PlayFieldSize = 4;
            Playfield playfield = new Playfield(PlayFieldSize);

            playfield.SetCell(0, 0, "@");
            string actual = playfield.GetCell(0, 0);
            string expected = "@";

            Assert.AreEqual(expected, actual, "At position 0,0 the symbol should be @");
        }

        [TestMethod]
        public void TestSetCellMethodUsingIPositionShouldProperlySetSymbolInGridAndGetMethodShouldReturnIt()
        {
            int PlayFieldSize = 4;
            Playfield playfield = new Playfield(PlayFieldSize);
            IPosition position = new Position(0, 0);

            playfield.SetCell(position.Row, position.Col, "@");
            string actual = playfield.GetCell(position.Row, position.Col);
            string expected = "@";

            Assert.AreEqual(expected, actual, "At position 0,0 the symbol should be @");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Size can not be bigger than 10")]
        public void TestWhenBiggerThanMaxSizeNumberIsGivenForSizeShouldThrowException()
        {
            int playfiledMinSize = 111;
            Playfield playfield = new Playfield(playfiledMinSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Size can not be less than 1")]
        public void TestWhenLessThanMinSizeNumberIsGivenForSizeShouldThrowException()
        {
            int playfiledMinSize = 0;
            Playfield playfield = new Playfield(playfiledMinSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Size can not be negative number")]
        public void TestWhenNegativeNumberIsGivenForSizeShouldThrowException()
        {
            int playfiledSize = -1;
            Playfield playfield = new Playfield(playfiledSize);
        }
    }
}