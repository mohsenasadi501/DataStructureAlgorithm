using DataStructureAlgorithm.Part1;

Console.WriteLine("*** Stacks ***");

string str = "MohsenAsadi";
var  reverser =  new StringReverser();
Console.WriteLine(reverser.Reverse(str));

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