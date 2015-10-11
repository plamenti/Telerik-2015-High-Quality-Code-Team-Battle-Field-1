using BattleFieldGame;

namespace BattleField.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RandomNumberGeneratorTests
    {
        [TestMethod]
        public void TestNextMethodShouldReturnNumberBetweenMinAndMax()
        {
            int checkCount = 10;
            int min = 1;
            int max = 10;
            bool actual = true;

            RandomNumberGenerator generator = new RandomNumberGenerator();
            for (int i = 0; i < checkCount; i++)
            {
                var generatedNumber = generator.Next(min, max);
                bool result = (min <= generatedNumber && generatedNumber <= max);
                if (result == false)
                {
                    actual = false;
                    break;
                }
            }

            Assert.IsTrue(actual);
        }
    }
}