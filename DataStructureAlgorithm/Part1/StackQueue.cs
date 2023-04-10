namespace DataStructureAlgorithm.Part1
{
    internal class StackQueue
    {
        Stack<int> stack1;
        Stack<int> stack2;
        public StackQueue()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }
        //O(1)
        public void enqueue(int item)
        {
            stack1.Push(item);
        }
        //O(n)
        public int dequeue()
        {
            if (stack1.Count == 0 && stack2.Count == 0)
                throw new Exception();

            if (stack2.Count == 0)
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            return stack2.Pop();
        }
        public bool isEmpty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }
    }
}
