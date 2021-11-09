using System;
using System.Collections.Generic;
using System.Net;

namespace ConsoleApp2
{
    class Program
    {
        private static int[] GenerateNumbers()
        {
            int[] arr = new int[10];
            Random rn = new Random();
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rn.Next();
            }
            return arr;
        }

        private static void Reverse(int[] numbers)
        {
            int temp;
            for (int i = 0; i < numbers.Length/2; i++)
            {
                temp = numbers[i];
                numbers[i] = numbers[numbers.Length - i - 1];
                numbers[numbers.Length - i - 1] = temp;
            }
        }
        private static void PrintNumbers(int[] numbers)
        {
            Console.WriteLine("{0}", string.Join(", ", numbers));
        }

        private static int Fibonacci(int n)
        {
            if (n == 1 || n == 0)
            {
                return n;
            }
            else return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static int GetWorkingDays(DateTime from, DateTime to)
        {
            var totalDays = 0;
            var holidays = new List<DateTime> { new DateTime(2021, 1, 1), 
                                                new DateTime(2021, 1, 18), 
                                                new DateTime(2021, 1, 20),
                                                new DateTime(2021, 2, 15),
                                                new DateTime(2021, 5, 31),
                                                new DateTime(2021, 6, 18),
                                                new DateTime(2021, 7, 5),
                                                new DateTime(2021, 9, 6),
                                                new DateTime(2021, 10, 11),
                                                new DateTime(2021, 11, 11),
                                                new DateTime(2021, 11, 25),
                                                new DateTime(2021, 12, 24)};
            for (var date = from.AddDays(1); date <= to; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday
                    && !holidays.Contains(date))
                    totalDays++;
            }

            return totalDays;
        }

        static void Main(string[] args)
        {
            //int[] numbers = GenerateNumbers();
            //Console.WriteLine("{0}", string.Join(", ", numbers));
            //Reverse(numbers);
            //PrintNumbers(numbers);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write(Fibonacci(i)+" ");
            //}

            //var from = new DateTime(2021, 11, 8);
            //var to = new DateTime(2021, 12, 31);
            //int days = GetWorkingDays(from, to);
            //Console.WriteLine(days);
        }
    }
}
