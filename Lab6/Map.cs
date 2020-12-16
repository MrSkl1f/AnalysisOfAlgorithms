using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class Map
    {
        private int count;
        private int[,] dist;

        public Map(int n, int rand)
        {
            Random r = new Random();
            count = n;
            dist = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                dist[i, i] = -1;
                for (int j = i + 1; j < count; j++)
                {
                    dist[i, j] = dist[j, i] = r.Next(rand);
                }
            }
        }

        public int this[int i, int j]
        {
            get { return dist[i, j]; }
            set { dist[i, j] = value; }
        }
        public int N
        {
            get { return count; }
            set { count = value; }
        }
        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write(dist[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
