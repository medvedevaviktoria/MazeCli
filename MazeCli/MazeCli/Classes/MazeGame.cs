using System;

namespace MazeCli.Classes
{
    public class MazeGame
    {
        private const int ROWS = 20;
        private const int COLS = 20;
        private readonly int[,] Maze = new int[20, 20]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
            {1,0,1,1,0,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1},
            {1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,1},
            {1,0,1,0,1,1,1,1,1,1,0,1,1,1,1,1,0,1,0,1},
            {1,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,0,1},
            {1,1,1,0,1,0,1,1,0,1,1,1,1,1,0,1,1,1,0,1},
            {1,0,0,0,1,0,1,0,0,0,0,0,0,1,0,0,0,1,1,1},
            {1,0,1,1,1,0,1,0,1,1,1,1,0,1,1,1,0,1,0,1},
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,1,0,1,0,1},
            {1,1,1,1,1,1,1,0,1,0,1,1,1,1,0,1,0,1,0,1},
            {1,0,1,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1},
            {1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,0,1},
            {1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1},
            {1,0,1,0,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1},
            {1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1},
            {1,1,1,0,1,0,1,0,1,1,1,1,1,1,0,1,1,1,1,1},
            {1,0,0,0,1,0,1,0,0,0,0,0,0,1,0,0,1,0,0,1},
            {1,0,1,1,1,0,1,0,1,1,1,1,0,1,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };
        private readonly int[] PlayerPosition = [1, 1];
        private int[] ExitPosition = [18, 18];
        private bool isWon = false;
        

        /// <summary>
        /// Метод запуска и процесса игровой сессии
        /// </summary>
        public void GameSession()
        {
            PrintMazeAndInfo();

            while (!(PlayerPosition[0] == ExitPosition[0] && PlayerPosition[1] == ExitPosition[1]))
            {
                ConsoleKey key = Console.ReadKey().Key;
                MovePlayer(key);
                PrintMazeAndInfo();
            }

            isWon = true;
            PrintMazeAndInfo();

        }

        /// <summary>
        /// Метод вывода лабиринта и доволнительной информации для игрока
        /// </summary>
        public void PrintMazeAndInfo()
        {
            Console.Clear();
            string[] infoLines;
            if (!isWon)
            {
                infoLines =
                [
                    "",
                    "Символы:",
                    "P - Игрок",
                    "E - Выход",
                    "█ - Стена",
                    "Перемещайтесь по лабиринту с помощью стрелочек на клавиатуре",
                    "",
                    "Цель: добраться до выхода"
                ];
            }
            else
            {
                infoLines =
                [
                    "",
                    "Поздравляю!",
                    "Вы добрались до выхода!",
                    "",
                    "Нажмите любую клавишу для выхода из игры"
                ];
            }
            

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (row == PlayerPosition[0] && col == PlayerPosition[1]) Console.Write("P");
                    else if (row == ExitPosition[0] && col == ExitPosition[1]) Console.Write('E');
                    else if (Maze[row, col] == 1) Console.Write("█");
                    else Console.Write(" ");
                }

                if (row < infoLines.Length) Console.Write("         " + infoLines[row]);
                Console.WriteLine();

            }
        }

        /// <summary>
        /// Метод обработки нажатий клавиш 
        /// </summary>
        /// <param name="key"></param>
        private void MovePlayer(ConsoleKey key)
        {
            int newRow = PlayerPosition[0], newCol = PlayerPosition[1] ;

            switch (key)
            {
                case ConsoleKey.UpArrow: newRow--; break;
                case ConsoleKey.DownArrow: newRow++; break;
                case ConsoleKey.LeftArrow: newCol--; break;
                case ConsoleKey.RightArrow: newCol++; break;
                default: break;
            }

            if (newRow < 0 || newRow >= ROWS || newCol < 0 || newCol >= COLS || Maze[newRow, newCol] == 1) return;

            PlayerPosition[0] = newRow; PlayerPosition[1] = newCol; 
        }
    }
}
