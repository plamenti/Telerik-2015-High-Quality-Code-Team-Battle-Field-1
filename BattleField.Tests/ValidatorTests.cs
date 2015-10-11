namespace BattleField.Tests
{
    using BattleFieldGame;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidatorTests
    {
        private const int MinNumber = -5;
        private const int MaxNumber = 5;
        private const int Size = 6;

        [TestMethod]
        public void TestIsNegativeNumberShouldReturnTrueIfNumberIsNegative()
        {
            int numberToTest = -1;
            bool expected = true;
            bool actual = Validator.IsNegativeNumber(numberToTest);

            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNegativeNumber method shold return true if number to test is negative.", numberToTest);
        }

        [TestMethod]
        public void TestIsNegativeNumberShouldReturnFalseIfNumberIsPositive()
        {
            int numberToTest = 1;
            bool expected = false;
            bool actual = Validator.IsNegativeNumber(numberToTest);

            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNegativeNumber method shold return false if number to test is positive.", numberToTest);
        }

        [TestMethod]
        public void TestIsNegativeNumberShouldReturnFalseIfNumberIsZero()
        {
            int numberToTest = 0;
            bool expected = false;
            bool actual = Validator.IsNegativeNumber(numberToTest);

            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNegativeNumber method shold return false if number to test is zero.", numberToTest);
        }

        [TestMethod]
        public void TestIsNegativeOrZeroNumberSholdReturnTrueIfNumberIsNegative()
        {
            int numberToTest = -1;
            bool expected = true;
            bool actual = Validator.IsNegativeOrZeroNumber(numberToTest);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNegativeOrZeroNumber method shold return true if number to test is negative.", numberToTest);
        }

        [TestMethod]
        public void TestIsNegativeOrZeroNumberSholdReturnTrueIfNumberIsZero()
        {
            int numberToTest = 0;
            bool expected = true;
            bool actual = Validator.IsNegativeOrZeroNumber(numberToTest);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNegativeOrZeroNumber method shold return true if number to test is zero.", numberToTest);
        }

        [TestMethod]
        public void TestIsNegativeOrZeroNumberSholdReturnFalseIfNumberIsPositive()
        {
            int numberToTest = 1;
            bool expected = false;
            bool actual = Validator.IsNegativeOrZeroNumber(numberToTest);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNegativeOrZeroNumber method shold return false if number to test is positive.", numberToTest);
        }

        [TestMethod]
        public void TestIsNumberBetweenSholdReturnTrueIfNumberIsBetweenMinAndMaxNumberInclusive()
        {
            int numberToTest = 1;
            bool expected = true;
            bool actual = Validator.IsNumberBetween(MinNumber, MaxNumber, numberToTest);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNumberBetween method shold return true if number to test is between MinNumber: {1} and MaxNumber: {2}.", numberToTest, MinNumber, MaxNumber);
        }

        [TestMethod]
        public void TestIsNumberBetweenSholdReturnTrueIfNumberIsEqualToMinNumber()
        {
            int numberToTest = -5;
            bool expected = true;
            bool actual = Validator.IsNumberBetween(MinNumber, MaxNumber, numberToTest);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNumberBetween method shold return true if number to test is equal to MinNumber: {1}.", numberToTest, MinNumber);
        }

        [TestMethod]
        public void TestIsNumberBetweenSholdReturnTrueIfNumberIsEqualToMaxNumber()
        {
            int numberToTest = 5;
            bool expected = true;
            bool actual = Validator.IsNumberBetween(MinNumber, MaxNumber, numberToTest);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNumberBetween method shold return true if number to test is equal to MaxNumber: {1}.", numberToTest, MaxNumber);
        }

        [TestMethod]
        public void TestIsNumberBetweenSholdReturnFalseIfNumberIsLessThanMinNumber()
        {
            int numberToTest = -6;
            bool expected = false;
            bool actual = Validator.IsNumberBetween(MinNumber, MaxNumber, numberToTest);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNumberBetween method shold return false if number to test is less than MinNumber: {1}.", numberToTest, MinNumber);
        }

        [TestMethod]
        public void TestIsNumberBetweenSholdReturnFalseIfNumberIsBiggerThanMaxNumber()
        {
            int numberToTest = 6;
            bool expected = false;
            bool actual = Validator.IsNumberBetween(MinNumber, MaxNumber, numberToTest);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsNumberBetween method shold return false if number to test is bigger than MaxNumber: {1}.", numberToTest, MaxNumber);
        }

        [TestMethod]
        public void TestIsInRangeSholdReturnTrueIfNumberIsBiggerOrEqualThanZeroAndLessThanSize()
        {
            int numberToTest = 1;
            bool expected = true;
            bool actual = Validator.IsInRange(numberToTest, Size);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsInRange method shold return true if number to test is bigger or equal to zero and less than Size: {1}.", numberToTest, Size);
        }

        [TestMethod]
        public void TestIsInRangeSholdReturnTrueIfNumberIsEqualThanZero()
        {
            int numberToTest = 0;
            bool expected = true;
            bool actual = Validator.IsInRange(numberToTest, Size);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsInRange method shold return true if number to test is equal to zero.", numberToTest);
        }

        [TestMethod]
        public void TestIsInRangeSholdReturnFalseIfNumberIsLessThanZero()
        {
            int numberToTest = -1;
            bool expected = false;
            bool actual = Validator.IsInRange(numberToTest, Size);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsInRange method shold return false if number to test is less than zero.", numberToTest);
        }

        [TestMethod]
        public void TestIsInRangeSholdReturnFalseIfNumberIsEqualToSize()
        {
            int numberToTest = 7;
            bool expected = false;
            bool actual = Validator.IsInRange(numberToTest, Size);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsInRange method shold return false if number to test is equal to Size: {1}.", numberToTest, Size);
        }

        [TestMethod]
        public void TestIsInRangeSholdReturnFalseIfNumberIsBiggerThanSize()
        {
            int numberToTest = 7;
            bool expected = false;
            bool actual = Validator.IsInRange(numberToTest, Size);
            Assert.AreEqual(expected, actual, "Number to test: {0}. IsInRange method shold return false if number to test is bigger than Size: {1}.", numberToTest, Size);
        }
    }
}