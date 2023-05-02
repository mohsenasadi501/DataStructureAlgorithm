using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part3
{
    public class SelectionSort
    {
        public void sort(int[] array)
        {
            // find the minumum item in array
            for (int j = 0; j < array.Length; j++)
            {
                int minindex = j;
                for (int index = minindex; index < array.Length; index++)
                    if (array[minindex] > array[index])
                        minindex = index;
                swap(array, minindex, j);   
            }
        }
        private void swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
