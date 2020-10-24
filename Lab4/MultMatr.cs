using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    static class MultMatr
    {
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
