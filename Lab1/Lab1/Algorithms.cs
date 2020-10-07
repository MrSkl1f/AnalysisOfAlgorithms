using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Lab1
{
    class Algorithms
    {
        private static int Min(int first, int second, int third)
        {
            int[] arr = { first, second, third };
            return arr.Min();
        }

        public static int LevTable(string firstStr, string secondStr, bool output = true)
        {
            int lenFirstStr = firstStr.Length + 1;
            int lenSecondStr = secondStr.Length + 1;

            int[,] table = new int[lenFirstStr, lenSecondStr];
            for (int i = 0; i < lenFirstStr; i++)
                for (int j = 0; j < lenSecondStr; j++) { table[i, j] = i + j; }

            int isNotEqual = 1;
            for (int i = 1; i < lenFirstStr; i++)
            {
                for (int j = 1; j < lenSecondStr; j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1]) { isNotEqual = 0; }
                    table[i, j] = Min(table[i - 1, j] + 1,
                                      table[i, j - 1] + 1,
                                      table[i - 1, j - 1] + isNotEqual);
                    isNotEqual = 1;
                }
            }
            if (output)
            {
                Console.WriteLine("Таблица");
                for (int i = 0; i < lenFirstStr; i++)
                {
                    for (int j = 0; j < lenSecondStr; j++) { Console.Write(String.Format("{0, 3}", table[i, j])); }
                    Console.WriteLine();
                }
            }
            return table[lenFirstStr - 1, lenSecondStr - 1];
        }

        public static int LevRecursion(string firstStr, string secondStr)
        {
            if (firstStr == "" || secondStr == "") { return Math.Abs(firstStr.Length - secondStr.Length); }
            int isNotEqual = 1;
            if (firstStr[firstStr.Length - 1] == secondStr[secondStr.Length - 1]) { isNotEqual = 0; }
            return Min(LevRecursion(firstStr, secondStr.Substring(0, secondStr.Length - 1)) + 1,
                       LevRecursion(firstStr.Substring(0, firstStr.Length - 1), secondStr) + 1,
                       LevRecursion(firstStr.Substring(0, firstStr.Length - 1), secondStr.Substring(0, secondStr.Length - 1)) + isNotEqual);
        }

        public static int LevDamTable(string firstStr, string secondStr, bool output = true)
        {
            int lenFirstStr = firstStr.Length + 1;
            int lenSecondStr = secondStr.Length + 1;

            int[,] table = new int[lenFirstStr, lenSecondStr];
            for (int i = 0; i < lenFirstStr; i++)
                for (int j = 0; j < lenSecondStr; j++) { table[i, j] = i + j; }

            int isNotEqual = 1;
            for (int i = 1; i < lenFirstStr; i++)
            {
                for (int j = 1; j < lenSecondStr; j++)
                {
                    if ((i > 1 && j > 1) && firstStr[i - 1] == secondStr[j - 2] && firstStr[i - 2] == secondStr[j - 1])
                        table[i, j] = Math.Min(table[i, j], table[i - 2, j - 2] + 1);
                    else
                    {
                        if (firstStr[i - 1] == secondStr[j - 1]) { isNotEqual = 0; }
                        table[i, j] = Min(table[i - 1, j] + 1,
                                          table[i, j - 1] + 1,
                                          table[i - 1, j - 1] + isNotEqual);
                    }
                    isNotEqual = 1;
                }
            }
            if (output)
            {
                Console.WriteLine("Таблица");
                for (int i = 0; i < lenFirstStr; i++)
                {
                    for (int j = 0; j < lenSecondStr; j++) { Console.Write(String.Format("{0, 3}", table[i, j])); }
                    Console.WriteLine();
                }
            }
            return table[lenFirstStr - 1, lenSecondStr - 1];
        }

        // Вычисляет минимальное из 3 значений
        private static int GetMinValue(int[,] table, string first, string second, int lenFirst, int lenSecond)
        {
            int isNotEqual = (first[lenFirst - 1] == second[lenSecond - 1]) ? 0 : 1;
            int firstParam = FindLevDistance(table, first, second.Substring(0, lenSecond - 1)) + 1;
            int secondParam = FindLevDistance(table, first.Substring(0, lenFirst - 1), second) + 1;
            int thirdParam = FindLevDistance(table, first.Substring(0, lenFirst - 1), second.Substring(0, lenSecond - 1)) + isNotEqual;
            return Min(firstParam, secondParam, thirdParam);
        }

        private static int FindLevDistance(int[,] table, string first, string second)
        {
            int lenFirst = first.Length;
            int lenSecond = second.Length;

            if (lenFirst == 0 || lenSecond == 0)
            {
                table[lenFirst, lenSecond] = Math.Abs(lenFirst - lenSecond);
                return table[lenFirst, lenSecond];
            }

            if (table[lenFirst, lenSecond] == -1)
                table[lenFirst, lenSecond] = GetMinValue(table, first, second, lenFirst, lenSecond);
            return table[lenFirst, lenSecond];
        }

        // Подгатавливает данные и таблицу
        public static int LevTableRec(string firstStr, string secondStr, bool output = true)
        {
            int lenFirstStr = firstStr.Length + 1;
            int lenSecondStr = secondStr.Length + 1;
            int[,] table = new int[lenFirstStr, lenSecondStr];
            for (int i = 0; i < lenFirstStr; i++)
                for (int j = 0; j < lenSecondStr; j++) { table[i, j] = -1; }

            int res;
            if (lenFirstStr - 1 == 0 || lenSecondStr - 1 == 0)
                res = Math.Abs((lenFirstStr - 1) - (lenSecondStr - 1));
            else
                res = GetMinValue(table, firstStr, secondStr, lenFirstStr - 1, lenSecondStr - 1);

            if (output)
            {
                Console.WriteLine("RecTable");
                for (int i = 0; i < lenFirstStr; i++)
                {
                    for (int j = 0; j < lenSecondStr; j++) { Console.Write(String.Format("{0, 3}", table[i, j])); }
                    Console.WriteLine();
                }
            }
            return res;
        }

        private static string CreateRandString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }

        public static void CheckTime()
        {
            Stopwatch clock = new Stopwatch();
            string first, second;
            var count = 7;
            /*
            first = CreateRandString(count);
            second = CreateRandString(count);
            clock.Restart();
            int res = LevTable(first, second, false);
            clock.Stop();
            Console.WriteLine(clock.ElapsedTicks);
            */

            first = CreateRandString(count);
            second = CreateRandString(count);
            clock.Restart();
            int res = LevRecursion(first, second);
            clock.Stop();
            var result = clock.ElapsedTicks;

            Console.WriteLine(result);
            /*

            first = CreateRandString(count);
            second = CreateRandString(count);
            clock.Restart();
            res = LevTableRec(first, second, false);
            clock.Stop();
            Console.WriteLine(clock.ElapsedTicks);
            
            first = CreateRandString(count);
            second = CreateRandString(count);
            clock.Restart();
            res = LevDamTable(first, second, false);
            clock.Stop();
                
            Console.WriteLine(clock.ElapsedTicks);
             */
        }
    }
}
