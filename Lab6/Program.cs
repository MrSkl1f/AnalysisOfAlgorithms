using System;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int check = Convert.ToInt32(Console.ReadLine());

            while (check != 0)
            {
                Map map = new Map(4, 50);
                Path res = BruteForce.GetRoute(map);
                Path secRes = AntAlgorithm.GetRoute(map, 30, 0.8, 0.2, 4, 0.1);
                res.Print();
                Console.WriteLine(res.N);
                secRes.Print();
                Console.WriteLine(secRes.N);
                check = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
