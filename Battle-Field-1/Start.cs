namespace BattleFieldGame
{
    using BattleFieldGame.Playfields;

    public class Start
    {
        public static void Main()
        {
            var randomNumberGenerator = new RandomNumberGenerator();
            var reader = new ConsoleReader();
            var renderer = new ConsoleRenderer();
            var playfield = new SmallPlayfield();
            var game = new GameEngine(randomNumberGenerator, reader, renderer, playfield);
            game.Run();
        }
    }
}