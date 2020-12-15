using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class Map
    {
        public int count;
        public int[,] dist;
        public Point[] pos;

        public Map(int n, int size)
        {
            count = n;
            InitPos(size);
            InitDist();
        }

        private void InitDist()
        {
            dist = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                dist[i, i] = -1;
                for (int j = i + 1; j < count; j++)
                {
                    dist[i, j] = dist[j, i] = GetDistance(pos[i], pos[j]);
                }
            }
        }

        private void InitPos(int size)
        {
            Random rand = new Random();
            pos = new Point[count];
            for (int i = 0; i < count; i++)
            {
                pos[i] = new Point(rand.Next(size), rand.Next(size));
            }
        }
        
        private int GetDistance(Point a, Point b)
        {
            return (int)Math.Ceiling(Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y)));
        }
    }

    class Point
    {
        private int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
    }
}
