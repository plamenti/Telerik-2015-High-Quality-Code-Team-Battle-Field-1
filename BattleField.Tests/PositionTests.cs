namespace BattleField.Tests
{
    using System;
    using BattleFieldGame;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Col can not be negative")]
        public void TestColPropertyShouldThrowIfNegativeNumberIsGiven()
        {
            var position = new Position(1, -1);
        }

        [TestMethod]
        public void TestEqualsMethodShouldReturnFalseIfSecondPositionObjectsIsNull()
        {
            var firstPosition = new Position(1, 1);

            var expected = false;
            var actual = firstPosition.Equals(null);

            Assert.AreEqual(expected, actual, "Method Equals should return false if the second Position objects is null");
        }

        [TestMethod]
        public void TestEqualsMethodShouldReturnFalseIfTwoPositionObjectsAreNotEqual()
        {
            var firstPosition = new Position(1, 1);
            var secondPosition = new Position(1, 2);

            var expected = false;
            var actual = firstPosition.Equals(secondPosition);

            Assert.AreEqual(expected, actual, "Method Equals should return false if two Position objects are not equal");
        }

        [TestMethod]
        public void TestEqualsMethodShouldReturnTrueIfTwoPositionObjectsAreEqual()
        {
            var firstPosition = new Position(1, 1);
            var secondPosition = new Position(1, 1);

            var expected = true;
            var actual = firstPosition.Equals(secondPosition);

            Assert.AreEqual(expected, actual, "Method Equals should return true if two Position objects are equal");
        }

        [TestMethod]
        public void TestEqualsOperatorShouldReturnFalseIfTwoPositionObjectsAreNotEqual()
        {
            var firstPosition = new Position(1, 1);
            var secondPosition = new Position(1, 2);

            var expected = false;
            var actual = firstPosition == secondPosition;

            Assert.AreEqual(expected, actual, "Operator == should return false if two Position objects are not equal");
        }

        [TestMethod]
        public void TestEqualsOperatorShouldReturnTrueIfTwoPositionObjectsAreEqual()
        {
            var firstPosition = new Position(1, 1);
            var secondPosition = new Position(1, 1);

            var expected = true;
            var actual = firstPosition == secondPosition;

            Assert.AreEqual(expected, actual, "Operator == should return true if two Position objects are equal");
        }

        [TestMethod]
        public void TestGetHashCodeMethodShouldReturnProperlyHashValue()
        {
            int row = 1;
            int col = 2;
            var position = new Position(row, col);
            var expected = row ^ col;
            var actual = position.GetHashCode();

            Assert.AreEqual(expected, actual, "GetHashCode method should calculate properly hash value");
        }

        [TestMethod]
        public void TestNotEqualsOperatorShouldReturnFalseIfTwoPositionObjectsAreEqual()
        {
            var firstPosition = new Position(1, 1);
            var secondPosition = new Position(1, 1);

            var expected = false;
            var actual = firstPosition != secondPosition;

            Assert.AreEqual(expected, actual, "Operator != should return false if two Position objects are equal");
        }

        [TestMethod]
        public void TestNotEqualsOperatorShouldReturnTrueIfTwoPositionObjectsAreNotEqual()
        {
            var firstPosition = new Position(1, 1);
            var secondPosition = new Position(1, 2);

            var expected = true;
            var actual = firstPosition != secondPosition;

            Assert.AreEqual(expected, actual, "Operator != should return true if two Position objects are not equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row can not be negative")]
        public void TestRowPropertyShouldThrowIfNegativeNumberIsGiven()
        {
            var position = new Position(-1, 1);
        }
    }
}