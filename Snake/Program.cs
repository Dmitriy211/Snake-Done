using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {        
        static void Main(string[] args)
        {           
            int l;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chose level (1-5)");
                l = int.Parse(Console.ReadLine());
                if (l > 0 && l <= 5)
                    break;
            }

            Wall wall = new Wall(l);
            Worm worm = new Worm();
            Food food = new Food();

            string way = "none";

            bool f0 = true;
            while (f0 == true)
            {                
                worm = new Worm();
                food = new Food();
                f0 = false;
                for (int i = 0; i < wall.bricks.Count; i++)
                    if (wall.bricks[i].Equals(worm.body[0]))
                        f0 = true;
            }

            bool s0 = true;
            bool s1 = true;
            while (s0 == true || s1 == true)
            {
                worm = new Worm();
                s0 = false;
                s1 = false;
                for (int i = 0; i < wall.bricks.Count; i++)
                    if (wall.bricks[i].Equals(worm.body[0]))
                        s0 = true;
                if (worm.body[0].Equals(food.location))
                    s1 = true;
            }            

            while (worm.isAlive)
            {                
                Console.Clear();                
                worm.Draw();                               
                food.Draw();                                                                                
                wall.Draw();                                

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (way != "down"  || worm.body.Count == 1)
                        {
                            worm.Move(0, -1);
                            way = "up";
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (way != "up" || worm.body.Count == 1)
                        {
                            worm.Move(0, 1);
                            way = "down";
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (way != "right" || worm.body.Count == 1)
                        {
                            worm.Move(-1, 0);
                            way = "left";
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (way != "left" || worm.body.Count == 1)
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
                    bool f1 = true;
                    bool f2 = true;
                    while (f1==true || f2==true)
                    {
                        f1 = false;
                        f2 = false;
                        food = new Food();
                        for (int i = 0; i < worm.body.Count; i++)
                            if (worm.body[i].Equals(food.location))
                                f1=true;

                        for (int i = 0; i < wall.bricks.Count; i++)
                            if (wall.bricks[i].Equals(food.location))
                                f2 = true;
                    }                  
                }
            }

            Console.Clear();
            Console.WriteLine("GAME OVER");

        }
    }
}
