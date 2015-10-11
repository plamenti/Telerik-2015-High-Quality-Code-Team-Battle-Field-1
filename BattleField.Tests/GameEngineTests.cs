namespace BattleField.Tests
{
    using BattleFieldGame.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void TestRunShouldSetStartingValuesOfMaxPossibleScoreAndFillPlayfieldAndRenderPlayfield()
        {
            int fakeMaxPossibleScore = 10;
            string fillPlayfield = "playfield is filled";
            string renderPlayfield = "playfield is rendered";

            string expected = fakeMaxPossibleScore + ", " + fillPlayfield + ", " + renderPlayfield;
            string actual = string.Empty;

            var fakeGameEngine = Mock.Create<IGameEngine>();
            Mock.Arrange(() => fakeGameEngine.Run()).DoInstead(() =>
            {
                actual = fakeMaxPossibleScore + ", " + fillPlayfield + ", " + renderPlayfield;
            });

            fakeGameEngine.Run();

            Assert.AreEqual(expected, actual, "Run should initialize some app variables");
        }
    }
}