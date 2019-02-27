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

            try
            {
                var parserResult = Parser.Default.ParseArguments<Options>(args);
                parserResult.WithParsed(options =>
                {
                    Enum.TryParse(options.Mode, out ModeEnum option);
                    switch (option)
                    {
                        case ModeEnum.ConsoleGames:
                            ShowConsoleGames();
                            var gameOption = Convert.ToInt16(Console.ReadLine());
                            var game = new ConsoleGamesFactory().GetConsoleGameObject(gameOption);
                            game.Run();
                            break;
                        case ModeEnum.Tools:
                            break;
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
            var gameMenu = "*** List of Games ***1. Play with a star";

            ConsoleHelper.PrintMessage(gameMenu);
        }

        #endregion
    }
}
