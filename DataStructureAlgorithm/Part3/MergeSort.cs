using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part3
{
    public class MergeSort
    {
        public void sort(int[] array)
        {
            if (array.Length < 2)
                return;

            //divide array into half
            var middle = array.Length / 2;
            int[] left = new int[middle];
            for (int i = 0; i < middle; i++)
                left[i] = array[i];

            int[] right = new int[array.Length - middle];
            for (int i = middle; i < array.Length; i++)
                right[i - middle] = array[i];

            //sort each half 
            sort(left);
            sort(right);
            //Merge the result

            merge(left, right, array);
        }
        private void merge(int[] left, int[] right, int[] result)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }
            while (i < right.Length)
                result[k++] = right[j++];

            while (j < left.Length)
                result[k++] = left[i++];

        }
    }
}
