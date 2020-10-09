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

            Matrix result1 = MultMatr.StandartMult(mat1, mat2);
            //Console.WriteLine("Первая матрица:");
            //mat1.ReadMatr();
            //Console.WriteLine("Вторая матрица:");
            //mat2.ReadMatr();
            //Console.WriteLine("Результат 1:");
            //result1.ReadMatr();

            Matrix result2 = MultMatr.StandartMult(mat1, mat2);
            //Console.WriteLine("Результат 2:");
            //result2 = MultMatr.VinogradMult(mat1, mat2);
            //result2.ReadMatr();
            //Console.WriteLine("Результат 3:");
            Matrix result3 = MultMatr.StandartMult(mat1, mat2);
            result3 = MultMatr.VinogradModMult(mat1, mat2);
            //result3.ReadMatr();


            int check = 1;
            for (int i = 0; i < result1.N; i++)
            {
                for (int j = 0; j < result1.M; j++)
                {
                    if (result1[i,j] != result2[i, j] || result1[i, j] != result3[i, j] || result2[i, j] != result3[i, j])
                    {
                        check = 0;
                    }
                }
            }
            if (check == 1)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
