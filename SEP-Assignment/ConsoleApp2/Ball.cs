using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Ball
    {
        public int Size { get; set; }
        public Color Color { get; set; }
        public int ThrowTime { get; set; }
        public Ball(int size, Color color)
        {
            Size = size;
            Color = color;
        }
        public void Pop()
        {
            Size = 0;
        }
        public void Throw()
        {
            if (Size == 0)
            {
                ThrowTime += 1;
            }
        }
    }
}
