namespace DataStructureAlgorithm.Part1
{
    internal class CharFinder
    {
        public Char FindFirstNonRepeatingChar(string input)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (var item in input.ToArray())
            {
                var count = map.ContainsKey(item) ? map[item] : 0;
                map[item] = count + 1;
            }
            foreach (var item in map)
                if (item.Value == 1) return item.Key;
            return ' ';
        }
    }
}
