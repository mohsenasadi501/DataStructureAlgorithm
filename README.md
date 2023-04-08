# 1:

In the first part of this document you would Learn:

1. **[Big O Notation](#Big-O-Notation)**

2. **Arrays**

3. **Linked Lists**

4. **Stacks**

5. **Queues**

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

Types of BigO:

- Constant   O(1)

- Logarithmic   O(log n)

- Linear   O(n)

- Quadratic   O(n^ 2)

- Exponential   O(2 ^ n)

![algorithm.png](D:\Development\DSA%20Sample\DataStructureAlgorithm\images\algorithm.png)

As it shown in above image constant type grows linearly as the same rate but the logarithmic curve down on some point, logarithmic is more efficent and scalabe compare to linear or other and exponential is the opossit of logarithmic and is not efficent to use and has a lot cost.
