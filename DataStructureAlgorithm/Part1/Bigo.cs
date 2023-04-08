namespace DataStructureAlgorithm.Part1
{
    internal class Bigo
    {
        public void log(int[] numbers)
        {
            //o(1)
            Console.WriteLine(numbers[0]);
        }
        public void logLoop(int[] numbers, string[] texts)
        {
            //O(n) == O(n + m)

            //o(n)
            foreach (var item in numbers)
                Console.WriteLine(item);
            //o(m)
            foreach (var item in texts)
                Console.WriteLine(item);
        }
        public void LogNestedLoop(int[] numbers)
        {
            //o(n^3)
            foreach (var item in numbers)
                foreach (var item1 in numbers)
                    foreach (var item2 in numbers)
                        Console.WriteLine(item2);
        }
    }
}
