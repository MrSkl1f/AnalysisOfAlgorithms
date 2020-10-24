using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class Matrix
    {
        private int n;
        private int m;
        private int[,] matrix;

        public Matrix() { }
        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            matrix = new int[n, m];
        }

        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }
        public int M
        {
            get { return m; }
            set { if (value > 0) m = value; }
        }

        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public void InputMatr()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введите эелемент матрицы {0}:{1}", i + 1, j + 1);
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void ReadMatr()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void FillMatr()
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rand.Next(100);
                }
            }
        }
    }
}
