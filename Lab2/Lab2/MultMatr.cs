using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class MultMatr
    {
        public static Matrix StandartMult(Matrix matr1, Matrix matr2)
        {
            if (matr1.M != matr2.N)
            {
                return null;
            }

            Matrix result = new Matrix(matr1.N, matr2.M);

            for (int i = 0; i < matr1.N; i++)
            {
                for (int j = 0; j < matr2.M; j++)
                {
                    for (int k = 0; k < matr1.M; k++)
                    {
                        result[i, j] += matr1[i, k] * matr2[k, j];
                    }
                }
            }
            return result;
        }

        public static Matrix VinogradMult(Matrix matr1, Matrix matr2)
        {
            if (matr1.M != matr2.N)
            {
                return null;
            }

            Matrix result = new Matrix(matr1.N, matr2.M);
            Array mulH = new Array(matr1.N);
            Array mulV = new Array(matr2.M);

            for (int i = 0; i < matr1.N; i++)
            {
                for (int j = 0; j < matr1.M / 2; j++)
                {
                    mulH[i] = mulH[i] + matr1[i, j * 2] * matr1[i, j * 2 + 1];
                }
            }

            for (int i = 0; i < matr2.M; i++)
            {
                for (int j = 0; j < matr2.N / 2; j++)
                {
                    mulV[i] = mulV[i] + matr2[j * 2, i] * matr2[j * 2 + 1, i];
                }
            }

            for (int i = 0; i < matr1.N; i++)
            {
                for (int j = 0; j < matr2.M; j++)
                {
                    result[i, j] = -mulH[i] - mulV[j];
                    for (int k = 0; k < matr1.M / 2; k++)
                    {
                        result[i, j] = result[i, j] + (matr1[i, 2 * k + 1] + matr2[2 * k, j]) * (matr1[i, 2 * k] + matr2[2 * k + 1, j]);
                    }
                }
            }

            if (matr1.M % 2 == 1)
            {
                for (int i = 0; i < matr1.N; i++)
                {
                    for (int j = 0; j < matr2.M; j++)
                    {
                        result[i, j] = result[i, j] + matr1[i, matr1.M - 1] * matr2[matr1.M - 1, j];
                    }
                }
            }

            return result;
        }

        public static Matrix VinogradModMult(Matrix matr1, Matrix matr2)
        {
            if (matr1.M != matr2.N)
            {
                return null;
            }

            Matrix result = new Matrix(matr1.N, matr2.M);
            Array mulH = new Array(matr1.N);
            Array mulV = new Array(matr2.M);

            int n2Mod2 = matr2.N % 2;

            for (int i = 0; i < matr1.N; i++)
            {
                for (int j = 0; j < (matr1.M - matr1.M % 2); j += 2)
                {
                    mulH[i] += matr1[i, j] * matr1[i, j + 1];
                }
            }

            for (int i = 0; i < matr2.M; i++)
            {
                for (int j = 0; j < (matr2.N - matr2.N % 2); j += 2)
                {
                    mulV[i] += matr2[j, i] * matr2[j + 1, i];
                }
            }

            for (int i = 0; i < matr1.N; i++)
            {
                for (int j = 0; j < matr2.M; j++)
                {
                    int buff = -(mulH[i] + mulV[j]);
                    for (int k = 0; k < (matr1.M - matr1.M % 2); k += 2)
                    {
                        buff += (matr1[i, k + 1] + matr2[k, j]) * (matr1[i, k] + matr2[k + 1, j]);
                    }
                    result[i, j] = buff;
                }
            }

            if (matr1.M % 2 == 1)
            {
                int m1Min_1 = matr1.M - 1;
                for (int i = 0; i < matr1.N; i++)
                {
                    for (int j = 0; j < matr2.M; j++)
                    {
                        result[i, j] += matr1[i, m1Min_1] * matr2[m1Min_1, j];
                    }
                }
            }

            return result;
        }
    }
}
