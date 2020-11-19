using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Arguments> data = new List<Arguments>();
            GenerateData(3, 5, data);
            StartConveyor(data);
        }

        public static void StartConveyor(List<Arguments> data)
        {
            Thread[] threads = new Thread[3];
            Line[] lines = new Line[3];

            lines[2] = new Line(2, 2000, null);
            lines[1] = new Line(1, 2000, lines[2]);
            lines[0] = new Line(0, 3000, lines[1], data);

            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(lines[i].RunLine);
                threads[i].Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        public static void GenerateData(int countOfLines, int size, List<Arguments> data)
        {
            for (int i = 0; i < size; i++)
            {
                data.Add(new Arguments(countOfLines, i));
            }
            data.Add(new Arguments(0, -1, true));
        }
    }
}
