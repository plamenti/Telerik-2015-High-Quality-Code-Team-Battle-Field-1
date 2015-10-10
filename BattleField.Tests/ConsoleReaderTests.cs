namespace BattleField.Tests
{
    using BattleFieldGame.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class ConsoleReaderTests
    {
        [TestMethod]
        public void TestReadSingleNumberMethodShouldReturnIntegerParsedFromString()
        {
            string numberToParse = "1";
            int expected = 1;
            int actual = 0;
            var fakeConsoleReader = Mock.Create<IReader>();
            Mock.Arrange(() => fakeConsoleReader.ReadSingleNumber()).DoInstead(() =>
            {
                int.TryParse(numberToParse, out actual);
            });

            fakeConsoleReader.ReadSingleNumber();

            Assert.AreEqual(expected, actual, "ReadSingleNumber method should return 1 that is parsed from string.");
        }

        [TestMethod]
        public void TestReadSingleNumberMethodShouldReturnStringDescribingWhileCycleIfTryParseReturnsFalse()
        {
            string numberToParse = "Not a number";
            int parsedNumber;
            string expected = "Enter a number between 0 and 5!";
            string actual = string.Empty;
            var fakeConsoleReader = Mock.Create<IReader>();
            Mock.Arrange(() => fakeConsoleReader.ReadSingleNumber()).DoInstead(() =>
            {
                if (!int.TryParse(numberToParse, out parsedNumber))
                {
                    actual = "Enter a number between 0 and 5!";
                }
                else
                {
                    actual = "Success";
                }
            });

            fakeConsoleReader.ReadSingleNumber();

            Assert.AreEqual(expected, actual, "ReadSingleNumber method should return warning message if number to parse is invalid string.");
        }

        [TestMethod]
        public void TestReadCoordinatesMethodShouldReturnSrtingDescribingWhileInputLEngthIsNotEqualToThree()
        {
            string input = "12";
            string expected = "Please enter coordinates/row, col/ stared from zero(0), separated by whitespace: ";
            string actual = string.Empty;
            var fakeConsoleReader = Mock.Create<IReader>();
            Mock.Arrange(() => fakeConsoleReader.ReadCoordinates()).DoInstead(() =>
            {
                if (input.Length != 3)
                {
                    actual = "Please enter coordinates/row, col/ stared from zero(0), separated by whitespace: ";
                }
                else
                {
                    actual = "Success";
                }
            });

            fakeConsoleReader.ReadCoordinates();

            Assert.AreEqual(expected, actual, "ReadCoordinates Method should return warning message if length of the input is not equal to 3");
        }

        [TestMethod]
        public void TestReadCoordinatesMethodShouldReturnArrayContainingTwoIntegersParsedFromInput()
        {
            string input = "1 2";
            int[] expectedArray = { 1, 2 };
            int[] actualArray = new int[] { 0, 0 };
            var fakeConsoleReader = Mock.Create<IReader>();
            Mock.Arrange(() => fakeConsoleReader.ReadCoordinates()).DoInstead(() =>
            {
                actualArray[0] = int.Parse(input[0].ToString());
                actualArray[1] = int.Parse(input[2].ToString());
            });

            fakeConsoleReader.ReadCoordinates();

            Assert.AreEqual(expectedArray[0], actualArray[0], "First arguments should be equal");
            Assert.AreEqual(expectedArray[1], actualArray[1], "Second arguments should be equal");
        }

        public void TestReadCoordinatesMethodShouldReturnArrayWithLength2()
        {
            string input = "1 2";
            int expectedArrayLength = 2;
            int[] actualArray = new int[] { 0, 0 };
            int actualArrayLength = 0;
            var fakeConsoleReader = Mock.Create<IReader>();
            Mock.Arrange(() => fakeConsoleReader.ReadCoordinates()).DoInstead(() =>
            {
                actualArray[0] = int.Parse(input[0].ToString());
                actualArray[1] = int.Parse(input[2].ToString());
                actualArrayLength = actualArray.Length;
            });

            fakeConsoleReader.ReadCoordinates();

            Assert.AreEqual(expectedArrayLength, actualArrayLength, "Array length should be 2");
        }
    }
}