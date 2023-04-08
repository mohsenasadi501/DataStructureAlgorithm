# 1:

In the first part of this document you would Learn:

1. **[Big O Notation](#Big_O_Notation)**

2. **Arrays**

3. **Linked Lists**

4. **Stacks**

5. **Queues**

6. **Hash Tables**



## Big_O_Notation

We use Big O Notation to describe performance of algorithm and how scalabe algorithm is.

The below code show **O(1)** becuase the code run in a constant time.

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

Linear rate grows as the same rate but the logarithmic carve down on some point, logarithmic is more efficent and scalabe compare to linear or other.

Exponential (نمایی) is the opossit of logarithmic (لگاریتمی) methods as shown below.

Types of BigO:

- Constant   O(1)

- Logarithmic   O(log n)

- Linear   O(n)

- Quadratic   O(n^ 2)

- Exponential   O(2 ^ n)

![algorithm.png](D:\OneDrive\MarkDown\DSA\algorithm.png)
