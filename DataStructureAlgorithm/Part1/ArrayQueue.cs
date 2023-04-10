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
        int count;

        public ArrayQueue(int size)
        {
            array = new int[size];
        }
        public void enqueue(int item)
        {
            if (count >= array.Length)
                throw new Exception();
            array[frontIndex] = item;
            frontIndex = (frontIndex + 1) % array.Length;
            count++;
        }
        public int dequeue()
        {
            int current = array[backIndex];
            array[backIndex] = 0;
            backIndex = (backIndex + 1) % array.Length;
            count--;
            return current;
        }
        public int peek()
        {
            return array[backIndex];
        }
        public Boolean isEmpty()
        {
            return count == 0;
        }
        public Boolean isFull()
        {
            return count == array.Length;
        }
    }
}
