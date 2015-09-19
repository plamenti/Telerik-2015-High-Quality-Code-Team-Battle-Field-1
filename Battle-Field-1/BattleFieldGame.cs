namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BattleFieldGame
    {
        public static void Main(string[] argumenti)
        {
            var game = new BattlefieldGameEngine();
            game.Run();
        }
    }
}