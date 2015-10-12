namespace BattleFieldGame
{
    using System;
    using BattleFieldGame.Factories;
    using BattleFieldGame.FileCares;
    using BattleFieldGame.Playfields;

    /// <summary>
    /// Entry point of application
    /// </summary>
    public class Start
    {
        private const string WelcomeMessage = "Welcome to \"Battle Field game.\". Commands from which you can choose are: \n\rNew game\n\rLoad game\n\rExit\n\r";
        private const string ChooseSizeMessage = "Enter size of field \n\rSmall\n\rMedium\n\rLarge\n\r";
        private const string GameLocation = "..\\..\\myGame.bin";

        /// <summary>
        /// Entry point of application that starts game
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(WelcomeMessage);

            string input = Console.ReadLine();

            ProceedCommand(input);
        }

        private static void ProceedCommand(string command)
        {
            var randomNumberGenerator = new RandomNumberGenerator();
            var reader = new ConsoleReader();
            var renderer = new ConsoleRenderer();
            var factory = new PlayfieldFactory();

            switch (command)
            {
                case "New game":                   
                    Playfield playfield;
                    Console.Clear();
                    Console.WriteLine(ChooseSizeMessage);

                    string size = Console.ReadLine();

                    playfield = factory.CreatePlayfield(size);
                    playfield.FillPlayfield(randomNumberGenerator);

                    if (playfield == null)
                    {
                        Console.Clear();
                        Console.WriteLine(ChooseSizeMessage);
                        ProceedCommand("New game");
                    }
                    else
                    {
                        var game = new GameEngine(reader, renderer, playfield);
                        game.Run();
                    }

                    break;
                case "Load game":
                    try
                    {
                        var fileSerializer = new FileSerializer();
                        var memento = fileSerializer.DeserializeObject(GameLocation);
                        playfield = factory.CreatePlayfield(ConvertNumberToString(memento.Grid.GetLength(0)));
                        playfield.RestoreMemento(memento);
                        
                        var game = new GameEngine(reader, renderer, playfield);
                        game.Run();
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(WelcomeMessage);
                        ProceedCommand(Console.ReadLine());
                    }

                    break;
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

        private static string ConvertNumberToString(int number)
        {
            if (number == 3)
            {
                return "Small";
            }
            else if (number == 5)
            {
                return "Medium";
            }
            else
            {
                return "Large";
            }
        }
    }
}
