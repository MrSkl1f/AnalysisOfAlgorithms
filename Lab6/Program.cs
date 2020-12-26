using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckCoeffs();
            //CheckTime();
            
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

        static void CheckTime()
        {
            Stopwatch clock = new Stopwatch();
            clock.Restart();
            List<string> line = new List<string>();
            clock.Stop();
            Path res = null;
            for (int i = 2; i <= 10; i++)
            {
                Map map = new Map(i, 50);
                long time = 0;
                for (int j = 0; j < 20; j++)
                {
                    clock.Restart();
                    //res = BruteForce.GetRoute(map);
                    res = AntAlgorithm.GetRoute(map, 30, 0.8, 0.2, 4, 0.1);
                    clock.Stop();
                    time += clock.ElapsedTicks;
                }
                time /= 20;
                line.Add((i).ToString() + " " + time.ToString());
                Console.WriteLine(i.ToString() + time.ToString());
            }
            //string path = "C:/Users/MrSklif/source/repos/MrSkl1f/AnalysisOfAlgorithms/Reports/Lab6/source/Brute.dat";
            string path = "C:/Users/MrSklif/source/repos/MrSkl1f/AnalysisOfAlgorithms/Reports/Lab6/source/Ant.dat";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.AppendAllLines(path, line);
        }

        static void CheckCoeffs()
        { 
            Map map = new Map(7, 50);
            Path shortest = BruteForce.GetRoute(map);
            shortest.GetDistance();
            for (double alpha = 0.1; alpha <= 0.9; alpha += 0.1)
            {
                for (double beta = 0.0; beta <= 0.9; beta += 0.1)
                {
                    for (double pho = 0.0; pho <= 0.9; pho += 0.3)
                    {
                        Path res = AntAlgorithm.GetRoute(map, 30, alpha, beta, 4, pho);
                        if (Math.Abs(shortest.N - res.N) < 1)
                        Console.WriteLine("{0,-5:0.0} {1,-5:0.0} {2,-5:0.0} {3}",
                            alpha,
                            beta,
                            pho,
                            Math.Abs(shortest.N - res.N));
                    }
                }
            }
        }
    }
}
