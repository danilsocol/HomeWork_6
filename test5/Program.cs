using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;

namespace test5
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int> dictionary = new MyDictionary<int>(10000);
            Random rnd = new Random();

            for (int i = 0; i < 9000; i++)
            {
                int num = rnd.Next();
                dictionary.Add( num);

            }

            Console.WriteLine();
            Console.WriteLine($"max {dictionary.maxJ}");
        }

       
       
    }
}


