using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part3
{
    public class BubbleSort
    {
        public void sort(int[] array)
        {
            bool isSorted = false;
            for (int i = 0; i < array.Length; i++)
            {
                isSorted = true;
                for (int j = 1; j < array.Length - 1; j++)
                {
                    if (array[j] < array[j - 1])
                    {
                        swap(array, j, j - 1);
                        isSorted = false;
                    }
                }
            }

            if (isSorted)
                return;
        }
        private void swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
