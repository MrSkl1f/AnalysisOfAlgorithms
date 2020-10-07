using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
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
    }
}
