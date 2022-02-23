using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DZ
{
    public class Restaurant
    {
        private static  List<Table> _tables = new();

        public Restaurant()
        {
            // for (int i = 0; i < 10; i++)
            // {
            //     _tables.Add(new Table(i));
            // }
            _tables.Add(new Table(1){State = State.Free});
            _tables.Add(new Table(2){State = State.Booked});
            _tables.Add(new Table(3){State = State.Free});
            _tables.Add(new Table(4){State = State.Booked});
            _tables.Add(new Table(5){State = State.Booked});
        }

        public static void BookFreeTable(int countOfPersons)
        {
            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);
            
            Thread.Sleep(5000);//ждем манагера  
            Console.WriteLine(table is null
                ? $"К сожалению все столы заняты"
                : $"Готово! Ваш столик номер {table.Id}"
            );
        }
        
        
        public static void BookFreeTableAsync(int countOfPersons)
        {
            

            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);

                await Task.Delay(5000);
                table?.SetState(State.Booked);

                Console.WriteLine(table is null
                    ? $"К сожалению все столы заняты"
                    : $"Готово! Ваш столик номер {table.Id}"
                );
            });

        }

        public static void RemoveBooking(int id)
        {
            var table = _tables.FirstOrDefault(t => t.Id == id);

            Thread.Sleep(5000);//ждем манагера  
            table?.SetState(State.Free);
        }
        
        public static void RemoveBookingAsync(int id)
        {
            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.Id == id);

                await Task.Delay(5000); //ждем манагера  
                table?.SetState(State.Free);
                
            });

        }
        
        public static void RemoveAllBookingAsync()
        {
            Task.Run(async () =>
            {
                for (int i = 0; i <= _tables.Count; i++)
                {
                    _tables[i].SetState(State.Free);
                }
               
             
                
            });

            foreach (var VARIABLE in _tables)
            {
                Console.WriteLine(VARIABLE.State);
            }

        }
    }
}