using System;
using MazeCli.Classes;

namespace MazeCli
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeGame game = new MazeGame();
            game.PrintMaze();
        }
    }
}