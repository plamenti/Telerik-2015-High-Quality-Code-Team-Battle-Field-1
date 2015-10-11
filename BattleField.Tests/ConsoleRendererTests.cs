using System;
using BattleFieldGame.Contracts;
using BattleFieldGame.Playfields;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace BattleField.Tests
{
    [TestClass]
    public class ConsoleRendererTests
    {
        [TestMethod]
        public void TestRenderMessageShouldWriteMessageToTheConsole()
        {
            string message = "Hello, World!";
            string expected = "Hello, World!";
            string actual = string.Empty;
            var fakeConsoleRenderer = Mock.Create<IRenderer>();
            Mock.Arrange(() => fakeConsoleRenderer.RenderMessage(Arg.IsAny<string>())).DoInstead((string arg) =>
            {
                actual = arg;
            });

            fakeConsoleRenderer.RenderMessage(message);

            Assert.AreEqual(expected, actual, "RenderMessage method should return readed messege");
        }

        [TestMethod]
        public void TestRenderSingleSymbolShouldWriteRenderedSymbolToTheConsole()
        {
            string message = "@";
            string expected = " @";
            string actual = string.Empty;
            var fakeConsoleRenderer = Mock.Create<IRenderer>();
            Mock.Arrange(() => fakeConsoleRenderer.RenderMessage(Arg.IsAny<string>())).DoInstead((string arg) =>
            {
                actual = " " + arg;
            });

            fakeConsoleRenderer.RenderMessage(message);

            Assert.AreEqual(expected, actual, "RenderSingleSymbol method should return rendered symbol");
        }

        [TestMethod]
        public void TestRenderPlayfieldShouldRenderAndFillGivenAsParameterField()
        {
            var playFieldToRender = new SmallPlayfield();

            var fakeConsoleRenderer = Mock.Create<IRenderer>();
            Mock.Arrange(() => fakeConsoleRenderer.RenderPlayfield(Arg.IsAny<IPlayfield>())).DoNothing();

            fakeConsoleRenderer.RenderPlayfield(playFieldToRender);
        }
    }
}