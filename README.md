# 1:

In the first part of this document you would Learn:

1. **[Big O Notation](#Big-O-Notation)**

2. **[Arrays](#Arrays)**

3. **[Linked Lists](#LinkedLists)**

4. **[Stacks](#Stacks)**

5. **[Queues](#Queues)**

6. **Hash Tables**

## Big-O-Notation

We use Big O Notation to describe performance of algorithm, runtime complexity and  how scalabe algorithm is.

The below codes show **O(1)** becuase the code run in a constant time.

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

As it shown in above image, constant type algorithms grows linearly as the same rate but the logarithmic curve down on some point, logarithmic is more efficent and scalabe compare to linear or other and exponential is the opossit of logarithmic and is not efficent to use and has a lot cost.

## Arrays

Arrays are simple data structure item use to store data squesntially, if you want to store data by index arrays are the best choice.

Featurse of Array Data Structure:

- Simple Data Structure
- Greate Data Structure when you khow how many item have
- The Items are fixed
- The length of array is fixed
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

## LinkedLists

Linked List Store Objects in squence and unlike Arrays can grows or shrink automatically like blow image.

![linkedlist.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/linkedlist.png)

In linked list we have first and last item of a list and recersively add another items to them and the linked list implementation from scratch:

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

As you can see above code we have Node class that store the value of item and the next item that create connection to the next item.

### Arrays vs Linked Lists:

We want to compare in terms of requierd memory and time complexcity.

- Static arrays have a fixed size 

- Dynamic arrays grows by 50-100%

- Linked Lists dont wast memory

- Use arrays if you khnow the number of items to store

**Runtime Complexcity**

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

### Types of Lisnked Listed:

We have two types of linked Listed Singly and Doubly and what is diffrence between them. The items singly just have link to next item that wehn you want to delete item from end you should loop in all items of Linked Listed but we can add reverse link than each item store next and previose item that case O(1) Big O like image below.

![doubleLinkedList.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/doubleLinkedList.png)

## Stacks

Stacks are powerfull data structure that help us to solve many complex programming problems.

#### Operations in stacks:

- **push(item)** Add item on top of the stacks

- **pop()** Remove Item on the top

- **peek()**  Return Item in the top without removing the item

- **isEmpty()** Determind stack is empty or not
  
  All operation of stacks run **O(1)** in a constant time.

#### Examples:

1- We can use stacks to reverse string like blow code:

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

Queue is data structure similar to stack but in queue for adding new item to top should remove item from bottom of queue as shown below:

![queue.png](https://github.com/mohsenasadi501/DataStructureAlgorithm/blob/main/images/queue.png)

- [x] **Queues are FIFO (First-In First-Out)**

- [x] **Stacks are LIFO (Last-In First-Out)**

Queues are similar to real work queue, that people join the line from the back and leave from front

#### Operations in Queues:

- **enqueue()** Add item to back of the queue

- **dequue()** Remove item from front of queue

- **peek()** Get item from front without remove it

- **isEmpty()**

- **isFull()**

All operation of stacks run **O(1)** in a constant time and we can say is so fast.

For example if you want to reverse queue in this case again you should use stack, in every situation if you want to reverse you should use stack.

#### Examples:

###### 1: The below code show how to create a queue with Array:

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

Above code use curcular array to solve a problem of fix array size.



###### 2: Implement Queue with stack:

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

Implementing queue with stack need two stack that stack1 for enqueue and stack2 for dequeue.



**What is PriorityQueue?**

PriorityQueue is similar to Queue but it not depend on priority of adding item it depends on the second item that is priority:

```csharp
// First param of class is calue and second of it is priority
PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>();
priorityQueue.Enqueue(2, 1);
priorityQueue.Enqueue(3, 3);
priorityQueue.Enqueue(4, 2);
```
