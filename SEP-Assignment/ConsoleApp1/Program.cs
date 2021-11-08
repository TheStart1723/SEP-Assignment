using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static void BytesOfTypes()
        {
            Console.WriteLine("{0,-10} {1,5} {2,20} {3,35}", "Type", "Number of Bytes", "Minimum Value", "Maximum Value");
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "short", sizeof(short), short.MinValue, short.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "int", sizeof(int), int.MinValue, int.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "long", sizeof(long), long.MinValue, long.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "float", sizeof(float), float.MinValue, float.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "double", sizeof(double), double.MinValue, double.MaxValue);
            Console.WriteLine("{0,-10} {1,5} {2,25} {3,35}", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
        }

        public static void ConvertCentury()
        {
            int century = Convert.ToInt32(Console.ReadLine());
            int year = century * 100;
            uint day = (uint)(century * 36524);
            uint hour = (uint)(century * 876576);
            uint minute = (uint)(century * 52594560);
            ulong second = (ulong)(century * 3155673600);
            ulong millisecond = (ulong)(century * 3155673600000);
            ulong nanosecond = (ulong)(century * 3155673600000000000);
            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} nanoseconds",
                century, year, day, hour, minute, second, millisecond, nanosecond);
        }

        public static void FizzBuzz()
        {
            int num = int.Parse(Console.ReadLine());
            if (num % 15 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (num % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else
            {
                Console.WriteLine("buzz");
            }
        }

        private static void WriteLine(byte i)
        {
            throw new NotImplementedException();
        }

        public static void Guess()
        {
            int correctNumber = new Random().Next(3) + 1;
            int guessedNumber = int.Parse(Console.ReadLine());
            if (guessedNumber == correctNumber)
            {
                Console.WriteLine("Correct Answer");
            }
            else if(1 <= guessedNumber && guessedNumber < correctNumber)
            {
                Console.WriteLine("Low Answer");
            }
            else if(3 >= guessedNumber && guessedNumber > correctNumber)
            {
                Console.WriteLine("High Answer");
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
        }

        public static void PrintAPyramid()
        {
            int line = int.Parse(Console.ReadLine());
            for (int i = 1; i <= line; i++)
            {
                int space = line - i;
                for (int j = 0; j < space; j++)
                {
                    Console.Write(" ");
                }
                int star = 2 * i - 1;
                for(int k = 0; k < star; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static void CalculateBirthday()
        {
            var date1 = new DateTime(1997, 3, 5);
            var date2 = DateTime.Now;
            TimeSpan ts = date2.Subtract(date1);
            Console.WriteLine((int)(ts.TotalDays));
        }

        public static void Greeting()
        {
            var date = DateTime.Now;
            int hour = date.Hour;
            if (hour > 6 && hour <= 12)
            {
                Console.WriteLine("Good Morning");
            }
            if (hour > 12 && hour <= 18)
            {
                Console.WriteLine("Good Afternoon");
            }
            if (hour > 18 && hour <= 22)
            {
                Console.WriteLine("Good Evening");
            }
            if (hour > 22 || hour <= 6){
                Console.WriteLine("Good Night");
            }
        }

        public static void CountTo24()
        {
            for (int i = 1; i <= 4; i++)
            {
                int j;
                for (j = 0; j < 24;)
                {
                    Console.Write("{0},", j);
                    j += i;
                }
                Console.WriteLine("{0}", j);
            }
        }

        public static void CopyArray()
        {
            int[] array1 = {10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
            int[] array2 = new int[10];
            for (int i = 0; i < array1.Length; i++)
            {
                array2[i] = array1[i];
            }
            Console.WriteLine("[{0}]", string.Join(", ", array1));
            Console.WriteLine("[{0}]", string.Join(", ", array2));
        }

        public static void ManageList()
        {
            var toDoList = new List<string>() { "Apple", "Banana", "Orange", "Avacado" };
            while (true)
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
                var operation = Console.ReadLine().Split(' ');
                switch (operation[0])
                {
                    case "+":
                        toDoList.Add(operation[1]);
                        break;

                    case "-":
                        toDoList.Remove(operation[1]);
                        break;

                    case "--":
                        toDoList.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }

                Console.WriteLine("[{0}]", string.Join(", ", toDoList));
            }
        }

        public static void RotateArray()
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
            int k = int.Parse(Console.ReadLine());
            int n = arr.Length;
            int[] sum = new int[n];
            for (int i = 1; i <= k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum[(j + i) % n] += arr[j];
                }
            }
            Console.WriteLine("{0}", string.Join(" ", sum));
        }

        public static void LongestSequence()
        {
            while (true)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
                int bestCount = 0, bestElement = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    int repeat = 1;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if(arr[i] == arr[j])
                        {
                            repeat++;
                        } else
                        {
                            break;
                        }
                    }
                    if (repeat > bestCount)
                    {
                        bestCount = repeat;
                        bestElement = arr[i];
                    }
                }
                for (int k = 0; k < bestCount; k++)
                {
                    Console.Write("{0} ", bestElement);
                }
                Console.WriteLine();

            }
        }

        public static void FrequentNumber()
        {
            while (true)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
                int bestoccur = 0, bestelemt = 0;
                var hashSet = new HashSet<int>(arr);
                int[] uniq = hashSet.ToArray();
                Console.WriteLine("{0}", string.Join(" ", uniq));
                for (int i = 0; i < uniq.Length; i++)
                {
                    int occur = arr.Count(e => e == uniq[i]);
                    if (occur > bestoccur)
                    {
                        bestoccur = occur;
                        bestelemt = uniq[i];
                    }
                }
                Console.WriteLine("The left most of them is {0}", bestelemt);

            }
        }

        public static void ReverseString()
        {
            string s = Console.ReadLine();
            char[] ch = s.ToCharArray();
            Array.Reverse(ch);
            Console.WriteLine(new string(ch));
            string reverse = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                reverse += s[s.Length - i - 1];
            }
            Console.WriteLine(reverse);
        }

        public static void ReverseWords()
        {
            char[] seporators = {'.',',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', '(', ' ', ')'};
            string s = Console.ReadLine();
            string result2 = string.Join(string.Empty, System.Text.RegularExpressions.Regex.Split(s, @"([^\w]+)").Reverse());
            Console.WriteLine(result2);
        }
        public static void ExtractPalindrome()
        {
            var hs = new SortedSet<string>();
            char[] seporators = {' ', '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', '(', ')' };
            string s = Console.ReadLine();
            string[] words = s.Split(seporators);
            foreach (string i in words)
            {
                char[] ch = i.ToCharArray();
                Array.Reverse(ch);
                string rv = new(ch);
                if (rv == i && !hs.Contains(i) && i != "")
                {
                    hs.Add(i);
                }

            }
            Console.WriteLine("{0}", string.Join(", ", hs));
        }

        public static void Parse()
        {
            Uri url = new Uri(Console.ReadLine());
            Console.WriteLine($"[protocol] = \"{url.Scheme}\"\n" +
                $"[server] = \"{url.Host}\"\n" +
                $"[resource] = \"{url.AbsolutePath}\"");
        }

        static void Main(string[] args)
        {
            //string userColor, astrologySign, addressNumber;
            //Console.WriteLine("What's your favorite color?");
            //userColor = Console.ReadLine();
            //Console.WriteLine("What's your astrology sign? ");
            //astrologySign = Console.ReadLine();
            //Console.WriteLine("What's your street address number?");
            //addressNumber = Console.ReadLine();
            //Console.WriteLine($"Your hacker name is {userColor}{astrologySign}{addressNumber}");

            //BytesOfTypes();

            //ConvertCentury();

            //FizzBuzz();

            //try
            //{
            //    int max = 500;
            //    for (byte i = 0; i < max; i++)
            //    {
            //        WriteLine(i);
            //    }
            //}
            //catch (NotImplementedException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //Guess();

            //PrintAPyramid();
            //CalculateBirthday();
            //Greeting();
            //CountTo24();
            //CopyArray();
            //ManageList();
            //RotateArray();
            //LongestSequence();
            //FrequentNumber();
            //ReverseString();
            //ReverseWords();
            //ExtractPalindrome();
            Parse();
        }
    }
}