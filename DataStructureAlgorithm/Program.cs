using DataStructureAlgorithm.Part1;
using DataStructureAlgorithm.Part2;
using DataStructureAlgorithm.Part3;

Console.WriteLine("Bubble Sort Implementation");
var sortArray = new int[] { 4, 5, 3, 8, 2, 1 };
BubbleSort bubbleSort = new BubbleSort();
bubbleSort.sort(sortArray);

Console.WriteLine("Tries Implementation");
TriesTree triesTree = new TriesTree();
triesTree.insert("mohsen");
triesTree.insert("mohammad");

Console.WriteLine("Heap Implementation");
HeapTree heapTree = new HeapTree();
heapTree.insert(7);
heapTree.insert(9);
heapTree.insert(8);
heapTree.insert(10);
heapTree.insert(4);
heapTree.insert(6);
heapTree.insert(1);

heapTree.remove();

Console.WriteLine("*** AVL Search Tree ***");
AvlTree avlTree = new AvlTree();
avlTree.insert(7);
avlTree.insert(9);
avlTree.insert(8);
avlTree.insert(10);
avlTree.insert(4);
avlTree.insert(6);
avlTree.insert(1);


Console.WriteLine("*** Binary Search Tree ***");

var fac = new Recursion().factorial(5);

Tree tree = new Tree();
tree.insert(7);
tree.insert(9);
tree.insert(8);
tree.insert(10);
tree.insert(4);
tree.insert(6);
tree.insert(1);

Tree tree1 = new Tree();
tree1.insert(7);
tree1.insert(9);
tree1.insert(8);
tree1.insert(10);
tree1.insert(4);
tree1.insert(6);
tree1.insert(1);

Console.WriteLine("Check Identical of two array");
Console.WriteLine(tree.equals(tree1));

Console.WriteLine("minimum value of tree");
Console.WriteLine(tree.min());

Console.WriteLine("Pre Order");
tree.traversePreorder();

Console.WriteLine("In Order");
tree.traverseInorder();

Console.WriteLine("Post Order");
tree.traversePostorder();


Console.WriteLine("The Height is:" + tree.height());

Console.WriteLine(tree.find(6));
Console.WriteLine(tree.find(20));

Console.WriteLine("*** HashTable ***");
HashTable hashTable = new HashTable(5);
hashTable.put(6, "Mohsen");
hashTable.put(8, "Asadi");
hashTable.put(11, "Ali");
hashTable.put(11, "Ehsan");
Console.WriteLine(hashTable.get(11).Value);


LinkedList linkedList = new LinkedList();
linkedList.AddFirst(1);
linkedList.AddFirst(2);
linkedList.AddFirst(3);
linkedList.AddFirst(4);
linkedList.AddFirst(5);

CharFinder charFinder = new CharFinder();
Console.WriteLine(charFinder.FindFirstNonRepeatingChar("A Green Apple"));

Dictionary<int, string> part1 = new Dictionary<int, string>();
part1.Add(0, "Mohsen");     //O(1)
part1.Add(1, "Jhon");
var containsValue = part1.ContainsValue("Mohsen");      //O(n)
var containsKey = part1.ContainsKey(10);                //O(1)

var dictionaryItem = part1.Single(x => x.Key == 0);     //O(1)

PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
priorityQueue.Enqueue(2, 1);
priorityQueue.Enqueue(3, 3);
priorityQueue.Enqueue(4, 2);

StackQueue stackQueue = new StackQueue();
stackQueue.enqueue(10);
stackQueue.enqueue(20);
stackQueue.enqueue(30);
stackQueue.enqueue(40);
stackQueue.enqueue(50);
stackQueue.enqueue(60);

//ArrayQueue queue = new ArrayQueue(5);
//queue.enqueue(1);
//queue.enqueue(2);
//queue.enqueue(3);
//queue.enqueue(4);
//queue.enqueue(5);

//queue.dequeue();
//queue.dequeue();
//queue.dequeue();

//queue.enqueue(6);
//queue.enqueue(7);
//queue.enqueue(8);

//queue.dequeue();
//queue.dequeue();

//queue.enqueue(9);
//queue.enqueue(10);
//queue.enqueue(11);
//queue.enqueue(12);
//queue.enqueue(13);

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
var reverser = new StringReverser();
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