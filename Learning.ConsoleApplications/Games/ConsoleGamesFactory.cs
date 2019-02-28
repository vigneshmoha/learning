using System;
using Learning.ConsoleApplications.Games.Concrete;

namespace Learning.ConsoleApplications.Games
{
    public class ConsoleGamesFactory
    {
        public virtual IConsoleGames GetConsoleGameObject(int gameIdentifier)
        {
            IConsoleGames consoleGameObject;

            switch (gameIdentifier)
            {
                case 1:
                    consoleGameObject = new PlayWithStar();
                    break;
                case 2:
                    consoleGameObject = new CatchTheObject();
                    break;
                case 3:
                    consoleGameObject = new TicTacToe();
                    break;
                default:
                    throw new Exception("No games found for your inputs");
            }

            return consoleGameObject;
        }
    }
}
