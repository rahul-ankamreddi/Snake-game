using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Program
    {
        static void Main(string[] args)
        {
            SnakeGame game = new SnakeGame();

            game.Border();
            game.Move();
            game.Input();
            game.End();

        }
    }
}