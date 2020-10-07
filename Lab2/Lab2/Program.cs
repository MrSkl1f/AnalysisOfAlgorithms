using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое n:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите первое m:");
            int m1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе n:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе m:");
            int m2 = Convert.ToInt32(Console.ReadLine());

            Matrix mat1 = new Matrix(n1, m1);
            Matrix mat2 = new Matrix(n2, m2);
            mat1.FillMatr();
            mat2.FillMatr();

            Matrix result = MultMatr.StandartMult(mat1, mat2);
            Console.WriteLine("Первая матрица:");
            mat1.ReadMatr();
            Console.WriteLine("Вторая матрица:");
            mat2.ReadMatr();
            Console.WriteLine("Результат 1:");
            result.ReadMatr();
            Console.WriteLine("Результат 2:");
            result = MultMatr.VinogradMult(mat1, mat2);
            result.ReadMatr();
            Console.WriteLine("Результат 3:");
            result = MultMatr.VinogradModMult(mat1, mat2);
            result.ReadMatr();
        }
    }
}
