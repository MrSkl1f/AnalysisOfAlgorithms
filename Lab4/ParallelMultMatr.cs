using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Lab4
{
    static class ParallelMultMatr
    {
        private static void ComputationLoopForMain (object curObj)
        {
            ParametersForFirst param = (ParametersForFirst)curObj;
            int startI  = param.startI, 
                endI    = param.endI,
                m2      = param.m2, 
                m1      = param.m1;
            Matrix res  = param.res,
                matr1   = param.matr1,
                matr2   = param.matr2;
            int[] mulH  = param.mulH,
                mulV    = param.mulV;

            for (int i = startI; i < endI; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    res[i, j] = -mulH[i] - mulV[j];
                    for (int k = 0; k < m1 / 2; k++)
                    {
                        res[i, j] += (matr1[i, 2 * k + 1] + matr2[2 * k, j]) * (matr1[i, 2 * k] + matr2[2 * k + 1, j]);
                    }
                }
            }
        }

        private static void ComputationLoopForMulH (object curObj)
        {
            ParametersForSecond param = (ParametersForSecond)curObj;
            int startI  = param.startI,
                endI    = param.endI,
                endJ    = param.endJ;
            Matrix matr = param.matr;
            int[] mul   = param.mul;

            for (int i = startI; i < endI; i++)
            {
                for (int j = 0; j < endJ / 2; j++)
                {
                    mul[i] += matr[i, j * 2] * matr[i, j * 2 + 1];
                }
            }
        }

        private static void ComputationLoopForMulV(object curObj)
        {
            ParametersForSecond param = (ParametersForSecond)curObj;
            int startI = param.startI,
                endI = param.endI,
                endJ = param.endJ;
            Matrix matr = param.matr;
            int[] mul = param.mul;

            for (int i = startI; i < endI; i++)
            {
                for (int j = 0; j < endJ / 2; j++)
                {
                    mul[i] += matr[j * 2, i] * matr[j * 2 + 1, i];
                }
            }
        }

        public static Matrix ParallelVinogradMult1(Matrix matr1, Matrix matr2, int countOfThreads)
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
            int[] mulH = new int[n1];
            int[] mulV = new int[m2];

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

            Thread[] threads = new Thread[countOfThreads];
            int distribution = n1 / countOfThreads;
            int startI = 0;
            for (int i = 0; i < countOfThreads; i++)
            {
                int endI = startI + distribution;
                if (i == countOfThreads - 1)
                {
                    endI = n1;
                }
                ParametersForFirst param = new ParametersForFirst(result, matr1, matr2, mulV, mulH, startI, endI, m2, m1);
                threads[i] = new Thread(ComputationLoopForMain);
                threads[i].Start(param);
                startI = endI;
            }
            foreach (Thread curThread in threads)
            {
                curThread.Join();
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

        public static Matrix ParallelVinogradMult2(Matrix matr1, Matrix matr2, int countOfThreads)
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
            int[] mulH = new int[n1];
            int[] mulV = new int[m2];

            Thread[] threads = new Thread[countOfThreads];
            
            int distribution = n1 / countOfThreads;
            int startI = 0;
            for (int i = 0; i < countOfThreads; i++)
            {
                int endI = startI + distribution;
                if (i == countOfThreads - 1)
                {
                    endI = n1;
                }
                ParametersForSecond param = new ParametersForSecond(matr1, mulH, startI, endI, m1);
                threads[i] = new Thread(ComputationLoopForMulH);
                threads[i].Start(param);
                startI = endI;
            }
            foreach (Thread curThread in threads)
            {
                curThread.Join();
            }

            distribution = m2 / countOfThreads;
            startI = 0;
            for (int i = 0; i < countOfThreads; i++)
            {
                int endI = startI + distribution;
                if (i == countOfThreads - 1)
                {
                    endI = n1;
                }
                ParametersForSecond param = new ParametersForSecond(matr2, mulV, startI, endI, n2);
                threads[i] = new Thread(ComputationLoopForMulV);
                threads[i].Start(param);
                startI = endI;
            }
            foreach (Thread curThread in threads)
            {
                curThread.Join();
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
    }
}
