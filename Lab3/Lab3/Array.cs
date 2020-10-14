using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Array
    {
        private int[] array;
        private int n;
        public Array() { }

        public Array(int n)
        {
            this.n = n;
            array = new int[n];
        }

        public int N
        {
            get { return n; }
            set { if (value > 0) n = 0; }
        }

        public int this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        public void Copy(Array arr)
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] = array[i];
            }
        }

        public void Read()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }

        public void Fill()
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(100);
            }
        }
    }
}
