namespace BattleFieldGame
{
    using BattleFieldGame.Factories;
    using BattleFieldGame.Playfields;

    public class Start
    {
        public static void Main()
        {
            var randomNumberGenerator = new RandomNumberGenerator();
            var reader = new ConsoleReader();
            var renderer = new ConsoleRenderer();
            var factory = new PlayfieldFactory();
            var playfield = factory.CreatePlayfield("small");
            var game = new GameEngine(randomNumberGenerator, reader, renderer, playfield);
            game.Run();
        }
    }
}