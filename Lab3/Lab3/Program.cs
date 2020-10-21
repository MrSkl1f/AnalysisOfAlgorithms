using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string check = "1";
            while (check == "1" || check == "2")
            {
                Console.Write("1 - Сортировать\n2 - Тест\nВвод: ");
                check = Console.ReadLine();
                if (check == "1")
                {
                    Console.Write("Введите количество элементов массива: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Array arr = new Array(n);
                    Array tmpArr = new Array(n);
                    arr.Fill();
                    arr.Read();

                    Console.Write("Bubble:\t\t");
                    arr.Copy(tmpArr);
                    Sort.BubbleSort(tmpArr);
                    tmpArr.Read();

                    Console.Write("Selection:\t");
                    arr.Copy(tmpArr);
                    Sort.SelectionSort(tmpArr);
                    tmpArr.Read();

                    Console.Write("Insertion:\t");
                    arr.Copy(tmpArr);
                    Sort.InsertionSort(tmpArr);
                    tmpArr.Read();
                }
                else if (check == "2")
                {
                    Sort.TestSort();
                }
            }
        }
    }
}
