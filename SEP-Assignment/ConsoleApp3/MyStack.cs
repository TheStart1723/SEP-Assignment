using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public static class MyStack <T> where T: struct
    {
        private static List<T> stack = new List<T>();
        public static int Count()
        {
            return stack.Count;
        }
        public static T Pop()
        {
            return stack[stack.Count - 1];
        }
        public static void Push(T x)
        {
            stack.Add(x);
        }
    }
}
