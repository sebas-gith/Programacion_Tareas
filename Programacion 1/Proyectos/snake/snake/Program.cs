using System;
using System.Security.AccessControl;

namespace Snake
{
    class Program
    {

        static void Main(string[] args)
        {
            Update();
        }

        static void Update()
        {
            int snakeX = 55;
            int snakeY = 10;
            Random random = new Random();
            int appleX = random.Next(10, 108);
            int appleY = random.Next(10, 19);
            DrawTitle();
            DrawBoard();
            DrawApple(appleX, appleY);
            short direction = 0;

            int Score = 0;

            DrawScore(Score);
            List<int> direcs = new List<int>();
            List<List<int>> poss = new List<List<int>>();
            direcs.Add(direction);
            poss.Add(new List<int>() { snakeX, snakeY });

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        direction = 0;

                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        direction = 1;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        direction = 2;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        direction = 3;
                    }
                }
                Console.SetWindowSize(120, 30);
                Console.CursorVisible = false;



                switch (direction)
                {
                    case 0:
                        snakeX += 1;
                        ClearHead(snakeX - 1, snakeY);
                        break;
                    case 1:
                        snakeX -= 1;
                        ClearHead(snakeX + 1, snakeY);
                        break;
                    case 2:
                        snakeY -= 1;
                        ClearHead(snakeX, snakeY + 1);
                        break;
                    case 3:
                        snakeY += 1;
                        ClearHead(snakeX, snakeY - 1);
                        break;
                }

                if (snakeX == appleX && snakeY == appleY)
                {


                    direcs.Add(direcs[direcs.Count - 1]);
                    switch (direcs[direcs.Count - 1])
                    {
                        case 0:
                            poss.Add(new List<int>() { poss[poss.Count - 1][0] + 1, poss[poss.Count - 1][1] });
                            break;
                        case 1:
                            poss.Add(new List<int>() { poss[poss.Count - 1][0] - 1, poss[poss.Count - 1][1] });
                            break;
                        case 2:
                            poss.Add(new List<int>() { poss[poss.Count - 1][0], poss[poss.Count - 1][1] - 1 });
                            break;
                        case 3:
                            poss.Add(new List<int>() { poss[poss.Count - 1][0], poss[poss.Count - 1][1] + 1 });
                            break;
                    }

                    appleX = random.Next(10, 108);
                    appleY = random.Next(10, 23);

                    DrawApple(appleX, appleY);
                    Score += 100;
                    DrawScore(Score);

                }


                if (snakeX == 8 && direction == 1)
                {
                    snakeX = 108;
                }
                else if (snakeX == 109 && direction == 0)
                {
                    snakeX = 9;
                }
                else if (snakeY == 3 && direction == 2)
                {
                    snakeY = 23;
                }
                else if (snakeY == 24 && direction == 3)
                {
                    snakeY = 4;
                }


                //body
                int tempX = snakeX;
                int tempY = snakeY;
                for (int i = 0; i < poss.Count; i++)
                {
                    ClearHead(poss[i][0], poss[i][1]);
                }

                for (int i = 0; i < poss.Count; i++)
                {
                    int tX = poss[i][0];
                    int tY = poss[i][1];
                    poss[i][0] = tempX;
                    poss[i][1] = tempY;


                    tempX = tX;
                    tempY = tY;
                    DrawBody(poss[i][0], poss[i][1]);
                }

                DrawHead(snakeX, snakeY);


                Thread.Sleep(Math.Abs(1000 / 20));
            }
        }
        static void DrawTitle()
        {
            Console.SetCursorPosition(55, 1);
            Console.WriteLine("SNAKE");
        }

        static void DrawApple(int appleX, int appleY)
        {
            Console.SetCursorPosition(appleX, appleY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▄");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static void DrawScore(int score)
        {
            Console.SetCursorPosition(80, 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Puntuacion: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(score);
        }


        static void DrawHead(int snakeX, int snakeY)
        {
            Console.SetCursorPosition(snakeX, snakeY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("█");

            Console.ForegroundColor = ConsoleColor.White;
        }
        static void DrawBody(int snakeX, int snakeY)
        {
            Console.SetCursorPosition(snakeX, snakeY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("█");

            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ClearHead(int snakeX, int snakeY)
        {
            Console.SetCursorPosition(snakeX, snakeY);
            Console.Write(" ");
        }
        static void DrawBoard()
        {
            int initialTop = 3;
            int initialLeft = 8;
            Console.SetCursorPosition(8, 3);
            Console.Write("╔");
            for (int i = 0; i < 100; ++i)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            for (int i = 1; i <= 20; ++i)
            {
                Console.SetCursorPosition(initialLeft, initialTop + i);
                Console.Write("║");
                Console.SetCursorPosition(initialLeft + 101, initialTop + i);
                Console.Write("║");
            }
            Console.SetCursorPosition(8, Console.CursorTop + 1);
            Console.Write("╚");
            for (int i = 0; i < 100; ++i)
            {
                Console.Write("═");
            }
            Console.SetCursorPosition(initialLeft + 101, Console.CursorTop);
            Console.Write("╝");
        }


    }
}