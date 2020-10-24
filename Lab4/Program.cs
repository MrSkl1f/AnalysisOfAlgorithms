using System;
using System.Diagnostics;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix first = new Matrix(600, 600);
            Matrix second = new Matrix(600, 600);
            first.FillMatr();
            second.FillMatr();
            //first.ReadMatr();
            Console.WriteLine();
            //second.ReadMatr();
            Console.WriteLine();

            Stopwatch clock = new Stopwatch();
            for (int i = 0; i < 3; i++)
            {
                clock.Restart();
                Matrix res = MultMatr.VinogradMult(first, second);
                clock.Stop();
                Console.Write("1 - ");
                Console.WriteLine(clock.ElapsedTicks);   
                clock.Restart();
                res = ParallelMultMatr.ParallelVinogradMult2(first, second, 8);
                clock.Stop();
                Console.Write("2 - ");
                Console.WriteLine(clock.ElapsedTicks);
                Console.WriteLine();
            }
            
        }
    }
}
