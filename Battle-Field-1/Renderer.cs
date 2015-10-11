namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Contracts;

    /// <summary>
    /// Class for easier render in Console
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Render playfield classes on Console
        /// </summary>
        /// <param name="playfield">The playfield that will be draw on Console</param>
        public void RenderPlayfield(IPlayfield playfield)
        {
            for (int row = 0; row < playfield.Size + GlobalConstants.BorderSize; row++)
            {
                for (int col = 0; col < playfield.Size + GlobalConstants.BorderSize; col++)
                {
                    if (row == 0)
                    {
                        if (col == 0)
                        {
                            this.RenderSingleSymbol(" ");
                        }

                        if (col == 1)
                        {
                            this.RenderSingleSymbol(" ");
                        }

                        if (col > 1)
                        {
                            this.RenderSingleSymbol((col - GlobalConstants.BorderSize).ToString());
                        }
                    }

                    if (row == 1)
                    {
                        if (col == 0)
                        {
                            this.RenderSingleSymbol(" ");
                        }

                        if (col == 1)
                        {
                            this.RenderSingleSymbol(" ");
                        }

                        if (col > 1)
                        {
                            this.RenderSingleSymbol("_");
                        }
                    }

                    if (row > 1)
                    {
                        if (col == 0)
                        {
                            this.RenderSingleSymbol((row - GlobalConstants.BorderSize).ToString());
                        }

                        if (col == 1)
                        {
                            this.RenderSingleSymbol("|");
                        }

                        if (col > 1)
                        {
                            Console.Write("{0, 2}", playfield.GetCell(row - GlobalConstants.BorderSize, col - GlobalConstants.BorderSize));
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Render message on Console
        /// </summary>
        /// <param name="message">Message that will be renderer on Console</param>
        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void RenderSingleSymbol(string symbol)
        {
            Console.Write("{0, 2}", symbol);
        }
    }
}