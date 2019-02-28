using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Learning.ConsoleApplications.Games
{
    public class ConsoleGamesFactory
    {
        public virtual IConsoleGames GetConsoleGameObject(int gameIdentifier)
        {
            IConsoleGames consoleGameObject = null;

            switch (gameIdentifier)
            {
                case 1:
                    consoleGameObject = new PlayWithStar();
                    break;
                default:
                    throw new Exception("No games found for your inputs");
            }

            return consoleGameObject;
        }
    }
}
