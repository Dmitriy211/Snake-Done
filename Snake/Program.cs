using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public static string way = "none";

        static void Main(string[] args)
        {
            Worm worm = new Worm();
            Food food = new Food();
            Wall wall = new Wall(1);
            Point f = new Point(0, 0);

            while (worm.isAlive)
            {
                f = food.location;
                Console.Clear();                
                worm.Draw();                               
                food.Draw();                                                                                
                wall.Draw();

                Console.WriteLine("\n" + food.location.x);
                Console.WriteLine(food.location.y);

                int fx = food.location.x;
                int fy = food.location.y;

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (way != "down")
                        {
                            worm.Move(0, -1);
                            way = "up";
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (way != "up")
                        {
                            worm.Move(0, 1);
                            way = "down";
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (way != "right")
                        {
                            worm.Move(-1, 0);
                            way = "left";
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (way != "left")
                        {
                            worm.Move(1, 0);
                            way = "right";
                        }
                        break;
                    case ConsoleKey.Escape:
                        worm.isAlive = false;
                        break;
                }

                for (int i = 0; i < wall.bricks.Count; i++)
                    if (wall.bricks[i].x == worm.body[0].x && wall.bricks[i].y == worm.body[0].y)
                    {
                        worm.isAlive = false;
                    }

                for (int i = 1; i < worm.body.Count; i++)
                {
                    if (worm.body[0].x == worm.body[i].x && worm.body[0].y == worm.body[i].y)
                        worm.isAlive = false;
                }

                if (worm.CanEat(food))
                {
                    bool k=true;
                    while (k==true)
                    {
                        k = false;
                        food = new Food();
                        for (int i = 0; i < worm.body.Count; i++)
                            if (worm.body[i].x == food.location.x && worm.body[i].y == food.location.y)
                                k=true;                        
                    }                  
                }
            }

            Console.Clear();
            Console.WriteLine("GAME OVER");

        }
    }
}
