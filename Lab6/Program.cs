using System;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(4, 50);
            Path res = BruteForce.GetRoute(map);
            res.Print();
            Console.WriteLine();
            map.Print();
        }
    }
}
