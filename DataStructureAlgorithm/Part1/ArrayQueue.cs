using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part1
{
    internal class ArrayQueue
    {
        int[] array;
        int frontIndex;
        int backIndex;

        public ArrayQueue()
        {
            array = new int[10];
        }
        public void enqueue(int item)
        {
            if (array.Length == 0)
                frontIndex = backIndex = 1;
            array[frontIndex] = item;
        }
        public int dequeue()
        {
            return 0;
        }
        public int peek()
        {
            return 0;
        }
        public Boolean isEmpty()
        {
            return false;
        }
        public Boolean isFull()
        {
            return false;
        }
    }
}
