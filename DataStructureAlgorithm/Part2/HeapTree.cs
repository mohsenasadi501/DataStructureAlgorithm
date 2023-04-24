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
        public void remove()
        {
            if (isEmpty())
                throw new Exception();

            items[0] = items[--size];
            var index = 0;
            while (index <= size && !isValidParent(index))
            {
                var largeChildIndex = largerChildIndex(index);
                swap(index, largeChildIndex);
                index = largeChildIndex;
            }
        }
        public bool isEmpty()
        {
            return size == 0;
        }
        private int largerChildIndex(int index)
        {
            return (leftChild(index) > rightChild(index))
                ? leftChildIndex(index)
                : rightChildIndex(index);
        }
        private bool isValidParent(int index)
        {
            return items[index] >= leftChild(index) &&
                items[index] >= rightChild(index);
        }
        private int leftChild(int index)
        {
            return items[leftChildIndex(index)];
        }
        private int rightChild(int index)
        {
            return items[rightChildIndex(index)];
        }
        private int leftChildIndex(int index)
        {
            return index * 2 + 1;
        }
        private int rightChildIndex(int index)
        {
            return index * 2 + 2;
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
