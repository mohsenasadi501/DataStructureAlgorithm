using DataStructureAlgorithm.Part1;

StackQueue stackQueue = new StackQueue();
stackQueue.enqueue(10);
stackQueue.enqueue(20);
stackQueue.enqueue(30);
stackQueue.enqueue(40);
stackQueue.enqueue(50);
stackQueue.enqueue(60);


ArrayQueue queue = new ArrayQueue(5);
queue.enqueue(1);
queue.enqueue(2);
queue.enqueue(3);
queue.enqueue(4);
queue.enqueue(5);

queue.dequeue();
queue.dequeue();
queue.dequeue();

queue.enqueue(6);
queue.enqueue(7);
queue.enqueue(8);

queue.dequeue();
queue.dequeue();

queue.enqueue(9);
queue.enqueue(10);
queue.enqueue(11);
queue.enqueue(12);
queue.enqueue(13);

//Queue<int> queue = new Queue<int>();
//queue.Enqueue(1);
//queue.Enqueue(2);
//queue.Enqueue(3);
//queue.Enqueue(4);
//queue.Enqueue(5);
//queue.Dequeue();
//queue.Dequeue();

Console.WriteLine("*** Stacks ***");

string str = "MohsenAsadi";
var  reverser =  new StringReverser();
Console.WriteLine(reverser.Reverse(str));

Stack<int> stack = new Stack<int>();    
stack.Push(10);
stack.Push(20);
stack.Push(30);
var item = stack.Pop();
Console.WriteLine(item);

Console.WriteLine("*** LinkedList ***");
LinkedList mLinkedList = new LinkedList();
mLinkedList.AddLast(10);
mLinkedList.AddLast(20);
mLinkedList.AddLast(30);
mLinkedList.AddLast(40);
mLinkedList.AddLast(40);
Console.WriteLine(mLinkedList.IndexOf(30));


Console.WriteLine("*** Array ***");
DataStructureAlgorithm.Part1.Array array = new DataStructureAlgorithm.Part1.Array(2);
array.Add(10);
array.Add(20);
array.Add(30);
array.Add(40);
array.Add(50);
array.Add(60);
array.Add(70);
array.Add(80);
array.Add(90);
array.Add(100);

array.Remove(5);
array.IndexOf(60);
array.Print();

Console.ReadKey();