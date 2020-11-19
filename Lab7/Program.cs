using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            int check = 1;
            while (check != 0)
            {
                Console.Write("0 - Выход\n1 - Проверить поиск по словарю\n2 - Тестировка\nВвод: ");
                check = Convert.ToInt32(Console.ReadLine());
                if (check == 1)
                {
                    Console.Write("Введите слово, которое нужно найти: ");
                    string str = Console.ReadLine();
                    Console.WriteLine(str);
                    Dictionary dict = new Dictionary();
                    dict.LoadData();
                    int res;
                    
                    res = Search.BruteForce(str, dict);
                    if (res >= 0)
                        Console.WriteLine("Результат 1: " + res.ToString() + " слово по этому индексу: " + dict[res].ToString());
                    
                    dict.SortDictionary();
                    res = Search.BinaryFind(str, dict);
                    if (res >= 0)
                        Console.WriteLine("Результат 2: " + res.ToString() + " слово по этому индексу: " + dict[res].ToString());
                    
                    SegmentDictionary segDict = new SegmentDictionary(dict);
                    Word result = Search.FindInSegment(str, segDict);
                    if (result.index >= 0)
                        Console.WriteLine("Результат 3: " + "сегмент: " + result.segment + ", индекс: " + result.index.ToString() + ", слово: " + segDict.FindWord(result));
                    
                    if (res < 0)
                    {
                        Console.WriteLine("Слово не найдено");
                    }
                }
                else if (check == 2)
                {
                    CheckBruteForceTime();
                    CheckBinaryFindTime();
                    CheckFindInSegmentTime();
                }
            }
        }

        static void CheckBruteForceTime()
        {
            Stopwatch clock = new Stopwatch();
            clock.Restart();
            Dictionary dict = new Dictionary();
            dict.LoadData();
            clock.Stop();
            long tmp = clock.ElapsedTicks;
            List<string> line = new List<string>();
            for (int i = 0; i < dict.N; i += 25)
            {
                string str = dict[i];
                long time = 0;
                for (int j = 0; j < 10000; j++)
                {
                    clock.Restart();
                    int res = Search.BruteForce(str, dict);
                    clock.Stop();
                    time += clock.ElapsedTicks;
                }
                time /= 10000;
                line.Add((i + 1).ToString() + " " + time.ToString());
                Console.WriteLine(i.ToString() + str);
            }
            string path = "C:/Users/MrSklif/source/repos/MrSkl1f/AnalysisOfAlgorithms/Reports/Lab7/source/BruteForce.dat";
            File.AppendAllLines(path, line);
        }

        static void CheckBinaryFindTime()
        {
            Stopwatch clock = new Stopwatch();
            clock.Restart();
            Dictionary dict = new Dictionary();
            dict.LoadData();
            dict.SortDictionary();
            clock.Stop();
            long tmp = clock.ElapsedTicks;
            List<string> line = new List<string>();
            for (int i = 0; i < dict.N; i += 25)
            {
                string str = dict[i];
                long time = 0;
                for (int j = 0; j < 10000; j++)
                {
                    clock.Restart();
                    int res = Search.BinaryFind(str, dict);
                    clock.Stop();
                    time += clock.ElapsedTicks;
                }
                time /= 10000;
                line.Add((i + 1).ToString() + " " + time.ToString());
                Console.WriteLine(i.ToString() + str);
            }
            string path = "C:/Users/MrSklif/source/repos/MrSkl1f/AnalysisOfAlgorithms/Reports/Lab7/source/BinaryFind.dat";
            File.AppendAllLines(path, line);
        }

        static void CheckFindInSegmentTime()
        {
            Stopwatch clock = new Stopwatch();
            clock.Restart();
            Dictionary dict = new Dictionary();
            dict.LoadData();
            dict.SortDictionary();
            SegmentDictionary segDict = new SegmentDictionary(dict);
            clock.Stop();
            long tmp = clock.ElapsedTicks;



            List<string> line = new List<string>();
            for (int i = 0; i < dict.N; i += 25)
            {
                string str = dict[i];
                long time = 0;
                Word res = new Word('a', 0);
                for (int j = 0; j < 10000; j++)
                {
                    clock.Restart();
                    res = Search.FindInSegment(str, segDict);
                    clock.Stop();
                    time += clock.ElapsedTicks;
                }
                time /= 1000;
                line.Add((i + 1).ToString() + " " + time.ToString());
                Console.WriteLine(i.ToString() + " " + str + " " + segDict.FindWord(res));
            }
            string path = "C:/Users/MrSklif/source/repos/MrSkl1f/AnalysisOfAlgorithms/Reports/Lab7/source/FindInSegment.dat";
            File.AppendAllLines(path, line);
        }
    }
}
