using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Learning.ConsoleApplications.Games
{
    public class CatchTheObject : IConsoleGames
    {
        private static int _left = 0;
        private static readonly int _top = Console.WindowHeight - 1;

        private struct Position
        {
            public int Left;
            public int Top;
        }

        private static IList<Position> _points = new List<Position>();
        private static DateTime _nextUpdate = DateTime.MinValue;

        public void Run()
        {
            Console.CursorVisible = false;

            DrawObjects();
            while (true)
            {
                var autoUpdate = DateTime.Now >= _nextUpdate;

                if (AcceptInput() || autoUpdate)
                {
                    DrawObjects();

                    if (autoUpdate)
                    {
                        AddStar();
                        MoveStars();

                        _nextUpdate = DateTime.Now.AddMilliseconds(500);
                    }
                }
            }
        }

        #region Private methods

        private static void DrawObjects()
        {
            Console.Clear();
            Console.SetCursorPosition(_left, _top);
            Console.Write(@"\_/");

            foreach (var point in _points)
            {
                Console.SetCursorPosition(point.Left, point.Top);
                Console.Write("*");
            }

            Console.SetCursorPosition(0, 0);
        }

        private static bool AcceptInput()
        {
            if (!Console.KeyAvailable) return false;

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    _left--;
                    break;
                case ConsoleKey.RightArrow:
                    _left++;
                    break;
            }

            return true;
        }

        private static void AddStar()
        {
            var randomNumber = new Random();

            _points.Add(new Position()
            {
                Left = randomNumber.Next(Console.WindowWidth),
                Top = 0
            });
        }

        private static void MoveStars()
        {
            for (var i = 0;i <= _points.Count - 1; i++) 
            {
                _points[i] = new Position()
                {
                    Left = _points[i].Left,
                    Top = _points[i].Top + 1
                };
            }
        }

        #endregion
    }
}
