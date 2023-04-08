namespace DataStructureAlgorithm.Part1
{
    internal class Array
    {
        private int[] array;
        private int count;
        public Array(int length)
        {
            array = new int[length];
        }

        public void Add(int item)
        {
            if (count == array.Length)
            {
                int[] copyArray = array;
                array = new int[count * 2];
                for (int index = 0; index < count; index++)
                    array[index] = copyArray[index];
            }
            array[count++] = item;
        }
        public void Print()
        {
            if (count > 0)
                for (int index = 0; index < count; ++index)
                    Console.WriteLine(array[index]);
        }
        public void Remove(int index)
        {
            if (index > count || index < 0)
                throw new IndexOutOfRangeException();

            for (int i = index; i < count; ++i)
                array[i] = array[i + 1];
            count--;
        }
        public int IndexOf(int value)
        {
            for (int i = 0; i < count; i++)
                if (array[i] == value)
                    return i;
            return -1;
        }
    }
}
