using System;
using System.Diagnostics;

namespace DZ
{
    class Program
    {
        static void Main(string[] args)
        {
            var rest = new Restaurant();

            var communication = new Communication();
            communication.Dialog();
            communication.RemoveAllBooking();
        }
    }
}
