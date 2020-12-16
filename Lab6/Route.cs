using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class Route
    {
        public List<int> path;
        public int dist;
        private Map map;

        public Route(Map map)
        {
            path = new List<int>();
            this.map = map;
        }
        public Route(Map m, List<int> path)
        {
            this.map = m;
            this.path = path;
            dist = GetDistance(m, path);
        }
        public Route(int maxDistance)
        {
            dist = maxDistance;
        }
        public void Add(int value)
        {
            dist += map[path.Count - 1, value];
            path.Add(value);
        }

        private int GetDistance(Map map, List<int> route)
        {
            int distance = 0;
            for (int i = 0; i < route.Count - 1; i++)
            {
                distance += map[route[i], route[i + 1]];
            }
            return distance;
        }
        public void Print()
        {
            foreach (int num in path)
            {
                Console.Write(num);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
