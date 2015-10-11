namespace BattleField.Tests
{
    using BattleFieldGame;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GlobalConstantsTests
    {
        [TestMethod]
        public void TestNegativeNumberMessageShouldReturnPassedPropertyNameConcatenatedWithNegativeNumberMessage()
        {
            string negativeMessage = " cannot be negative number";
            string propertyName = "Some property";
            string expected = propertyName + negativeMessage;
            string actual = GlobalConstants.NegativeNumberMessage(propertyName);

            Assert.AreEqual(expected, actual, "NegativeNumberMessage should be propertyName + negativeMessage");
        }

        [TestMethod]
        public void TestNumberOutOfRangeShouldReturnPassedPropertyNameConcatenatedWithOutOfRangeMessage()
        {
            string outOfRangeMessage = " is out of range";
            string propertyName = "Some property";
            string expected = propertyName + outOfRangeMessage;
            string actual = GlobalConstants.NumberOutOfRange(propertyName);

            Assert.AreEqual(expected, actual, "NumberOutOfRange should be propertyName + outOfRangeMessage");
        }

        [TestMethod]
        public void TestNumberBetweenMessageShouldReturnPassedMinAndMaxValuesWithNumberBetweenMessage()
        {
            string betweenMessage = "Enter a number between {0} and {1}!";
            int min = 1;
            int max = 10;
            string expected = string.Format(betweenMessage, min, max);
            string actual = GlobalConstants.NumberBetweenMessage(min, max);

            Assert.AreEqual(expected, actual, "NumberBetweenMessage should be message + min + max");
        }
    }
}