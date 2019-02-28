using System;
using CommandLine;
using Learning.ConsoleApplications.Configuration;
using Learning.ConsoleApplications.Games;
using Learning.ConsoleApplications.Helpers;
using Learning.ConsoleApplications.Models;

namespace Learning.ConsoleApplications
{
    class Program
    {

        static void Main(string[] args)
        {
            RegisterDependencies();

            Console.Write("Enter debugging mode..");
            Console.ReadLine();

            try
            {
                var parserResult = Parser.Default.ParseArguments<Options>(args);
                parserResult.WithParsed(options =>
                {
                    var mode = ConsoleHelper.ModeEnumConverter(options.Mode);
                    
                    switch (mode)
                    {
                        case ModeEnum.ConsoleGames:
                            ShowConsoleGames();
                            var gameOption = Convert.ToInt16(Console.ReadLine());
                            var game = new ConsoleGamesFactory().GetConsoleGameObject(gameOption);
                            game.Run();
                            break;
                        case ModeEnum.Tools:
                            break;
                        case ModeEnum.Default:
                            throw new Exception("Mode not found..");
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                });
            }
            catch (Exception ex)
            {
                ConsoleHelper.PrintError($"Error - {ex.Message}");
            }
            finally
            {
                Environment.Exit(0);
            }
        }

        #region Private Methods
        private static void RegisterDependencies()
        {
            StructureMapConfiguration.RegiterDependencies();
        }

        private static void ShowConsoleGames()
        {
            var gameMenu = "*** List of Games *** \n 1. Play with a star \n 2. Catch the objects";

            ConsoleHelper.PrintMessage(gameMenu);
        }

        #endregion
    }
}
