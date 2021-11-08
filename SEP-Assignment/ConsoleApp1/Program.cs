using System;

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
            CountTo24();
        }
    }
}