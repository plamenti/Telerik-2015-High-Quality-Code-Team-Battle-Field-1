namespace BattleField
{
    using System;

    public class Start
    {
        public static void Main(string[] argumenti)
        {
            var game = new GameEngine();
            game.Run();
        }
    }
}