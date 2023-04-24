using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part2
{
    internal class HeapTree
    {
        private int[] items = new int[10];
        private int size;

        public void insert(int value)
        {
            if (size == items.Length)
                throw new OverflowException();

            items[size++] = value;

            bubbleUp();
        }
        public bool isFull()
        {
            return size == items.Length;
        }
        private void bubbleUp()
        {
            var index = size - 1;
            while (index > 0 && items[index] > items[parent(index)])
            {
                swap(index, parent(index));
                index = parent(index);
            }
        }
        private int parent(int index)
        {
            return (index - 1) / 2;
        }
        private void swap(int first, int second)
        {
            var temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }
    }
}
