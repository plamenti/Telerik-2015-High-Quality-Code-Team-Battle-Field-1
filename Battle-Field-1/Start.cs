namespace BattleFieldGame
{
    public class Start
    {
        public static void Main()
        {
            var randomNumberGenerator = new RandomNumberGenerator();
            var reader = new ConsoleReader();
            var renderer = new ConsoleRenderer();
            var game = new GameEngine(randomNumberGenerator, reader, renderer);
            game.Run();
        }
    }
}