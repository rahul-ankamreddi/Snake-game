using System;
using System.Threading;

namespace ConsoleApp2
{
    public class SnakeGame
    {
        readonly int borderWidth = 50;
        readonly int borderHeight = 20;

        int[] X = new int[10];
        int[] Y = new int[10];

        int score = 0;

        int fruitX = 0, fruitY = 0;


        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        Random random = new Random();

        char key = 'w';

        public SnakeGame()
        {
            X[0] = 5;
            Y[0] = 5;
            //fruitX = random.Next(1, borderWidth);
            //fruitY = random.Next(1, borderHeight);
            //WritePoint(fruitX, fruitY, '@');
            fruit();

        }

        public void WritePoint(int x, int y, char mark)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mark);
            Console.CursorVisible = false;
        }

        public void fruit()
        {
            fruitX = random.Next(1, borderWidth);
            fruitY = random.Next(1, borderHeight);
            WritePoint(fruitX, fruitY, '@');
        }


        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        public void Border()
        {
            for (int xAxis = 0; xAxis <= borderWidth; xAxis++)
            {
                WritePoint(xAxis, 0, '*');
                WritePoint(xAxis, borderHeight, '*');
            }
            for (int yAxis = 0; yAxis <= borderHeight; yAxis++)
            {
                WritePoint(0, yAxis, '*');
                WritePoint(borderWidth, yAxis, '*');
            }

        }

        public void End()
        {
            Console.SetCursorPosition(0, borderHeight + 4);
        }

        public void Snake()
        {
            WritePoint(X[0], Y[0], '#');

        }

        public string GameOver()
        {
            Console.SetCursorPosition(0, borderHeight + 3);
            return "Game Over";
        }

        public void Move()
        {
            int moveX = 1;
            int moveY = 1;
            int positionX = 1;
            int positionY = 1;
            while ((positionX > 0) && (positionX < borderWidth) && (positionY > 0) && (positionY < borderHeight))
            {
                positionX = X[0] + moveX;
                positionY = Y[0] + moveY;
                if (positionX == borderWidth || positionX == 0)
                {
                    Console.WriteLine(GameOver());
                    break;
                }
                if (positionY == borderHeight || positionY == 0)
                {
                    Console.WriteLine(GameOver());
                    break;
                }

                Input();
                Border();

                if(positionX == fruitX && positionY == fruitY)
                {
                    fruit();
                    score++;
                }
                WritePoint(fruitX, fruitY, '@');

                Console.SetCursorPosition(0, borderHeight + 1);
                Console.WriteLine($"Your score is : { score}");


                WritePoint(positionX, positionY, 'O');
                WritePoint(positionX - 1, positionY, ' ');
                WritePoint(positionX + 1, positionY, ' ');
                WritePoint(positionX, positionY + 1, ' ');
                WritePoint(positionX, positionY - 1, ' ');


                switch (key)
                {
                    case 'w':
                        moveY--;
                        break;
                    case 's':
                        moveY++;
                        break;
                    case 'd':
                        moveX++;
                        break;
                    case 'a':
                        moveX--;
                        break;
                    default:
                        
                        break;
                }

                Thread.Sleep(100);

            }
        }



    }
}
