using System;

namespace Learning.ConsoleApplications.Games.Concrete
{
    public class PlayWithStar : IConsoleGames
    {
        private static int _left;
        private static int _top;

        public void Run()
        {
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(_left, _top);
                Console.Write('*');
                AcceptInput();
            }
        }

        private static void AcceptInput()
        {

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    _left--;
                    break;
                case ConsoleKey.RightArrow:
                    _left++;
                    break;
                case ConsoleKey.UpArrow:
                    _top--;
                    break;
                case ConsoleKey.DownArrow:
                    _top++;
                    break;
            }
        }
    }
}
