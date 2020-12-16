using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    static class BruteForce
    {
        public static Path GetRoute(Map map)
        {
            Path shortest = new Path(null, map, int.MaxValue);
            foreach (List<int> cur in GetAllRoutes(map.N))
            {
                cur.Add(0);
                Path check = new Path(cur, map, -1);
                check.GetDistance();
                if (shortest.N > check.N)
                    shortest = check;
            }
            return shortest;
        }

        private static List<List<int>> GetAllRoutes(int count)
        {
            List<List<int>> AllRoutes = new List<List<int>>();
            List<int> cur = new List<int>();
            for (int i = 0; i < count; i++)
                cur.Add(i);
            while (NextSet(cur, count))
                AllRoutes.Add(Copy(cur));
            return AllRoutes;
        }
        private static bool NextSet(List<int> cur, int count)
        {
            int j = count - 2;
            while (j != -1 && cur[j] >= cur[j + 1]) j--;
            if (j == -1 || cur[j] == 0)
                return false;
            int k = count - 1;
            while (cur[j] >= cur[k]) 
                k--;
            Swap(cur, j, k);
            int left = j + 1; 
            int right = count - 1;
            while (left < right)
                Swap(cur, left++, right--);
            return true;
        }

        private static void Swap(List<int> cur, int i, int j)
        {
            int tmp = cur[i];
            cur[i] = cur[j];
            cur[j] = tmp;
        }
        
        private static List<int> Copy(List<int> lst)
        {
            List<int> newLst = new List<int>();
            foreach (int num in lst)
                newLst.Add(num);
            return newLst;
        }

        private static void Print(List<int> cur)
        {
            foreach (int num in cur)
            {
                Console.Write(num);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
