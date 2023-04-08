namespace DataStructureAlgorithm.Part1
{
    internal class LinkedList
    {
        private class Node
        {
            public int value;
            public Node next;
            public Node(int value)
            {
                this.value = value;
            }
        }

        private Node first;
        private Node last;
        public int size;

        public void AddFirst(int item)
        {
            var mNode = new Node(item);
            if (first == null)
                last = first = mNode;
            else
            {
                mNode.next = first;
                first = mNode;
            }
            size++;
        }
        public void AddLast(int item)
        {
            var mNode = new Node(item);
            if (first == null)
                last = first = mNode;
            else
            {
                last.next = mNode;
                last = mNode;
            }
            size++;
        }
        public int IndexOf(int item)
        {
            int index = 0;
            var current = first;
            while (current != null)
            {
                if (current.value == item) return index;
                current = current.next;
                index++;
            }
            return -1;
        }
        public bool Contains(int value)
        {
            var current = first;
            while (current != null)
            {
                if (current.value == value) return true;
                current = current.next;
            }
            return false;
        }
        public void RemoveFirst()
        {
            if (first == null)
                throw new InvalidOperationException();
            if (first == last)
            {
                first = last = null;
                size--;
                return;
            }
            var second = first.next;
            first.next = null;
            first = second;
            size--;
        }
        public void RemoveLast()
        {
            var current = first;
            while (current != null)
            {
                if (current.next == last) break;
                current = current.next;
            }
            last = current;
            size--;
        }
        public int Size()
        {
            return size;
        }
        public int[] toArray()
        {
            int[] result = new int[size];
            var current = first;
            int index = 0;
            while (current != null)
            {
                result[index++] = current.value;
                current = current.next;
            }
            return result;
        }
    }
}
