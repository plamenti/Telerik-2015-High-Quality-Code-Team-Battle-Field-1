﻿namespace BattleFieldGame
{
    using System;
    using System.Linq;
    using BattleFieldGame.Contracts;

    public class GameEngine : IGameEngine
    {
        private const string SymbolX = "X";

        //// Tectonik: currentHit can be made readonly, but I won't change it because I could break something. The person responsible for this should look over this comment, decide what to do and delete the comment
        private IPosition currentHit = new Position(0, 0);

        private bool isGameOver = false;
        private int maxPossibleScore;
        private int numberOfTurnsPlayed = 0;
        private IPlayfield playfield;
        private IRandomNumberGenerator randomNumberGenerator;
        private IReader reader;
        private IRenderer renderer;
        private int score = 0;

        public GameEngine(IRandomNumberGenerator randomNumberGenerator, IReader reader, IRenderer renderer, IPlayfield playfield)
        {
            this.randomNumberGenerator = randomNumberGenerator;
            this.reader = reader;
            this.renderer = renderer;
            this.playfield = playfield;
        }

        public void Run()
        {
            Console.Write(GlobalConstants.WelcomeMessage);

            int playfieldSize = this.reader.ReadSingleNumber();

            while (playfieldSize < GlobalConstants.MinBattleFieldSize || playfieldSize > GlobalConstants.MaxBattleFieldSize)
            {
                Console.WriteLine(GlobalConstants.NumberBetweenMessage(GlobalConstants.MinBattleFieldSize, GlobalConstants.MaxBattleFieldSize));
                playfieldSize = this.reader.ReadSingleNumber();
            }

            this.playfield = new Playfield(playfieldSize);
            this.maxPossibleScore = playfieldSize * playfieldSize;
            this.playfield.FillPlayfield(this.randomNumberGenerator);
            this.renderer.RenderPlayfield(this.playfield);

            while (!this.isGameOver)
            {
                this.PlayTurn();
            }

            this.CalculateScore();

            this.renderer.RenderMessage("Congratiolations you won in " + this.numberOfTurnsPlayed + " turns!");
            this.renderer.RenderMessage("With " + this.score + " score from " + this.maxPossibleScore + " max possible score!");
        }

        private void CalculateScore()
        {
            for (int row = 0; row < this.playfield.Size; row++)
            {
                for (int col = 0; col < this.playfield.Size; col++)
                {
                    if (this.playfield.GetCell(row, col) == SymbolX)
                    {
                        this.score++;
                    }
                }
            }
        }

        private void CheckForGameEnd()
        {
            string[] mineNumbers = { "1", "2", "3", "4", "5" };
            for (int row = 0; row < this.playfield.Size; row++)
            {
                for (int col = 0; col < this.playfield.Size; col++)
                {
                    if (mineNumbers.Contains(this.playfield.GetCell(row, col)))
                    {
                        return;
                    }
                }
            }

            this.isGameOver = true;
        }

        private void FiveHitted()
        {
            this.HitInDiameter(2);
        }

        private void FourHitted()
        {
            this.ThreeHitted();
            this.HitInCross(2);
        }

        private string GetSymbolFromField(IPlayfield playfield)
        {
            Console.WriteLine(GlobalConstants.EnterCoordinates);

            int[] coordinates = this.reader.ReadCoordinates();

            while (!(coordinates[0] >= 0 && coordinates[0] < playfield.Size
                    && coordinates[1] >= 0 && coordinates[1] < playfield.Size))
            {
                coordinates = this.reader.ReadCoordinates();
            }

            int row = coordinates[0];
            int col = coordinates[1];

            this.currentHit.Row = row;
            this.currentHit.Col = col;

            return playfield.GetCell(row, col);
        }

        private void Hit(string symbol)
        {
            switch (symbol)
            {
                case "1":
                    this.OneHitted();
                    break;

                case "2":
                    this.TwoHitted();
                    break;

                case "3":
                    this.ThreeHitted();
                    break;

                case "4":
                    this.FourHitted();
                    break;

                case "5":
                    this.FiveHitted();
                    break;

                default:
                    break;
            }
        }

        private void HitInCross(int lines)
        {
            // hit rows
            for (int row = this.currentHit.Row - lines; row <= this.currentHit.Row + lines; row++)
            {
                this.HitPositionRow(row, this.currentHit.Col);
            }

            // hit cols
            for (int col = this.currentHit.Col - lines; col <= this.currentHit.Col + lines; col++)
            {
                this.HitPositionCol(this.currentHit.Row, col);
            }
        }

        private void HitInDiameter(int lines)
        {
            for (int row = this.currentHit.Row - lines; row <= this.currentHit.Row + lines; row++)
            {
                for (int col = this.currentHit.Col - lines; col <= this.currentHit.Col + lines; col++)
                {
                    if (Validator.IsInRange(row, this.playfield.Size) && Validator.IsInRange(col, this.playfield.Size))
                    {
                        this.playfield.SetCell(row, col, SymbolX);
                    }
                }
            }
        }

        private void HitPositionCol(int row, int col)
        {
            if (Validator.IsInRange(col, this.playfield.Size))
            {
                this.playfield.SetCell(row, col, SymbolX);
            }
        }

        private void HitPositionRow(int row, int col)
        {
            if (Validator.IsInRange(row, this.playfield.Size))
            {
                this.playfield.SetCell(row, col, SymbolX);
            }
        }

        private void OneHitted()
        {
            this.playfield.SetCell(this.currentHit, SymbolX);
        }

        private void PlayTurn()
        {
            this.numberOfTurnsPlayed++;
            string symbol = this.GetSymbolFromField(this.playfield);

            while (symbol == "-" || symbol == SymbolX)
            {
                symbol = this.GetSymbolFromField(this.playfield);
            }

            this.Hit(symbol);

            this.renderer.RenderPlayfield(this.playfield);

            this.CheckForGameEnd();
        }

        private void ThreeHitted()
        {
            this.HitInDiameter(1);
        }

        private void TwoHitted()
        {
            this.OneHitted();
            this.HitInCross(1);
        }
    }
}