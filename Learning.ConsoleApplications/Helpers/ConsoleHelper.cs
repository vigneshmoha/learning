using System;
using System.Net;
using Learning.ConsoleApplications.Models;

namespace Learning.ConsoleApplications.Helpers
{
    public static class ConsoleHelper
    {
        public static void PrintMessage(string message, ConsoleColor colour = ConsoleColor.Green)
        {
            var previousColour = Console.ForegroundColor;
            Console.ForegroundColor = colour;

            Console.WriteLine(message);
            Console.ForegroundColor = previousColour;

        }

        public static void PrintError(string errorMessage)
        {
            PrintMessage(errorMessage, ConsoleColor.Red);
        }

        public static ModeEnum ModeEnumConverter(string enumString)
        {
            var lowercaseString = enumString.ToLower();

            switch (lowercaseString)
            {
                case "cg":
                case "consolegames":
                    return ModeEnum.ConsoleGames;
                case "t":
                case "tools":
                    return ModeEnum.Tools;
                default:
                    return ModeEnum.Default;
            }
        }
    }
}
