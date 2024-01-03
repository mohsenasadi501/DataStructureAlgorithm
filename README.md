# 1: Linear Data Structure

Linear data structures are organized in a particular order, and it is done so because the elements are ordered in a particular pattern.

In the first part of this document you will learn:

1. **[Big O Notation](#Big-O-Notation)**

2. **[Arrays](#Arrays)**

3. **[Linked Lists](#LinkedLists)**

4. **[Stacks](#Stacks)**

5. **[Queues](#Queues)**

6. **[Hash Tables](#HashTables)**

## Big-O-Notation

We use Big O Notation to describe the performance of the algorithm, time complexity and space complexity to express it, and how scalable the algorithm is.

The below codes show **O(1)** because the code runs in a constant time.

```csharp
 public void log(int[] numbers)
 {
     //o(1)
     Console.WriteLine(numbers[0]);
 }
```

```csharp
 public void logLoop(int[] numbers , string[] texts)
 {
     //O(n) == O(n + m)

     //o(n)
     foreach (var item in numbers)
         Console.WriteLine(item);

     //o(m)
     foreach(var item in texts)
         Console.WriteLine(item);
  }
```

```csharp
public void LogNestedLoop(int[] numbers)
 {
    //o(n^3)
    foreach (var item in numbers)
        foreach (var item1 in numbers)
            foreach (var item2 in numbers)
                Console.WriteLine(item2);
}
```

##### Types of BigO:

| Row | Name        | Big O Notation |
|:---:|:-----------:|:--------------:|
| 1   | Constant    | O(1)           |
| 2   | Logarithmic | O(log n)       |
| 3   | Linear      | O(n)           |
| 4   | Quadratic   | O(n^ 2)        |
| 5   | Exponential | O(2 ^ n)       |

![algorithm.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/algorithm.png)

As shown in the above image, constant-type algorithms grow linearly at the same rate but the logarithmic curve is down at some point, logarithmic is more efficient and scalable compared to linear or others. Exponential is the opposite of logarithmic and is not efficient to use and has a lot cost.

### What is Space Complexity?

Space complexity refers to the total amount of memory space used by an algorithm/program, including the space of input values for execution.

### What is Time Complexity?

It calculates the time taken to run an algorithm as the input grows. In other words, it calculates the worst-case time complexity of an algorithm. Big O Notation in Data Structure describes the upper bound of an algorithm's runtime.

## Arrays

Arrays are a simple data structure type used to store data sequentially, if you want to store data by index arrays are the best choice.

Features of Array Data Structure:

- Simple Data Structure
- The Items are fixed
- The length of the array is fixed
- You can not remove or add new Item 

Example of how to add Array class **Add**, **Remove**, **IndexOf** and **Print** methods functionality:

```csharp
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
```

###### Default assigned values of Array:

| Row | DataType          | Default Value |
|:---:|:-----------------:|:-------------:|
| 1   | boolean           | false         |
| 2   | int               | 0             |
| 3   | double            | 0.0           |
| 4   | String            | null          |
| 5   | User-Defined Type | null          |

## LinkedLists

Linked List stores objects in sequence, unlike Arrays, which can grow or shrink automatically like a below image.

![linkedlist.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/linkedlist.png)

In the linked list we have the first and last item of a list and recursively add another item to them.

The linked list implementation from scratch:

```csharp
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
```

As you can see above code we have a Node class that stores the value of the item and the next item that creates a connection to the next item.

### Arrays vs Linked Lists:

There are two different types of access: **random access** and **sequential access**

- [x] Sequential access means reading the elements one by one like **Linked List**.

- [x] Random access means you jump directly to the 10th element like **Array**.

We want to compare in terms of space and time complexity.

- Static arrays have a fixed size 

- Dynamic arrays grow by 50-100%

- Linked Lists don't waste memory

- Use arrays if you know the number of items to store

**Time Complexity**

| Row | Function name              | Array             | Linked List       |
|:---:|:-------------------------- |:-----------------:|:-----------------:|
| 1   | **(LookUp)** By Index      | <mark>O(1)</mark> | O(n)              |
| 2   | **(LookUp)** By Value      | O(n)              | O(n)              |
| 3   | **(Insert)** Beginning/End | O(n)              | <mark>O(1)</mark> |
| 4   | **(Insert)** Middle        | O(n)              | O(n)              |
| 5   | **(Delete)** Beginning     | O(n)              | <mark>O(1)</mark> |
| 6   | **(Delete)** Middle        | O(n)              | O(n)              |
| 7   | **(Delete)** End           | O(n)              | O(n)              |

### 

### Types of Linked Listed:

We have two types of LinkedIn listed Singly and Doubly and what is the difference between them? The items singly just have a link to the next item when you want to delete the item from the end you should loop in all items of Linked Listed but we can add a reverse link to each item stored next and previous item that case O(1) Big O like the image below.

![doubleLinkedList.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/doubleLinkedList.png)

## Stacks

Stacks are powerful data structures that help us to solve many complex programming problems.
A Stack is a linear data structure that follows the LIFO (Last-In-First-Out) principle. It contains only one pointer top pointer pointing to the topmost element of the stack. Whenever an element is added to the stack, it is added on the top of the stack, and the element can be deleted only from the stack.

- [x] **Stacks are LIFO (Last-In First-Out)**
  This term refers to the fact that new elements are added to the beginning of the stack, and the first element to be retrieved is the last added element.

#### Operations in Stacks:

- **push(item)** Add an item on top of the stacks

- **pop()** Remove an item from the top

- **peek()**  Return an item from the top without removing the item

- **isEmpty()** Determine stack is empty or not
  
  All operations of stacks run **O(1)** in a constant time.

#### Examples:

1- We can use stacks to reverse strings like below code:

```csharp
internal class StringReverser
{
    public string Reverse(string input)
    {
        string newString = "";
        Stack<Char> chars = new Stack<Char>();
        foreach (var item in input.ToArray())
            chars.Push(item);

        while (chars.Count > 0)
        {
            newString += chars.Pop().ToString();
        }
        return newString;
    }
}
```

2- Stack implementation from scratch

```csharp
internal class Stack
{
    private int[] items = new int[5];
    private int count;

    public void push(int item)
    {
        if (count == items.Length)
            throw new StackOverflowException();
        items[count++] = item;

    }
    public int pop()
    {
        if (count == 0)
            throw new Exception();
        return items[--count];
    }
    public int peek()
    {
        if (count == 0)
            throw new Exception();
        return items[--count];
    }
}
```

## Queues

A queue can be defined as an ordered list that enables insert operations to be performed at one end called Back(REAR) and delete operations to be performed at another end called FRONT as shown below:

![queue.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/queue.png)

- [x] **Queues are FIFO (First-In First-Out)**
  It means the first element to be retrieved from the queue is the first added element.

Queues are similar to real work queues, in which people join the line from the back and leave from the front.

#### Operations in Queues:

- **enqueue(**) Add an item to the back of the queue.

- **dequue()** Remove an item from the front of the queue.

- **peek(**) Get an item from the front without removing it.

- **isEmpty()**

- **isFull()**

All operations of Queues run **O(1)** in a constant time and we can say is so fast.

#### Examples:

###### 1: The below code shows how to create a queue with Array:

```csharp
internal class ArrayQueue
{
    int[] array;
    int frontIndex;
    int backIndex;
    int count;

    public ArrayQueue(int size)
    {
        array = new int[size];
    }
    public void enqueue(int item)
    {
        if (count >= array.Length)
            throw new Exception();
        array[frontIndex] = item;
        frontIndex = (frontIndex + 1) % array.Length;
        count++;
    }
    public int dequeue()
    {
        int current = array[backIndex];
        array[backIndex] = 0;
        backIndex = (backIndex + 1) % array.Length;
        count--;
        return current;
    }
    public int peek()
    {
        return array[backIndex];
    }
    public Boolean isEmpty()
    {
        return count == 0;
    }
    public Boolean isFull()
    {
        return count == array.Length;
    }
}
```

above code uses a circular array to solve a problem of fixed array size.

###### 2: Implement Queue with stack:

Implementing a queue with stack needs two stacks, stack1 for enqueue and stack2 for dequeue.

```csharp
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
```

**What is PriorityQueue?**

PriorityQueue is similar to Queue but it does not depend on the priority of adding an item it depends on the second item that is a priority:

```csharp
// First param of class is value and second of it is priority
PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>();
priorityQueue.Enqueue(2, 1);
priorityQueue.Enqueue(3, 3);
priorityQueue.Enqueue(4, 2);
```

## HashTables

Hash tables also called Dictionary, give us super fast lookup and we can use it for:

- Spell checkers

- Dictionaries

- Compilers

- Code editors

What do we call other programming languages' Hash Tables implementation:

| Java     | JavaScript | Phyton     | C#         |
|:--------:|:----------:|:----------:|:----------:|
| Hash Map | Object     | Dictionary | Dictionary |

#### Hash Function

A hash function is a function where you put in a string and you get back a number, so a hash function maps strings to numbers.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/hashFunction.png" alt="hashFunction.png" width="393">

#### Operations in HashTables:

- Insert()   

- Lookup()

- Delete()

Hash Table Store data with key and value pairs and All above operations run in **O(1)**.

Dictionary in C# code with time complexity:

```csharp
Dictionary<int, string> part1 = new Dictionary<int, string>();
part1.Add(0, "Mohsen");    //O(1)
part1.Add(1, "Jhon");
var containsValue = part1.ContainsValue("Mohsen");    //O(n)
var containsKey = part1.ContainsKey(10);    //O(1)

var dictionaryItem = part1.Single(x => x.Key == 0);    //O(1)
```

#### Examples:

###### 1- Find the first Non-repeated character:

```csharp
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
```

First, we count all chars and store them in the dictionary after that find from the dictionary item which is 1 and return it.

2- Create a Hash Table with Array and Linked List:

```csharp
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
```

for having constant O(1) time complexity we should use Array to store, in the above code why do we use Linked List?  imagine we have an Array with 5 fixed sizes and the key should be between 0 to 4, if the input key is 11 what happens?

In this scenario we should hash the key, if the key is an integer we get the remain of the key divided by array length, we use the % symbol (Modulo) and this issue with fixed, for example:

`var index = key % array.length`

`1 = 11% 5;`

`1 = 1% 5;`

#### Collisions

Another error might occur that the hash function generates two equal hash values, we can not store two items in the same index, this is what we call a **Collision**  like the below image.

If we use a good hash function the collisions will not happen a lot.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/collision.png" alt="collision.png" width="464">

We have two ways to fix this issue

**1- Chaining**: Store multiple items in a Linked List as shown in the above example.

As you can see we store A and C items in an index one but in a linked list.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/chaining.png" alt="chaining.png" width="482">

**2- Open Addressing**:  In this method, we do not insert duplicated data in the Linked List, we store them in an Array itself.

**Types of Open Addressing:**

- **Linear Probing:**
  We linearly probe/look for the next slot. If slot [hash(x)%size] is full, we try [hash(x)%size+1]. If that is full too, we try [hash(x)%size+2]…until an available space is found. Linear Probing has the best cache performance but the downside includes primary and secondary clustering.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/linearprobing.png" alt="linearprobing.png" width="455">

- **Quadratic Probing:**
  We look for the i²th iteration. If slot [hash(x)%size] is full, we try [(hash(x)+1*1)%size]. If that is also full, we try [(hash(x)+2*2)%size]…until an available space is found. Secondary clustering might arise here and there is no guarantee of finding a slot in this approach.

- **Double Hashing:**
  We use a second hash function hash2(x) and look for the i*hash2(x) slot. If slot [hash(x)%size] is full, we try [(hash(x)+1*hash2(x))%size]. If that is full too, we try [(hash(x)+2*hash2(x))%size]…until an available space is found. No primary or secondary clustering but lot more computation here.

#### Recap

You will almost never have to implement a hash table yourself. The programming language you use should provide an implementation for you.

# 2: Non-Linear DataStructure

Nonlinear elements of data structures aren't ordered in a particular way, as opposed to linear structures. They are arranged in a hierarchical manner in which each element may be linked to one element. The graph and tree-based structures divide those that are nonlinear.

In this part, you will learn:

1. **[Binary Trees](#Binary-Trees)**

2. **[AVL Trees](#AVL-Trees)**

3. **[Heaps](#Heaps)**

4. **[Tries](#Tries)**

5. **[Graphs](#Graphs)**

## Binary-Trees

The Tree is a data structure that stores elements in the hierarchy, referring to elements called nodes and connected lines called edges.

A Binary Tree, which is the most basic form of a tree structure, is a data structure where each node has at most two children. Those two children are referred to as the left and right children.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/tree.png" alt="tree.png" width="478">

**Usage**:

- Represent hierarchical data

- Databases

- AutoCompletion

- Compilers

- Compression(Mp3 ,..)

**Different Types of Binary Tree:**

![binarySearchTreeType.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/binarySearchTreeType.png)

1. **Full Binary Tree**
   
   We have a full binary tree when every node of the tree has two or zero children.

2. **Complete Binary Tree**
   
   A complete binary tree is formed when every level of the tree is completely filled, except possibly from the last one. Also, the last level has all nodes as left as possible.

3. **Perfect Binary Tree**
   
   We get a perfect binary tree when all tree nodes have two children, as well as all leaves, are uniform by having the same depth.

4. **Balanced Binary Tree**
   
   A balanced binary tree is formed when the tree’s height is O(Log n), with n being the number of nodes. We will explain this later on with AVL and Red-Black trees which are the most commonly used balanced binary search trees.

#### Binary Search Tree

This is a special type of binary tree called **Binary Search Tree (BST)** because it allows us to quickly look up data in this tree. Values of any right node are always greater than the left one and have **Logarithmic** time complexity.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/binarysearchtree.png" alt="binarysearchtree.png" width="393">

What about the time complexity of operations in BST?

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/binarysearchtreeOp.png" alt="binarysearchtreeOp.png" width="424">

As you can see in the above image, all operations in BST run logarithmic.

#### Example:

The implementation of the insert and find method in BST.

```csharp
internal class Tree
{
    internal class Node
    {
        public int value;
        public Node leftChild;
        public Node rightChild;
        public Node(int value)
        {
            this.value = value;
        }
    }
    private Node root;
    public Tree()
    {
    }

    public void insert(int item)
    {
        // if root is null add first item to the root item
        if (root == null)
            root = new Node(item);
        else
        {
            var current = root;
            while (current != null)
            {
                if (current.value < item)
                {
                    if (current.rightChild != null)
                        current = current.rightChild;
                    else
                    {
                        current.rightChild = new Node(item);
                        break;
                    }

                }
                else
                {
                    if (current.leftChild != null)
                        current = current.leftChild;
                    else
                    {
                        current.leftChild = new Node(item);
                        break;
                    }
                }
            }
        }
    }
    public bool find(int value)
    {
        var current = root;
        while (current != null)
        {
            if (current.value < value)
                current = current.rightChild;
            else if(current.value > null)
                current = current.leftChild;
            else
                return true;
        }
        return false;
    }
}
```

#### Traversing Trees:

There are some approaches to traverse the tree, It classified into two main categories

- **Breadth First Seach (BFS)**
  
  Also called **Level Order** traversing which you should visit all the nodes at the same level before visiting the nodes at the next level.
  
  <img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/levelordertraverse.png" alt="levelordertraverse.png" width="505">
  
  As you can see in the above image, first you visit 7 then 4,9,1,6,8 and 10.
  
  For implementing this search algorithm for Trees and Graphs we should use **Queue** Data Structure.

- **Depth First Search (DFS)**
  
  In this method, we have three different ways
  
  1. **Pre-order** (Root - Left - Right)
     
     ![postorder.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/preorder.png)

```csharp
 private void traversePreorder(Node root)
 {
     if (root == null)
         return;
     Console.WriteLine(root.value);
     traversePreorder(root.leftChild);
     traversePreorder(root.rightChild);
 }
```

2. **In-order** (Left - Root - Right)
   
   ![preorder.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/inorder.png)

```csharp
 public void traverseInorder(Node root)
 {
     if (root == null)
     {
         return;
     }
     traverseInorder(root.leftChild);
     Console.WriteLine(root.value);
     traverseInorder(root.rightChild);
 }
```

3. **Post-order** (Left - Right - Root)
   
   ![preorder.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/postorder.png)

```csharp
public void traversePostorder(Node root)
{
    if (root == null)
    {
        return;
    }
    traversePostorder(root.leftChild);
    traversePostorder(root.rightChild);
    Console.WriteLine(root.value);
}
```

For implementing this search algorithm for Trees and Graphs we should use **Stack** Data Structure.

#### Depth & Height:

A node’s height is the number of edges to its most distant leaf node. On the other hand, a node’s depth is the number of edges back up to the root. So, the root always has a depth of 0  while leaf nodes always have a height of 0.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/treeHeight.png" alt="treeHeight.png" width="463">

We have two ways to calculate height:

- Recursive way

- Iterative way

There is a recursive formula to calculate the height of the Tree, we should calculate the left and right of the tree and compare both of them:

`Height = 1 + max(height(L), height(R))`

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/heightTree.png" alt="heightTree.png" width="422"> 

```csharp
// O(n)
public int height(Node root)
{
    if (root == null) return -1;
    if (root.leftChild == null && root.rightChild == null)
        return 0;
    return 1 + Math.Max(height(root.leftChild), height(root.rightChild));
}
```

#### Example:

1- Find a minimum value in a Tree:

We can implement it in two ways, first, the easiest way is to traverse all nodes of the Tree with recursion that is time complexity of the method is **O**(n)**

```csharp
// O(n)
public int min(Node root)
{
    if ( root.leftChild == null && root.rightChild == null) 
        return root.value;
    var left = min(root.leftChild);
    var right = min(root.rightChild);

    return Math.Min(Math.Min(left, right), root.value);
}
```

As you know in the Binary Search Tree the minimum value is always in the left nodes and we should search in the left child, because of this the time complexity is **O(log(n))**

```csharp
//O(log(n)
public int min()
{
    if (root == null)
        throw new Exception();

    var current = root;
    var last = current;
    while (current != null)
    {
        last = current;
        current = current.leftChild;
    }
    return last.value;
}
```

Also if you want to find the greatest value in BST, we should do the opposite and traverse to the left of the tree.

2- Identify whether two trees are identical or not:

```csharp
public bool equals(Node first, Node second)
{
    //if two tree are null 
    if(first == null && second == null) return true;
    if(first != null && second != null)
    {
        return first.value == second.value
            && equals(first.leftChild, second.leftChild)
            && equals(first.rightChild, second.rightChild);
    }
    return false;
}
```

3- Validating Binary Search Tree:

As we know in the binary search tree, right nodes should be greater than left nodes traversing to leaf nodes. The first way to check each node is to traverse all nodes and it costs a lot.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/validatetree.png" alt="validatetree.png" width="430">

```csharp
public bool isBinarySearchTree()
{
    return isBinarySearchTree(root, int.MinValue, int.MaxValue);
}
public bool isBinarySearchTree(Node root, int min, int max)
{
    if (root == null) return true;
    if (root.value < min || root.value > max) return false;

    return isBinarySearchTree(root.leftChild, min, root.value - 1)
        && isBinarySearchTree(root.leftChild, root.value + 1, max);
}
```

## AVL-Trees

As mentioned before every operation in BTS is run on O(log(n)) which this condition happens when the tree is balanced.
AVL trees are a special type of BST that automatically re-balance themselves every time we add or remove nodes.

In the balanced tree, the height of every node should be:

`height(left) - height(right) <= 1`

We have a factor to check the balance of the tree called the **balanced factor** which is the difference in the heights of the left and right subtrees.

`BF = height(left) - height(right)`

` -1 <= BF <= +1`

The Balance factor of an AVL Tree should be 0,+1,-1, if is greater or lower than these numbers, the tree should re-balanced itself.

#### Self-Balancing Tree

- AVL Tree (Adelson-Velsky and Landis)

- Red-black Trees

- B-trees

- Splay Trees

- 2-3 Trees

### Rotations

A tree rotation is necessary when we have inserted or deleted a node which leaves the tree in an unbalanced state.
We have four types of rotation:

- Left (LL)

- Right (RR)

- Left-Right (LR)

- Right-Left (RL)

### Left Rotation(LL)

A single rotation is applied when a node is inserted in the right subtree of a right subtree. In the given example, **node 1** has a balance factor of 2 after the insertion of **node 3**. By rotating the tree left, **node 2** becomes the root resulting in a balanced tree.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/leftRotation.png" alt="leftRotation.png" width="254">

After the Left Rotation and tree has balanced

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/leftRotation-perform.png" alt="leftRotation-perform.png" width="210">

### Right Rotation(RR)

A single rotation is applied when a node is inserted in the left subtree of a left subtree. In the given example, **node 3** now has a balance factor of 2 after the insertion of **node A**. By rotating the tree right, **node 2** becomes the root resulting in a balanced tree.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/rightRotation.png" alt="rightRotation.png" width="203">

After Left Rotation and tree-balanced

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/leftRotation-perform.png" alt="leftRotation-perform.png" width="181">

### Left-Right Rotation(LR)

In the given example, **node 7** is causing an imbalance resulting in **node 10** having a balance factor of 2. As **node 7** is inserted in the right subtree of **node 5**, a *left rotation* needs to be applied. However, a single rotation will not give us the required results. Now, all we have to do is apply the *right rotation* as shown before to achieve a balanced tree.<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/left-rightRotation.png" alt="left-rightRotation.png" width="193">

We should first rotate like the below image

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/left-rightRotationPerform1.png" alt="left-rightRotationPerform1.png" width="196">

Then we rotate it to the right same as in the below image and now the tree is balanced

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/left-rightRotationPerform2.png" alt="left-rightRotationPerform2.png" width="195">

### Right-Left Rotation(RL)

In the given example, **node 7** is causing an imbalance resulting in **node 5** having a balance factor of 2. As **node 7** is inserted in the left subtree of **node 10**, a *right rotation* needs to be applied. However, just as before, a single rotation will not give us the required results. Now, by applying the *left rotation* as shown before, we can achieve a balanced tree.<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/rightleftRotation.png" alt="rightleftRotation.png" width="169">

First, we should rotate like the below image 

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/rightleftRotationPerform1.png" alt="rightleftRotationPerform1.png" width="172">

Final rotation

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/rightleftRotationPerform2.png" alt="rightleftRotationPerform2.png" width="179">

## Heaps

A Heap is a special Tree-based data structure in which the tree is a complete binary tree.
Heaps have two characteristics:

1. The Tree should be complete (Nodes should fill from left to right).

2. The value of every node is greater than or to its children.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/heap.png" alt="heap.png" width="383">

### The Heap property

The heap property says that if the value of the parent is either greater than or equal to (in a max heap ) or less than or equal to (in a min heap) the value of the Child.

**MaxHeap:** sorted nodes Accenting and root is the largest in the heap and all the values below this are less than this value.

**MinHeap:** sorted nodes Descending and root is the smallest in the heap and all the values below this are greater than this value.

### Heap Applications:

- Sorting (HeapSort)

- Graph Algorithms (shortest path)

- Priority queues

- Find the Kth smallest/largest value

In Heaps, we can only delete the root node, and to fill it we should fill the root node with the last leaf of the tree and bubble down if the Heap tree is **MaxHeap** and the time complexity of removing from this tree is **O(log n)**.

Another operation in the Heap tree is to find the maximum value that is super easy, the root node value is the greatest in a tree and runs on constant time **O(1)**.

### Operations on Heaps

- **Heapify →** Process to rearrange the heap in order to maintain heap-property.
- **Find-max (or Find-min) →** find a maximum item of a max-heap, or a minimum item of a min-heap, respectively.
- **Insertion →** Add a new item in the heap.
- **Deletion →** Delete an item from the heap.
- **Extract Min-Max →** Returning and deleting the maximum or minimum element in max-heap and min-heap respectively.

## Tries

The Tries (Prefix Tree) is another type of tree but is not a BST one, each child can have several nodes.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/triesTree.png" alt="triesTree.png" width="431">

We use tries for auto-complete, for example, google search.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/triesComplexity.png" alt="triesComplexity.png" width="443">

We are not duplicating this character as you can see above, we can have up to 26 subtrees for each node in the English language and the root should be empty.

The time complexity of the operation of this tree depends on the length of the word.

- **Lookup  O(L)**

- **Insert     O(L)**

- **Delete   O(L)**

We can implement tries with Array and Hashmap too.

Array Implemetation:

```csharp
internal class TriesTree
{
    public Node root = new Node(' ');
    public class Node
    {
        public static int ALPHABET_SIZE = 26;
        public char Value { get; set; }
        public Node[] Children = new Node[ALPHABET_SIZE];
        public bool isEndOfWord;

        public Node(char value)
        {
            Value = value;
        }
    }
    public void insert(string word)
    {
        var current = root;
        foreach (var item in word.ToCharArray())
        {
            var index = item - 'a';
            if (current.Children[index] == null)
                current.Children[index] = new Node(item);
            current = current.Children[index];
        }
        current.isEndOfWord = true;
    }
}
```

## Graphs

A Graph in Data Structure is a collection of nodes that consist of data and are connected to other nodes of the graph like the below image.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/graph.png" alt="graph.png" width="263">

#### Nodes

They are also called **Vertices**. A node can represent anything such as any location, port, houses, buildings, landmarks, etc.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/graphnode.png" alt="graphnode.png" width="378">

##### Degree of a Node

The Degree of a node is the number of edges connecting the node in the graph. A simple example would be, suppose in Facebook, if you have 100 friends then the node that represents you has a degree of 100.

#### Edges

It represents the relationships between various nodes in a graph. Edges are also called the **Path** in a graph.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/graphEdge.png" alt="graphEdge.png" width="292">

The above image represents edges in a graph.

A graph data structure (V, E) consists of:

1. A collection of vertices (V) or nodes.
2. A collection of edges (E) or path.

#### Cycle Graphs

In graph theory, a graph that consists of a single cycle is called a cycle graph or **circular graph**.

- A Cycle Graph or Circular Graph is a graph that consists of a single cycle.

- In a Cycle Graph number of vertices is equal to a number of edges.

- In a Cycle Graph, the Degree of each vertex in a graph is two.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/cycleGraph.png" alt="cycleGraph.png" width="316">

#### Connected Graphs

A Graph is said to be **connected** if every pair of vertices in the graph is connected. This means that there is a path between every pair of vertices.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/connectedGraph.png" alt="connectedGraph.png" width="253">

#### Weighted Graphs

In weighted graphs, each edge has a value associated with them (called weight). It refers to a **simple graph** that has weighted edges. The weights are usually used to compute the shortest path in the graph.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/weightedGraph.png" alt="weightedGraph.png" width="335">

#### Directed Graphs

The graphs where the edges have **directions** from one node towards the other node. In Directed Graphs, we can only traverse from one node to another if the edge have a direction pointing to that node.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/directedGraph.png" alt="directedGraph.png" width="277">

Directed graphs are used in many areas. One of the usecase you may think of is a family tree, where there can be only the edge directed from parent to children. So, family tree are directed graphs.

#### Undirected Graphs

Undirected graphs have edges that do not have a direction. Hence, the graph can be traversed in either direction.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/undirectedGraph.png" alt="undirectedGraph.png" width="304">

The above graph is undirected. Here, the edges do not point to any direction. We can travel through both directions, so it is bidirectional. In these graphs, we can reach to one node, from any other node.



### Breadth-first Search

Breadth First Traversal or Breadth First Search is a recursive algorithm for searching all the vertices of a graph or tree data structure.

A standard BFS implementation puts each vertex of the graph into one of two categories:

1. **Visited**
2. **Not Visited**

The purpose of the algorithm is to mark each vertex as visited while avoiding cycles.

The algorithm works as follows:

1. Start by putting any one of the graph's vertices at the back of a queue.
2. Take the front item of the queue and add it to the visited list.
3. Create a list of that vertex's adjacent nodes. Add the ones that aren't in the visited list to the back of the queue.
4. Keep repeating steps 2 and 3 until the queue is empty.

#### Time Complexity:

The time complexity of the BFS algorithm is represented in the form of **`O(V + E)`**, where V is the number of nodes and E is the number of edges.

The space complexity of the algorithm is **`O(V)`**.



### Dijkstra's Algorithm

Given a weighted graph and a source vertex in the graph, find the ****shortest paths**** from the source to all the other vertices in the given graph.

****Note:**** The given graph does not contain any negative edge.

##### Example:

It is easier to start with an example and then think about the algorithm.

1. Start with a weighted graph

2. Choose a starting vertex and assign infinity path values to all other devices

3. Go to each vertex and update its path length

4. If the path length of the adjacent vertex is lesser than new path length, don't update it

5. Avoid updating path lengths of already visited vertices

6. After each iteration, we pick the unvisited vertex with the least path length. So we choose 5 before 7

7. Notice how the rightmost vertex has its path length updated twice

8. Repeat until all the vertices have been visited



### Graph Implementation

#### Adjacency Matrix

The first approach to impelement graph (**Adjacency Matrix)** is to use a two-dimensional Array and implement using a Hash Table like the below image:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/twodgraph.png" alt="twodgraph.png" width="371">

If two nodes are connected, the value should be 1 otherwise 0.

The problem with this approach is the amount of space needed and space complexity is **O(n^2)** and grows fast.

##### Operations Time Complexity:

- Add Edge = **O(1)**

- Remove Edge = **O(1)**

- Query Edge = **O(1)**

- Find Neighboars = **O(V)**

- Add Node = **O(V^2)**

- Remove Node = **O(V^2)**

If you know how many nodes you need and you are not going to add an item this type is great to use because the time complexity of edges is **O(1)**

### Adjacency List

The second approach is  **(Adjacency List)** and is implemented with an Array of Linked Lists every element of an Array has a Linked List and contains nodes that are more space efficient with the first one and  space complexity is **O(V + E)**

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/adjacencyList.png" alt="adjacencyList.png" width="412">

The worst-case scenario is when every node is connected to every other node we say we have a **Dense Graph**

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/densegraph.png" alt="densegraph.png" width="364">

##### TimeCompexity:

K = Number of edges of each Node.

**Average scenario:**

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/graphtimecomplexity.png" alt="graphtimecomplexity.png" width="405">

**Worst case scenario:**

![graphtimecomplexityWorse.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/graphtimecomplexityWorse.png)

As you can see in the above images if you have a dense graph both approaches take the same amount of space and the time complexity of the Matrix is better, so if we dealing with a dense graph is better to implement with Matrix but in reality, **Adjancency List** is better than Matrix One.

# 3: Algorithms

In this part of the document you will learn:

1. **[Recursion](#Recursion)**

2. **[DivideAndConquer](#DivideAndConquer)**

3. **[Sorting](#Sorting)**

4. **[Searching](#Searching)**

5. **[String Manipulation](#StringManipulation)**

## Recursion

Recursion is when a function calls itself.

### Call Stack

In computer science, a call stack is a stack data structure that stores information about the active subroutines of a computer program, and in software development, the **call stack** is what a program uses to keep track of method calls.

While you're calling a method that has another method in it, What will happen?

The computer stores **Pushes** the main method first to the Stack and then **Pushes** the inner method to the Stack and starts to calculate from the Stack by popping the method and calling it.

As we know each function call has an input and return value, where do these values store? These values are stored in the **Stack Frame**. 

What does Stack Frame have?

- Local variables
- Arguments passed into the method
- Information about the caller's stack frame
- The *return address*—what the program should do after the function returns (i.e.: where it should "return to"). This is usually somewhere in the middle of the caller's code.

### Recursive Functions

A Recursive function can be defined as a routine that calls itself directly or indirectly.

In recursive functions on each recursion, we will have one Stack Frame that takes memory until finishing the function and recursive calls end up with huge call stacks.

The Recursive function has two parts:

**Base Case:** The base case is when the function doesn't call itself again, so it doesn't go into an infinite loop.

**Recursive Case:** The recursive case is when the function calls itself.

```csharp
public void CountDown(int i)
{
    Console.WriteLine(i);

    // Base Case
    if(i<=0)
    {
        return;
    }
    //Recursive Case
    else
    {
        Countdown(i-1);
    }
 }
```

There's no performance benefit to using recursion; in fact, loops are sometimes better for performance. ***Loops may achieve a performance gain for your program, but Recursion may achieve a performance gain for your programmer.***

While calling a recursive function, each call is stored in **Call Stack** until the Base Case condition executes, then it will start by popping calls from the last to the first.

## DivideAndConquer

The divide-and-conquer technique involves taking a large-scale problem and dividing it into similar sub-problems of a smaller scale and recursively solving each of these sub-problems. Generally, a problem is divided into sub-problems repeatedly until the resulting sub-problems are very easy to solve.

A **divide and conquer algorithm** is a strategy of solving a large problem by

1. breaking the problem into smaller sub-problems
2. solving the sub-problems, and
3. combining them to get the desired output.

Here are the steps involved:

1. **Divide**: Divide the given problem into sub-problems using recursion.
2. **Conquer**: Solve the smaller sub-problems recursively. If the subproblem is small enough, then solve it directly.
3. **Combine:** Combine the solutions of the sub-problems that are part of the recursive process to solve the actual problem.

### Divide and Conquer Applications

- [BinarySearch](#BinarySearch)
- [MergeSort](#MergeSort)
- [QuickSort](#QuickSort)

## Sorting

In the Sorting algorithm, we learn:

- How do they work?

- Time & space complexity

- Implementation

### BubbleSort

This one is the simplest type of sort algorithm:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/bubbleSort.png" alt="bubbleSort.png" width="389"> 

We should scan Array items from left to right, if items are out of order swap them.

In the below image, we should iterate an Array 5 times that is equal to the length of the Array and for each iteration, we should compare <u>0 & 1</u> , <u>1 & 2</u> , <u>2 & 3</u> , <u>3 & 4 </u>

#### Time Complexity:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/bsTimeComplexity.png" alt="bsTimeComplexity.png" width="341">

As you can see if the Array is fully unsorted the worst scenario will happen and as the below image shows this sorting algorithm is Inefficient because of a red area.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/complexity%20chart.png" alt="complexity chart.png" width="465">

We have two optimizations in the below code, first, we add a Sorted bool field that when just one item is unsorted, we don't need to iterate all array members.

Another optimization after each loop in Array, we sort one member, however, there is no need to iterate again to all members and we can decrease the second loop each time.

```csharp
public class BubbleSort
{
    public void sort(int[] array)
    {
        bool isSorted = false;
        for (int i = 0; i < array.Length; i++)
        {
            isSorted = true;
            for (int j = 1; j < array.Length - 1; j++)
            {
                if (array[j] < array[j - 1])
                {
                    swap(array, j, j - 1);
                    isSorted = false;
                }
            }
        }

        if (isSorted)
            return;
    }
    private void swap(int[] array, int index1, int index2)
    {
        var temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
```

### SelectionSort

In this sort we need to find a minimum item in Array that is 1 in index 3 we need to swap the item to item zero, Now 1 is in the correct position.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/selectionSort.png" alt="selectionSort.png" width="307">

Then our array has two parts, sorted and unsorted like below.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/selectionsortpart.png" alt="selectionsortpart.png" width="296">

Now we should repeat this action in the unsorted part until all array items are sorted.

As we understand for sorting one item in the list we should apply **Simple Search** to find the **lowest** or **highest** value and we should apply this search for each item to sort then we will have **O(n*n) = O(n^2)**.

#### Time Complexity:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/ssTimeComlexity.png" alt="ssTimeComlexity.png" width="310">

This is a fairly slow algorithm

Selection sort implementation

```csharp
public class SelectionSort
{
    public void sort(int[] array)
    {
        for (int j = 0; j < array.Length; j++)
        {
            int minindex = j;
            for (int index = minindex; index < array.Length; index++)
                if (array[minindex] > array[index])
                    minindex = index;
            swap(array, minindex, j);   
        }
    }
    private void swap(int[] array, int index1, int index2)
    {
        var temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
```

### InsertionSort

The best way to understand insertion sort is by playing a card game, imagine each Array represents a card, every time you get a card insert it in the right position, first you get 8 then you get 2 insert it before then you get 4, you should insert it between 2 and 8 and 1 insert before all item and finally get 3 insert it after 2.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/insertionSort.png" alt="insertionSort.png" width="338">

#### Time Complexity:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/iscomplexityTime.png" alt="iscomplexityTime.png" width="300">

Insersion sort implementation

```csharp
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
```

### MergeSort

The idea of merge sort is to break down a list into smaller and smaller sub-lists then sort them and merge them back to each other to a completely sorted list. we should divide an array until we can not divide anymore and should compare each array that has a single item to sort them and again merge them.

We can say Merge Sort is **Divide and Conquer** algorithm, it works by recursively dividing a problem into smaller sub-problems until is easy to solve. If our array is like below:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/mergeSort.png" alt="mergeSort.png" width="356">

We should find an index of the middle by dividing the length of the array.

`middle = length/2 => 5/2 = 2`

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/first%20mergesort.png" alt="first mergesort.png" width="359">

First, we focus on the left sub-array to find the middle and split it.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/secondmergesort.png" alt="secondmergesort.png" width="356">

Now we have a single item array and we should merge and combine two left Array.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/thirdmergesort.png" alt="thirdmergesort.png" width="354">

Now we should repeat to the right array and split and merge it until the array is fully sorted.

Real Example with numbers:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/mergeSortSample.png" alt="mergeSortSample.png" width="478">

#### Time Complexity:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/mergesorttimeComplexity.png" alt="mergesorttimeComplexity.png" width="268">

This algorithm is more efficient than the previous algorithm but it costs allocating more space.

Merge Sort Implementation:

```csharp
public class MergeSort
{
    public void sort(int[] array)
    {
        if (array.Length < 2)
            return;

        //divide array into half
        var middle = array.Length / 2;
        int[] left = new int[middle];
        for (int i = 0; i < middle; i++)
            left[i] = array[i];

        int[] right = new int[array.Length - middle];
        for (int i = middle; i < array.Length; i++)
            right[i - middle] = array[i];

        //sort each half 
        sort(left);
        sort(right);
        //Merge the result

        merge(left, right, array);
    }
    private void merge(int[] left, int[] right, int[] result)
    {
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
                result[k++] = left[i++];
            else
                result[k++] = right[j++];
        }
        while (i < right.Length)
            result[k++] = right[j++];

        while (j < left.Length)
            result[k++] = left[i++];

    }
}
```

### QuickSort

Like Merge Sort, quicksort uses divide-and-conquer and so it's a recursive algorithm. The way that Quicksort uses divide-and-conquer is a little different from how merge sort does.

Quicksort has a couple of other differences from merge sort. Quicksort works in place. And its worst-case running time is as bad as selection sort's and insertion sort's. But its average-case running time is as good as merge sort.

So why think about quicksort when merge sort is at least as good? That's because the **constant factor** hidden in the big-Θ notation for quicksort is quite good.

**Here are the divide, conquer, and combine steps that Quicksort uses:**

1. Pick a pivot element

2. Partition, or rearrange, the array into two subarrays, such that all elements are less than and such that all elements are greater than or equal to.

3. Sort the subarrays and recursively with quicksort.

Picking a good pivot is the key for a fast implementation of quicksort; The best-case pivot would divide the array into two equal parts.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/quickSortSample.png" alt="quickSortSample.png" width="465">

#### Advantages of quicksort

- The average-case time complexity to sort an array of n elements is O(n lg n).
- Generally, it runs very fast. It is even faster than merge sort.
- No extra storage is required

#### Disadvantages of quicksort

- Its running time can be different for different array contents.
- The worst-case quick sort takes place when the array is already sorted. 
- It is not stable.

#### Time Complexity

| Case         | Time Complexity |
| ------------ | --------------- |
| Best Case    | O(n log n)      |
| Average Case | O(n log n)      |
| Worst Case   | O(n^2)          |

## Searching

### BinarySearch

Binary Search is a searching algorithm for finding an element's position in a sorted Array. Binary search can be implemented only on a sorted list of items. If the elements are not sorted already, we need to sort them first.

1. This is an Array we want to search **X=4**.
   
   <img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/binarySearchArray.png" alt="binarySearchArray.png" width="317">

2. Set two pointers low and high at the lowest and the highest positions respectively.
   
   <img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/binarySearchPointer.png" alt="binarySearchPointer.png" width="318">

3. Find the index of the middle element of the array ie. `arr[(low + high)/2] = 3`
   
   <img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/binarySearchMiddle.png" alt="binarySearchMiddle.png" width="311">

4. If x == mid, then return mid. Else, compare the element to be searched with m.

5. If `x > mid`, compare x with the middle element of the elements on the right side of mid. This is done by setting low to `low = mid + 1`.

6. Otherwise, compare x with the middle element of the elements on the left side of mid. This is done by setting high to `high = mid - 1`.
   
   <img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/binarySearch4Middle.png" alt="binarySearch2Middle.png" width="299">

7. Repeat steps 3 to 6 until low meets high and finally find X.
   
   <img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/binarySearch5Middle.png" alt="binarySearch5Middle.png" width="149">

#### Recap

- Binary search is a lot faster than simple search.

- O(log n) is faster than O(n), but it gets a lot faster once the list of items you're searching through grows.

- Algorithm times are measured in terms of the growth of an algorithm.

#### Time Complexity

| Case         | Time Complexity | Space Complexity |
|:------------ |:---------------:|:----------------:|
| Best Case    | O(1)            | O(1)             |
| Average Case | O(logn)         | O(1)             |
| Worst Case   | O(logn)         | O(1)             |
