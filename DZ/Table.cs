using System;

namespace DZ
{
    public class Table
    {
        public State State { get; set; }

        public int  SeatsCount { get; set; }

        public int Id { get; set; }
        
        private Random Random = new Random();
        
        
        public Table(int id)
        {
            Id = id;
            //State =State.Free;
            SeatsCount = Random.Next(2, 5);
            
        }

        public bool SetState(State state)
        {
            if (state==State)
            {
                return false;
            }

            State = state;
            return true;
        }
        
        
    }
}