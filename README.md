# 1: Linear Data Structure

In the first part of this document you will learn:

1. **[Big O Notation](#Big-O-Notation)**

2. **[Arrays](#Arrays)**

3. **[Linked Lists](#LinkedLists)**

4. **[Stacks](#Stacks)**

5. **[Queues](#Queues)**

6. **[Hash Tables](#HashTables)**

## Big-O-Notation

We use Big O Notation to describe the performance of the algorithm, time complexity and space complexity to express it and how scalable the algorithm is.

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

`var inedex = key % array.length`

`1 = 11% 5;`

`1 = 1% 5;`

Another error might occur that the hash function generates two equal hash values, we can not store two items in the same index, this is what we call a **Collision**  like the below image

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/collision.png" alt="collision.png" width="464">

We have three ways to fix this issue

**1-Chaining** : Store multiple items in a Linked List as shown in the above example.

As you can see we store A and C items in an index one but in a linked list.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/chaining.png" alt="chaining.png" width="482">

**2- Open Addressing**:  In this method, we do not insert duplicated data in the Linked List, we store them in an Array itself.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/linearprobing.png" alt="linearprobing.png" width="455">

In this method, we increment 1 each time that the item is full to find an empty item. As the image shows if these clusters happen we should search for free items past 3 previous items and have cost, another method is to use.

 **Quadratic Probing**

![linearprobing.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/quadraticprobing.png)

# 2: Non-Linear DataStructure
In this part, you will learn:

1. **[Binary Trees](#BinaryTrees)**

2. **[AVL Trees](#AVLTrees)**

3. **[Heaps](#Heaps)**

4. **[Tries](#Tries)**

5. **[Graphs](#Graphs)**

## Binary Trees

The Tree is a data structure that stores elements in the hierarchy, referring to elements called nodes and connected lines called edges.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/tree.png" alt="tree.png" width="478">

**Usage**:

- Represent hierarchical data

- Databases

- Autocompletion

- Compilers

- Compression(Mp3 ,..)

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

- **Breadth First**
  
  Also called **Level Order** traversing which you should visit all the nodes at the same level before visiting the nodes at the next level.
  
  <img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/levelordertraverse.png" alt="levelordertraverse.png" width="505">
  
  As you can see in the above image, first you visit 7 then 4,9,1,6,8 and 10.

- **Depth First**
  
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

#### Depth & Height:

The Depth property of a Tree is the number of edges from the root to the target node and the height property is the opposite of depth, the height of the leaf in a tree is equal to zero.

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

We can implement it in two ways, first, the easiest way is to traverse all nodes of Tree in with recursion that is time complexity of method is **O(n)**

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

As you know in the Binary Search Tree the minimum value is always in the left nodes and we should search in left child, because of this the time complexity is **O(log(n))**

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

## AVLTrees

As i mentioned before every operation in BTS is run on O(log(n)) time complexity that this condition happends when the tree is balanced.

In the balanced tree height of every node should be:

`height(left) - height(right) <= 1`

AVL tree are special type of BST that automatically re-balance themselves every time we add or remove nodes.

#### Self-Balancing Tree

- AVL Tree (Adelson-Velsky and Landis)

- Red-black Trees

- B-trees

- Splay Trees

- 2-3 Trees

### Rotations

We have four types of rotation:

- Left (LL)

- Right (RR)

- Left-Right (LR)

- Right-Left (RL)

We have factor to check the balance of tree called balanced factor:

`BF = height(left) - height(right)`

` -1 <= BF <= 1`

BF should be 0,1,-1 if is greater or lower than these number, the tree should re balanced itself.

### Left Rotation(LL)

We can calculate  BF of each child and node with value of 1 is not balance and the heavy is on the right we have to perform left rotation

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/leftRotation.png" alt="leftRotation.png" width="254">

After Left Rotation and tree balanced

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/leftRotation-perform.png" alt="leftRotation-perform.png" width="210">

### Right Rotation(RR)

As you can see in below image the heavy of left is more than right and the tree is unbalanced and need to rotate to right.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/rightRotation.png" alt="rightRotation.png" width="203">

After Left Rotation and tree balanced

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/leftRotation-perform.png" alt="leftRotation-perform.png" width="181">

### Left-Right Rotation(LR)

In the below image we have double rotation with left and right 

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/left-rightRotation.png" alt="left-rightRotation.png" width="193">

We should first rotate like below image

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/left-rightRotationPerform1.png" alt="left-rightRotationPerform1.png" width="196">

Then we have rotate to right  same as below image and now the tree is balanced

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/left-rightRotationPerform2.png" alt="left-rightRotationPerform2.png" width="195">

### Right-Left Rotation(RL)

This is opposite of LR Rotation and we should perform right left rotation

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/rightleftRotation.png" alt="rightleftRotation.png" width="169">

First we should rotate like below image 

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/rightleftRotationPerform1.png" alt="rightleftRotationPerform1.png" width="172">

Final rotation

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/rightleftRotationPerform2.png" alt="rightleftRotationPerform2.png" width="179">

## Heaps

Heap is special type of tree with two properties.

1. Tree is should be compelte (Nodes should fill from left to right)

2. The value of every node is greater than or to its children

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/heap.png" alt="heap.png" width="383">

We have two types of heap: **MaxHeap** that sorted Accenting and **MinHeap** sorted Deccenting 

###### Heap Applications:

- Sorting (HeapSort)

- Graph Algorithms (shortest path)

- Priority queues

- Find the Kth smallest/largest value

In heaps only we can delete the root node, and to fill it we should fill the root node with last leaf of tree and bubbling down if heap tree is **MaxHeap** and the time complexity of removing from this tree is **O(log n)**

Another operration in heap tree is find the maximun value that is super easy, root node value is the greatest value in tree and run on constant time **O(1)**

#### Bulding Heaps

We usually implemeting heap using array and we dont need class with node , leftChild and rightChild.

When we want to insert item in array we should determind the indexes of each node, that we can use the formola below ro each node.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/heaparray.png" alt="heaparray.png" width="466">

The formola of calculate parent index is: `ParentIndex = (Index -1) / 2`

## Tries

 Tries is another types of tree but is not BST one, each child can have several nodes.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/triesTree.png" alt="triesTree.png" width="431">

We use tries for auto complete, for example google search.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/triesComplexity.png" alt="triesComplexity.png" width="443">

We are not duplicationg in this charecter as you can see above, we can have up to 26 subtree for each node in english language and the root should be empty.

The time complexity of operation of this tree is depend on lentgh of word 

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

We use graphs for connected objects, exp: people on a social media platform and we can say tree is kind of graph without cycle and root node.

Instead of Node in trees we call **Vertex** in graphs

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/graph.png" alt="graph.png" width="281">

If two node connected directly to each other we called **adjacent** or neighbor 

If edges have direction we say is a **Directed Graph** like twitter, if you follow someone is  connection from your account to their account and is one way direction and undirected graphs are facebook and linkedin.

Each edges can have weight like below that we use it to represent how strong connection is.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/weightGraph.png" alt="weightGraph.png" width="296">

### Adjacency Matrix

First approach **(Adjacency Matrix)** is to use two dimentional array and implement using hash table like below

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/twodgraph.png" alt="twodgraph.png" width="371">

If two node is connected the value it should be 1 othervise 0.

The problem of this approach is amount of space need and space complexity is **O(n^2)** and grow fast.

##### Operations Time Complexity:

- Add Edge = **O(1)**

- Remove Edge = **O(1)**

- Query Edge = **O(1)**

- Find Neighboars = **O(V)**

- Add Node = **O(V^2)**

- Remove Node = **O(V^2)**

If you know how many nodes you need and you are not going to add item this type is greate to use because time complexity of edges is **O(1)**

### Adjacency List

Second Approach **(Adjacency List)** and implement with array of linked list and every element of array has a linked list and contains nodes that is more space efficeint with the first one and  space complexity is **O(V + E)**

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/adjacencyList.png" alt="adjacencyList.png" width="412">

The worst case scenario is when every node is connected to every other node we say we have **Dense Graph**

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/densegraph.png" alt="densegraph.png" width="364">

##### TimeCompexity:

K = Number of edges of each Nodes.

**Average scenario:**

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/graphtimecomplexity.png" alt="graphtimecomplexity.png" width="405">

**Worst case scenario:**

![graphtimecomplexityWorse.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/graphtimecomplexityWorse.png)

As you can see in an above images if you have dense graph both approche take the same amount of  apace and time comlexity of Matrix is better, so if we dealing with dense graph is better to impplementing with Matrix but in reality **Adjancency List** is better than Matrix One.

# 3: Algorithms

In the first part of this document you would Learn:

1. **[Sorting](#Sorting)**

2. **[Searching](#Searching)**

3. **[String Manipulation](#StringManipulation)**

## Sorting

In sorting algorithm we learn:

- How they work

- Time & space complexity

- Implementation

### Bubble Sort

This is the simplest type of sort algorithm

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/bubbleSort.png" alt="bubbleSort.png" width="389"> 

We should scan array item from left to right, if item is out of order swap them.

In the below image we should iterate array 5 time that eqaul to length of array and each iteration we should compare <u>0 & 1</u> , <u>1 & 2</u> , <u>2 & 3</u> , <u>3 & 4 </u>

#### Time Complexity:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/bsTimeComplexity.png" alt="bsTimeComplexity.png" width="341">

As you can see if array is fully unsorted the worst scenario will happend and as below image shown this sorting algorithm is Inefficient because in a red area.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/complexity%20chart.png" alt="complexity chart.png" width="465">

We have two optimization in below code, first we add isSorted bool field that when just one item is unsorted , we dont need to iterate all array member.

Another optimization after each loop in array, we sort one member, however there is no need to iterate again to all member and we can decrease second loop each time.

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

### Selection Sort

In this sort we need to find a minimum item in array that is 1 in index 3 we need to swap item to item zero , Now 1 is in the correct position.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/selectionSort.png" alt="selectionSort.png" width="307">

Then our array has two parts, sorted and unsorted like below.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/selectionsortpart.png" alt="selectionsortpart.png" width="296">

Now we should repeat this action in unsorted part until all array item sorted.

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

### Insertion Sort

The best way to to undrestand insertion sort is playing a card game, imagin each array represent a card, every time you get a card insert it in a right position, first you get 8 then you get 2 insert it before then you get 4, you should insert it between 2 and 8 and 1 insert before all item and finally get 3 insert it after 2.

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

### Merge Sort

The idea of merge soft is to break down a list into smaller and smaller sub list sort those and merge back to each other to compeletly sorted list. we should divided an array until we can not devided any more and should compare each array that have single item to sort them and again merge it.

We call merge sort  as **Divide and Conquer** algorithm, it works by recursively dividing a problem into smaller sub problem until is easy to be solve.



<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/mergeSort.png" alt="mergeSort.png" width="356">

We should find a index of the middle by dividing length of array.

`middle = length/2 => 5/2 = 2`

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/first%20mergesort.png" alt="first mergesort.png" width="359">

First we focus on left sub-array and find the middle and split it.

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/secondmergesort.png" alt="secondmergesort.png" width="356">

Now we have single item array and we should merge and combine two left array

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/thirdmergesort.png" alt="thirdmergesort.png" width="354">

Now we should repeat to right array and split and merge it.

#### Time Complexity:

<img title="" src="https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/mergesorttimeComplexity.png" alt="mergesorttimeComplexity.png" width="268">

This algorithm is more efficent than previose algorithm but it cost alocating more space.

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
