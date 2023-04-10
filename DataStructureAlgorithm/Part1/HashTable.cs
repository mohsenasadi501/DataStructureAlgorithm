namespace DataStructureAlgorithm.Part1
{
    internal class HashTable
    {
        internal class Entry
        {
            public int Key;
            public string Value;
            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }
        private LinkedList<Entry>[] _array;
        public HashTable(int size)
        {
            _array = new LinkedList<Entry>[size];
        }

        public void put(int key, string value)
        {
            // if you have sting key, should first convert key to int using GetHashCode function and store it
            var hashkey = hash(key);
            if (_array[hashkey] == null)
            {
                var linked = new LinkedList<Entry>();
                linked.AddLast(new Entry(key, value));
                _array[hashkey] = linked;
            }
            else
            {
                foreach (var item in _array[hashkey])
                {
                    if (item.Key == key)
                    {
                        item.Value = value;
                        return;
                    }
                }
                var linkedList = _array[hashkey];
                linkedList.AddLast(new Entry(key, value));
            }
        }
        public Entry get(int key)
        {
            var hashkey = hash(key);
            var item = _array[hashkey];
            if (item != null)
                return item.Single(x => x.Key == key);
            else
                return null;
        }
        public void remove(int key)
        {
            var hashkey = hash(key);
            if (_array[hashkey] == null)
                throw new Exception();
            else
            {
                var item = _array[hashkey];
                if (item.Count == 1)
                    _array[hashkey] = null;
                else
                {
                    var innerItem = item.Single(x => x.Key == key);
                    _array[hashkey].Remove(innerItem);
                }
            }
        }
        private int hash(int key)
        {
            return key % _array.Length;
        }
    }
}
