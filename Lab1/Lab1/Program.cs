using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int check = -1;
            while (check != 0)
            {
                Console.Write("0 - Выход\n" +
                              "1 - Левенштейн с матрицей\n" +
                              "2 - Левенштейн рекурсивно\n" +
                              "3 - Левенштейн рекурсивно с матрицей\n" +
                              "4 - Дамерау-Левенштейн с матрицей\n" +
                              "5 - Замер времени\n");
                check = Convert.ToInt32(Console.ReadLine());
                if (check != 0)
                {
                    string first = "", second = "";
                    if (check != 5)
                    {
                        Console.Write("Введите первое слово: ");
                        first = Console.ReadLine();
                        Console.Write("Введите второе слово: ");
                        second = Console.ReadLine();
                    }
                    int res = 0;
                    if (check == 1) { res = Algorithms.LevTable(first, second); }
                    if (check == 2) { res = Algorithms.LevRecursion(first, second); }
                    if (check == 3) { res = Algorithms.LevTableRec(first, second); }
                    if (check == 4) { res = Algorithms.LevDamTable(first, second); }
                    Console.WriteLine("Расстояние: " + Convert.ToString(res));
                }
                if (check == 5)
                {
                    Algorithms.CheckTime();
                }
            }
        }
    }
}
