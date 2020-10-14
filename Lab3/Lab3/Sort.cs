using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    static class Sort
    {
        public static void BubbleSort(Array arr)
        {
            int len = arr.N;
            if (len == 0)
            {
                return;
            }

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

        public static void ShakerSort(Array arr)
        {
            int len = arr.N;
            if (len == 0)
            {
                return;
            }
            int left = 0;
            int right = len - 1;
            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = tmp;
                    }
                }
                left++;
            }
        }

        public static void InsertionSort(Array arr)
        {
            int len = arr.N;
            if (len == 0)
            {
                return;
            }
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
    }
}

