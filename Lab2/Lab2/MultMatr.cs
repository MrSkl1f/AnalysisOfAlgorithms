using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Lab2
{
    class MultMatr
    {
        public static Matrix StandartMult(Matrix matr1, Matrix matr2)
        {
            int n1 = matr1.N;
            int n2 = matr2.N;
            int m1 = matr1.M;
            int m2 = matr2.M;
            if ((m1 != n2) || n1 == 0 || n2 == 0)
            {
                return null;
            }

            Matrix result = new Matrix(n1, m2);

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    for (int k = 0; k < m1; k++)
                    {
                        result[i, j] += matr1[i, k] * matr2[k, j];
                    }
                }
            }
            return result;
        }

        public static Matrix VinogradMult(Matrix matr1, Matrix matr2)
        {
            int n1 = matr1.N;
            int n2 = matr2.N;
            int m1 = matr1.M;
            int m2 = matr2.M;
            if ((m1 != n2) || n1 == 0 || n2 == 0)
            {
                return null;
            }

            Matrix result = new Matrix(n1, m2);
            Array mulH = new Array(n1);
            Array mulV = new Array(m2);

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m1 / 2; j++)
                {
                    mulH[i] += matr1[i, j * 2] * matr1[i, j * 2 + 1];
                }
            }
            for (int i = 0; i < m2; i++)
            {
                for (int j = 0; j < n2 / 2; j++)
                {
                    mulV[i] += matr2[j * 2, i] * matr2[j * 2 + 1, i];
                }
            }
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    result[i, j] = -mulH[i] - mulV[j];
                    for (int k = 0; k < m1 / 2; k++)
                    {
                        result[i, j] += (matr1[i, 2 * k + 1] + matr2[2 * k, j]) * (matr1[i, 2 * k] + matr2[2 * k + 1, j]);
                    }
                }
            }

            if (m1 % 2 == 1)
            {
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        result[i, j] += matr1[i, m1 - 1] * matr2[m1 - 1, j];
                    }
                }
            }

            return result;
        }

        public static Matrix VinogradModMult(Matrix matr1, Matrix matr2)
        {
            int n1 = matr1.N;
            int n2 = matr2.N;
            int m1 = matr1.M;
            int m2 = matr2.M;
            if ((m1 != n2) || n1 == 0 || n2 == 0)
            {
                return null;
            }

            Matrix result = new Matrix(n1, m2);
            Array mulH = new Array(n1);
            Array mulV = new Array(m2);

            int smallerM = m1 % 2;
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < (m1 - smallerM); j += 2)
                {
                    mulH[i] -= matr1[i, j] * matr1[i, j + 1];
                }
            }

            int smallerN = n2 % 2;
            for (int i = 0; i < m2; i++)
            {
                for (int j = 0; j < (n2 - smallerN); j += 2)
                {
                    mulV[i] -= matr2[j, i] * matr2[j + 1, i];
                }
            }

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    int buff = mulH[i] + mulV[j];
                    for (int k = 0; k < (m1 - smallerM); k += 2)
                    {
                        buff += (matr1[i, k + 1] + matr2[k, j]) * (matr1[i, k] + matr2[k + 1, j]);
                    }
                    result[i, j] = buff;
                }
            }

            if (smallerM == 1)
            {
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        result[i, j] += matr1[i, m1 - 1] * matr2[m1 - 1, j];
                    }
                }
            }

            return result;
        }

        public static void testAlgorithms()
        {
            Matrix matr1;
            Matrix matr2;
            Matrix result;
            Stopwatch clock = new Stopwatch();
            for (int length = 1; length <= 501; length += 100)
            {
                matr1 = new Matrix(length, length);
                matr2 = new Matrix(length, length);
                matr1.FillMatr();
                matr2.FillMatr();
                for (int _ = 0; _ < 3; _++)
                { 
                    clock.Restart();
                    result = StandartMult(matr1, matr2);
                    clock.Stop();
                    var res = clock.ElapsedTicks;
                    Console.WriteLine("Result standart with " + Convert.ToString(length) + "x" + Convert.ToString(length) + " is " + Convert.ToString(res));
                    clock.Restart();
                    result = VinogradMult(matr1, matr2);
                    clock.Stop();
                    res = clock.ElapsedTicks;
                    Console.WriteLine("Result Vinograd with " + Convert.ToString(length) + "x" + Convert.ToString(length) + " is " + Convert.ToString(res));
                    clock.Restart();
                    result = VinogradModMult(matr1, matr2);
                    clock.Stop();
                    res = clock.ElapsedTicks;
                    Console.WriteLine("Result Mod Vinograd with " + Convert.ToString(length) + "x" + Convert.ToString(length) + " is " + Convert.ToString(res));
                    Console.WriteLine();
                }
                Console.WriteLine(); Console.WriteLine();
            }
        }
    }
}
