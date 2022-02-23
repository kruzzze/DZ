using System;
using System.Diagnostics;

namespace DZ
{
    public class Communication
    {

        public void Dialog()
        {
            Console.WriteLine("Добрый день!Если вы хотите забронировать стол,то нажмите 1.Если хотите удалить бронь,то нажмите 2");
            
            if (!int.TryParse(Console.ReadLine(),out var action) &&action is not (1 or 2))
            {
                Console.WriteLine("Введите 1 или 2");
                
            }

            if (action==1)
            {

                while (true)
                {
                    Console.WriteLine("Привет!Желаете забронировать столик?\n1-Мы уведомим вас по смс(асинхронно)"+
                                      "\n2 -Подождите на линии. Мы вас оповестим(синхронно)");
                
                    if (!int.TryParse(Console.ReadLine(),out var choice) &&choice is not (1 or 2))
                    {
                        Console.WriteLine("Введите 1 или 2");
                        continue;
                    }

                    var stopWatch = new Stopwatch();
                    stopWatch.Start();//замер потраченного времени на бронь

                    if (choice==1)
                    {
                        Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу вашу бронь." );
                        Restaurant.BookFreeTableAsync(1);
                    }
                    else
                    {
                        Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу вашу бронь." );
                        Restaurant.BookFreeTable(1);
                    }

                    Console.WriteLine("Спасибо за обращение");
                    stopWatch.Stop();
                    var ts = stopWatch.Elapsed;
                    Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}");
                
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Привет!Желаете удалить бронь со стола?\n1-Мы уведомим вас по смс(асинхронно)"+
                                      "\n2 -Подождите на линии. Мы вас оповестим(синхронно)");
                    
                    if (!int.TryParse(Console.ReadLine(),out var choice) &&choice is not (1 or 2))
                    {
                        Console.WriteLine("Введите 1 или 2");
                
                    }

                    var stopWatch = new Stopwatch();
                    stopWatch.Start();//замер потраченного времени на бронь
                    if (choice==2)
                    {
                        Console.WriteLine("Номер вашего стола?");
                        int temp = int.Parse(Console.ReadLine());
                        Restaurant.RemoveBooking(temp);
                        Console.WriteLine("Стол свободен,прощайте");
                    }
                    else
                    {
                        Console.WriteLine("Номер вашего стола?");
                        int temp = int.Parse(Console.ReadLine());
                        Restaurant.RemoveBookingAsync(temp);
                        Console.WriteLine("Стол свободен,прощайте");
                    }
                    
                    Console.WriteLine("Спасибо за обращение");
                    stopWatch.Stop();
                    var ts = stopWatch.Elapsed;
                    Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}");
                    break;;
                }
            }
        }

        public void RemoveAllBooking()
        {
            Console.WriteLine("ВНИМАНИЕ ВСЕ БРОНИ СНИМАЮТСЯ!!");
            Restaurant.RemoveAllBookingAsync();
        }
      
    }
}