using System;

namespace MazeCli.Classes
{
    public class MazeGame
    {
        private int rows = 20;
        private int cols = 20;
        private int[,] maze = new int[20, 20]
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
        private int playerRow = 1;
        private int playerCol = 1;
        private int exitRow = 18;
        private int exitCol = 18;
        

        public void GameSession()
        {
            PrintMaze();

            while (!(playerRow == exitRow && playerCol == exitCol))
            {
                ConsoleKey key = Console.ReadKey().Key;
                MovePlayer(key);
                PrintMaze();
            }
        }

        public void PrintMaze()
        {
            Console.Clear();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == playerRow && col == playerCol) Console.Write("P");
                    else if (row == exitRow && col == exitCol) Console.Write('E');
                    else if (maze[row, col] == 1) Console.Write("█");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private void MovePlayer(ConsoleKey key)
        {
            int newCol = playerCol, newRow = playerRow;

            switch (key)
            {
                case ConsoleKey.UpArrow: newRow--; break;
                case ConsoleKey.DownArrow: newRow++; break;
                case ConsoleKey.LeftArrow: newCol--; break;
                case ConsoleKey.RightArrow: newCol++; break;
                default: break;
            }

            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || maze[newRow, newCol] == 1) return;

            playerCol = newCol; playerRow = newRow;
        }
    }
}
