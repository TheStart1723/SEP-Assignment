using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public static class MyList<T> where T: struct
    {
        private static List<T> list;
        public static void Add(T element)
        {
            list.Add(element);
        }
        public static T Remove(int index)
        {
            T element = list[index];
            list.RemoveAt(index);
            return element;
        }
        public static bool Contains(T element)
        {
            return list.Contains(element);
        }
        public static void Clear()
        {
            list.Clear();
        }
        public static void InsertAt(T element, int index)
        {
            list.Insert(index, element);
        }
        public static void DeleteAt(int index)
        {
            list.RemoveAt(index);
        }
        public static T Find(int index)
        {
            return list[index];
        }
    }
}
