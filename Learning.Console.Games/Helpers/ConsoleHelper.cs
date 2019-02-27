using System;

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
    }
}
