namespace DataStructureAlgorithm.Part3
{
    public class InsertionSort
    {
        public void sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var current = array[i];
                var j = i - 1;
                while (j >= 0 && array[j] > current)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = current;
            }
        }
    }
}
