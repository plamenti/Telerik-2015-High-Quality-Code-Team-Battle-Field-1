namespace BattleFieldGame
{
    public class Start
    {
        public static void Main()
        {
            var randomNumberGenerator = new RandomNumberGenerator();
            var reader = new ConsoleReader();
            var renderer = new ConsoleRenderer();
            var playfield = new Playfield(5);
            var game = new GameEngine(randomNumberGenerator, reader, renderer, playfield);
            game.Run();
        }
    }
}