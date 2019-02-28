using System;
using System.Threading;

namespace Learning.ConsoleApplications.Games.Concrete
{
    public class TicTacToe : IConsoleGames
    {
        private static char[] array = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private static bool gameOver = false;
        private static bool gameDrawn = false;
        private static int playerInfo = 1;
        private static int choice;

        private const char playerOne = 'X';
        private const char playerTwo = 'O';

        public void Run()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("**** Welcome to Tic Tac Toe ****\n");
                Console.WriteLine($"Player 1: {playerOne} \nPlayer 2: {playerTwo}");
                Console.WriteLine("\n");

                DrawTicTacToeBoard();

                Console.WriteLine("\n");
                var currentPlayer = (playerInfo % 2 == 0) ? "2" : "1";
                Console.WriteLine($"Player {currentPlayer} chance, Please enter the choice and type ENTER:");
                choice = int.Parse(Console.ReadLine());

                if (choice <= 0 || choice > array.Length)
                {
                    ResetTheBoard($"Sorry selected position {choice} is not available.. Please provide valid position..");

                    continue;
                }

                if (array[choice - 1] != 'X' && array[choice - 1] != 'O')
                {
                    var charValue = (playerInfo % 2 == 0) ? playerTwo : playerOne;
                    array[choice - 1] = charValue;

                    playerInfo++;
                }
                else
                {
                    ResetTheBoard($"Sorry selected position {choice} is already marked with {array[choice]}");
                }

                gameOver = CheckWinOrDraw();
            } while (!gameOver && !gameDrawn);

            Console.Clear();
            DrawTicTacToeBoard();

            if (gameOver && !gameDrawn)
            {
                Console.WriteLine($"Player {(playerInfo % 2) + 1} has won the match..");
                Console.WriteLine("Congratulations....! :) (Y)");
            }
            else
            {
                Console.WriteLine("Match has drawn.. Please restart..");
            }

            Console.ReadLine();
        }

        private static void DrawTicTacToeBoard()
        {
            Console.WriteLine(" _________________ ");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine($"|  {array[0]}  |  {array[1]}  |  {array[2]}  |");
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine($"|  {array[3]}  |  {array[4]}  |  {array[5]}  |");
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine($"|  {array[6]}  |  {array[7]}  |  {array[8]}  |");
            Console.WriteLine("|_____|_____|_____|");
        }

        private static bool CheckWinOrDraw()
        {
            var firstRow = array[0] == array[1] && array[1] == array[2];
            var secondRow = array[3] == array[4] && array[4] == array[5];
            var thirdRow = array[6] == array[7] && array[7] == array[8];

            var firstColumn = array[0] == array[3] && array[3] == array[6];
            var secondColumn = array[1] == array[4] && array[4] == array[7];
            var thirdColumn = array[2] == array[5] && array[5] == array[8];

            var leftDiagnol = array[0] == array[4] && array[4] == array[8];
            var rightDiagnol = array[2] == array[4] && array[4] == array[6];

            if (firstRow || secondRow || thirdRow || firstColumn || secondColumn || thirdColumn || leftDiagnol || rightDiagnol)
            {
                return true;
            }

            foreach (var element in array)
            {
                if (element != playerOne && element != playerTwo)
                {
                    gameDrawn = false;
                    break;
                }

                gameDrawn = true;
            }

            return false;
        }

        private static void ResetTheBoard(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("\n");

            Console.WriteLine("Re-Loading.. Wait for two seconds..");
            Thread.Sleep(2000);
        }
    }
}
