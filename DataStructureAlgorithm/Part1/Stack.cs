using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part1
{
    internal class Stack
    {
        private int[] items = new int[5];
        private int count;

        public void push(int item)
        {
            if (count == items.Length)
                throw new StackOverflowException();
            items[count++] = item;

        }
        public int pop()
        {
            if (count == 0)
                throw new Exception();
            return items[--count];
        }
        public int peek()
        {
            if (count == 0)
                throw new Exception();
            return items[--count];
        }
    }
}
