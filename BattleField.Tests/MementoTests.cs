namespace BattleField.Tests
{
    using System;
    using BattleFieldGame;
    using BattleFieldGame.Mementos;
    using BattleFieldGame.Playfields;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MementoTests
    {
        [TestMethod]
        public void TestConstructorShouldCopyCorrectPlayfield()
        {
            var rng = new RandomNumberGenerator();
            var playfield = new SmallPlayfield();
            playfield.FillPlayfield(rng);

            var memento = new Memento(playfield);
            bool areEqual = true;

            for (int row = 0; row < playfield.Size; row++)
            {
                for (int col = 0; col < playfield.Size; col++)
                {
                    if (playfield.GetCell(row, col) != memento.Grid[row, col])
                    {
                        areEqual = false;
                    }
                }
            }

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestConstructorWhenPassNullShouldThrowException()
        {
            var rng = new RandomNumberGenerator();
            SmallPlayfield playfield = null;

            var memento = new Memento(playfield);
        }
    }
}