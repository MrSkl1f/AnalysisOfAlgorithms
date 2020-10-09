using System;
using System.Collections.Generic;
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

            Matrix result = new Matrix(matr1.N, matr2.M);

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
                    mulH[i] = mulH[i] + matr1[i, j * 2] * matr1[i, j * 2 + 1];
                }
            }

            for (int i = 0; i < m2; i++)
            {
                for (int j = 0; j < n2 / 2; j++)
                {
                    mulV[i] = mulV[i] + matr2[j * 2, i] * matr2[j * 2 + 1, i];
                }
            }

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    result[i, j] = -mulH[i] - mulV[j];
                    for (int k = 0; k < m1 / 2; k++)
                    {
                        result[i, j] = result[i, j] + (matr1[i, 2 * k + 1] + matr2[2 * k, j]) * (matr1[i, 2 * k] + matr2[2 * k + 1, j]);
                    }
                }
            }

            if (m1 % 2 == 1)
            {
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        result[i, j] = result[i, j] + matr1[i, matr1.M - 1] * matr2[matr1.M - 1, j];
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

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < (m1 - m1 % 2); j += 2)
                {
                    mulH[i] += matr1[i, j] * matr1[i, j + 1];
                }
            }

            for (int i = 0; i < m2; i++)
            {
                for (int j = 0; j < (n2 - n2 % 2); j += 2)
                {
                    mulV[i] += matr2[j, i] * matr2[j + 1, i];
                }
            }

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    int buff = -(mulH[i] + mulV[j]);
                    for (int k = 0; k < (m1 - m1 % 2); k += 2)
                    {
                        buff += (matr1[i, k + 1] + matr2[k, j]) * (matr1[i, k] + matr2[k + 1, j]);
                    }
                    result[i, j] = buff;
                }
            }

            if (m1 % 2 == 1)
            {
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        result[i, j] += matr1[i, matr1.M - 1] * matr2[matr1.M - 1, j];
                    }
                }
            }

            return result;
        }
    }
}
