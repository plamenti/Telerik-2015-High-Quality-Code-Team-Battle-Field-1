namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Factories;
    using BattleFieldGame.Playfields;

    public class Start
    {
        private const string WelcomeMessage = "Welcome to \"Battle Field game.\". Commands from which you can choose are: \n\rNew game\n\rLoad game\n\rExit\n\r";
        private const string ChooseSizeMessage = "Enter size of field \n\rSmall\n\rMedium\n\rLarge\n\r";

        public static void Main()
        {
            Console.WriteLine(WelcomeMessage);

            string input = Console.ReadLine();

            ProceedCommand(input);
        }

        private static void ProceedCommand(string command)
        {
            switch (command)
            {
                case "New game":
                    var randomNumberGenerator = new RandomNumberGenerator();
                    var reader = new ConsoleReader();
                    var renderer = new ConsoleRenderer();
                    var factory = new PlayfieldFactory();
                    Playfield playfield;
                    Console.Clear();
                    Console.WriteLine(ChooseSizeMessage);

                    string size = Console.ReadLine();

                    playfield = factory.CreatePlayfield(size);

                    if (playfield == null)
                    {
                        Console.Clear();
                        Console.WriteLine(ChooseSizeMessage);
                        ProceedCommand("New game");
                    }
                    else
                    {
                        var game = new GameEngine(randomNumberGenerator, reader, renderer, playfield);
                        game.Run();
                    }

                    break;
                case "Load game":
                    throw new NotImplementedException();
                case "Exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(WelcomeMessage);
                    ProceedCommand(Console.ReadLine());
                    break;
            }
        }
    }
}