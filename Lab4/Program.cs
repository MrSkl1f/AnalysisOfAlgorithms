using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int check = 1;
            while (check != 0)
            {
                Console.Write("0 - Выход\n1 - Проверить умножение матриц\n2 - Тестировка\nВвод: ");
                check = Convert.ToInt32(Console.ReadLine());
                if (check == 1)
                {
                    CheckMult();
                }
                else if (check == 2)
                {
                    TestFirstExperiment();
                    TestSecondExperiment();
                }
            }
        }

        static void CheckMult()
        {
            Console.WriteLine("Введите первое n:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите первое m:");
            int m1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе n:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе m:");
            int m2 = Convert.ToInt32(Console.ReadLine());

            Matrix mat1 = new Matrix(n1, m1);
            Matrix mat2 = new Matrix(n2, m2);
            mat1.FillMatr();
            mat2.FillMatr();

            Matrix result1 = MultMatr.VinogradMult(mat1, mat2);
            Console.WriteLine("Первая матрица:");
            mat1.ReadMatr();
            Console.WriteLine("Вторая матрица:");
            mat2.ReadMatr();
            Console.WriteLine("Результат 1:");
            result1.ReadMatr();
            Matrix result2 = ParallelMultMatr.ParallelVinogradMult1(mat1, mat2, 8);
            Console.WriteLine("Результат 2:");
            result2.ReadMatr();
            Console.WriteLine("Результат 3:");
            Matrix result3 = ParallelMultMatr.ParallelVinogradMult2(mat1, mat2, 8);
            result3.ReadMatr();
        }
    
        static void TestFirstExperiment()
        {
            // 300 на 300 с разным количеством потоков
            Matrix matr1 = new Matrix(300, 300);
            Matrix matr2 = new Matrix(300, 300);
            matr1.FillMatr();
            matr2.FillMatr();
            Stopwatch clock = new Stopwatch();
            List<string> lines1 = new List<string>();
            List<string> lines2 = new List<string>();
            List<string> lines3 = new List<string>();
            for (int threads = 0; threads <= 32; threads+=2)
            {
                long time1 = 0, time2 = 0, time3 = 0;

                int curThreads = threads;
                if (threads == 0)
                {
                    curThreads = 1;
                }
                for (int i = 0; i < 4; i++)
                {
                    clock.Restart();
                    Matrix res1 = MultMatr.VinogradMult(matr1, matr2);
                    clock.Stop();
                    if (i != 0)
                    {
                        time1 += clock.ElapsedTicks;
                    }

                    clock.Restart();
                    Matrix res2 = ParallelMultMatr.ParallelVinogradMult1(matr1, matr2, curThreads);
                    clock.Stop();
                    if (i != 0)
                    {
                        time2 += clock.ElapsedTicks;
                    }

                    
                    clock.Restart();
                    Matrix res3 = ParallelMultMatr.ParallelVinogradMult2(matr1, matr2, curThreads);
                    clock.Stop();
                    if (i != 0)
                    {
                        time3 += clock.ElapsedTicks;
                    }
                }
                time1 /= 3;
                time2 /= 3;
                time3 /= 3;
                lines1.Add(curThreads.ToString() + " " + time1.ToString());
                lines2.Add(curThreads.ToString() + " " + time2.ToString());
                lines3.Add(curThreads.ToString() + " " + time3.ToString());
                Console.WriteLine(curThreads.ToString() + " complete");
            }
            string path = "C:/Users/MrSklif/source/repos/MrSkl1f/AnalysisOfAlgorithms/Reports/Lab4/source/";
            File.AppendAllLines(path + "FirstExp1.dat", lines1);
            File.AppendAllLines(path + "FirstExp2.dat", lines2);
            File.AppendAllLines(path + "FirstExp3.dat", lines3);
        }

        static void TestSecondExperiment()
        {
            Stopwatch clock = new Stopwatch();
            List<string> lines1 = new List<string>();
            List<string> lines2 = new List<string>();
            List<string> lines3 = new List<string>();
            for (int size = 0; size <= 700; size += 100)
            {
                Matrix matr1 = new Matrix(size, size);
                Matrix matr2 = new Matrix(size, size);
                matr1.FillMatr();
                matr2.FillMatr();
                long time1 = 0, time2 = 0, time3 = 0;
                for (int i = 0; i < 3; i++)
                {
                    clock.Restart();
                    Matrix res1 = MultMatr.VinogradMult(matr1, matr2);
                    clock.Stop();
                    if (i != 0)
                    {
                        time1 += clock.ElapsedTicks;
                    }

                    clock.Restart();
                    Matrix res2 = ParallelMultMatr.ParallelVinogradMult1(matr1, matr2, 8);
                    clock.Stop();
                    if (i != 0)
                    {
                        time2 += clock.ElapsedTicks;
                    }

                    clock.Restart();
                    Matrix res3 = ParallelMultMatr.ParallelVinogradMult2(matr1, matr2, 8);
                    clock.Stop();
                    if (i != 0)
                    {
                        time3 += clock.ElapsedTicks;
                    }
                }
                time1 /= 2;
                time2 /= 2;
                time3 /= 2;
                lines1.Add(size.ToString() + " " + time1.ToString());
                lines2.Add(size.ToString() + " " + time2.ToString());
                lines3.Add(size.ToString() + " " + time3.ToString());
                Console.WriteLine(size.ToString() + " complete");
            }
            string path = "C:/Users/MrSklif/source/repos/MrSkl1f/AnalysisOfAlgorithms/Reports/Lab4/source/";
            File.AppendAllLines(path + "SecondExp1.dat", lines1);

            File.AppendAllLines(path + "SecondExp2.dat", lines2);
            File.AppendAllLines(path + "SecondExp3.dat", lines3);
        }

    }
}
