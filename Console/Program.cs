using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 200; i++)
                numbers.Add(rnd.Next(1000, 10000));


            var res = numbers.WhereInList(x => x > 5000);

            Console.ReadKey();
        }
    }
}
