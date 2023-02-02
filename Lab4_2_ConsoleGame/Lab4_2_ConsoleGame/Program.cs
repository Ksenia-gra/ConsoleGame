using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4_2_ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random= new Random();
            Game.SetField();
            int coinsCount = 0;
            Console.SetCursorPosition(1,1);
            Console.WriteLine($"coins:{coinsCount}");

            List<RivalCar> rivalCars = new List<RivalCar>();
            //создание машин соперников
            for(int i=0;i<random.Next(3,5);i++)
            {
                RivalCar rivalCar = new RivalCar
                (new Point(random.Next(1, Game.x - 1), random.Next(1, Game.y - 1)));
                rivalCars.Add(rivalCar);

            }
            Coin coin = new Coin(new Point(random.Next(1, Game.x - 1), random.Next(1, Game.y - 1)));
            //сздание машины
            Car car = new Car(new Point((Game.x-2)/2,Game.y-3));

            bool flag = true;
            bool isWin = false;
            while (flag)
            {
                
                if (!car.isCrashed())
                {
                    Console.ForegroundColor= ConsoleColor.White;
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine($"coins:{coinsCount}");
                    
                    
                    Console.ForegroundColor= rivalCars[0].RivalCarColor;
                    for(int i=0;i<rivalCars.Count();i++)
                    {

                        if (!rivalCars[i].isCrashed())
                        {//проверка что машина соперника не врезалась в конец карты
                            rivalCars[i].Drive();
                            if (rivalCars[i].isHit(coin.Points))
                            {
                             
                                coin.Clear();
                                coin = new Coin(new Point(random.Next(1, Game.x - 1), random.Next(1, Game.y - 1)));

                            }
                        }
                           
                        else
                        {
                            rivalCars[i].Clear();
                          

                           rivalCars[i]= new RivalCar
                    (new Point(random.Next(1, Game.x - 1), random.Next(1, Game.y - 1)));

                        }
                    }
                    


                    Thread.Sleep(100);
                    

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();

                        car.SetDirection(key.Key);


                    }
                    
                    Console.ForegroundColor = car.CarColor;
                    foreach (RivalCar rivalCar in rivalCars)
                    {
                        if (car.isHit(rivalCar.Points) )
                           
                           flag= false;
                    }
                   
                    car.Drive();
                    if (car.isHit(coin.Points))
                    {
                        coinsCount++;
                        coin.Clear();
                        coin= new Coin(new Point(random.Next(1, Game.x - 1), random.Next(1, Game.y - 1)));
                        
                    }


                    Thread.Sleep(100);
                }
                   
                else
                {
                    if (car.StartPosition.Y == 0)
                    {
                       
                        isWin = true;
                    }
                    flag = false;

                }
                    
                
                
            }
            if (isWin)
            {
                Console.Clear();
                Console.SetCursorPosition((Game.x - 5) / 2, (Game.y - 1) / 2);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Вы выиграли!Монет собрано:{coinsCount}");
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition((Game.x - 5) / 2, (Game.y - 1) / 2);
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Вы проиграли!");
            }
            
           Console.ReadKey();
        }
    }
}
