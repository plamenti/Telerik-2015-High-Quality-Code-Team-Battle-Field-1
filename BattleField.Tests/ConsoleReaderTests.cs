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
            string actual = "";
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
    }
}