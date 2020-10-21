using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Lab3
{
    static class Sort
    {
        public static void BubbleSort(Array arr)
        {
            int len = arr.N;
            for (int indI = 0; indI + 1 < len; indI++)
            {
                for (int indJ = 0; indJ + 1 < len - indI; indJ++)
                {
                    if (arr[indJ + 1] < arr[indJ])
                    { 
                        int tmp = arr[indJ];
                        arr[indJ] = arr[indJ + 1];
                        arr[indJ + 1] = tmp;
                    }
                }
            }
        }

        public static void SelectionSort(Array arr)
        {
            int len = arr.N;
            for (int i = 0; i < len - 1; i++)
            {
                int select = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (arr[j] < arr[select])
                    {
                        select = j;
                    }

                }
                int tmp = arr[select];
                arr[select] = arr[i];
                arr[i] = tmp;
            }
        }

        public static void InsertionSort(Array arr)
        {
            int len = arr.N;
            for (int i = 1; i < len; i++)
            {
                int x = arr[i];
                int j = i - 1;
                for (; j >= 0 && arr[j] > x; j--)
                {
                    arr[j + 1] = arr[j];
                }
                arr[j + 1] = x;
            }
        }

        public static void TestSort()
        {
            Stopwatch clock = new Stopwatch();
            for (int i = 0; i <= 500; i += 100)
            {
                Array arr = new Array(i);
                Array tmpArr = new Array(i);
                arr.Fill();
                
                for (int _ = 0; _ < 3; _++)
                {
                    arr.Copy(tmpArr);
                    
                    // ------ Bubble Sort -------
                    clock.Restart();
                    BubbleSort(tmpArr);
                    clock.Stop();
                    var res = clock.ElapsedTicks;
                    Console.WriteLine("Result bubble sort with " + Convert.ToString(i) + " is " + Convert.ToString(res));
                    // --------------------------

                    arr.Copy(tmpArr);

                    // ----- Selection Sort -----
                    clock.Restart();
                    SelectionSort(tmpArr);
                    clock.Stop();
                    res = clock.ElapsedTicks;
                    Console.WriteLine("Result selection sort with " + Convert.ToString(i) + " is " + Convert.ToString(res));
                    // --------------------------

                    arr.Copy(tmpArr);
                    
                    // ----- Insertion Sort -----
                    clock.Restart();
                    InsertionSort(tmpArr);
                    clock.Stop();
                    res = clock.ElapsedTicks;
                    Console.WriteLine("Result selection sort with " + Convert.ToString(i) + " is " + Convert.ToString(res));
                    // --------------------------
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}

