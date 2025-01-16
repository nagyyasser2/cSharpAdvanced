# Generics in C#

Generics in C# allow you to define reusable, type-safe classes, methods, delegates, and interfaces. They enable you to write code that can operate on different data types without compromising type safety or performance.

## Why Use Generics?

1. **Type Safety**: Generics enforce compile-time type checking, reducing runtime errors.
2. **Code Reusability**: Write a single definition for multiple types.
3. **Performance**: Eliminate the need for boxing/unboxing and type casting, resulting in better performance.

---

## Generic Classes

A generic class defines a template that can work with any data type.

### Example

```csharp
using System;

public class GenericClass<T>
{
    private T data;

    public void SetData(T value)
    {
        data = value;
    }

    public T GetData()
    {
        return data;
    }
}

class Program
{
    static void Main()
    {
        GenericClass<int> intInstance = new GenericClass<int>();
        intInstance.SetData(42);
        Console.WriteLine(intInstance.GetData()); // Output: 42

        GenericClass<string> stringInstance = new GenericClass<string>();
        stringInstance.SetData("Hello, Generics!");
        Console.WriteLine(stringInstance.GetData()); // Output: Hello, Generics!
    }
}
```

---

## Generic Methods

A generic method allows you to define type parameters for individual methods, independent of any class type.

### Example

```csharp
using System;

class Program
{
    static void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }

    static void Main()
    {
        int a = 5, b = 10;
        Console.WriteLine($"Before Swap: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"After Swap: a = {a}, b = {b}");

        string str1 = "Hello", str2 = "World";
        Console.WriteLine($"Before Swap: str1 = {str1}, str2 = {str2}");
        Swap(ref str1, ref str2);
        Console.WriteLine($"After Swap: str1 = {str1}, str2 = {str2}");
    }
}
```

---

## Generic Interfaces

A generic interface defines a contract that can operate on multiple types.

### Example

```csharp
using System;
using System.Collections.Generic;

public interface IRepository<T>
{
    void Add(T item);
    T Get(int id);
}

public class Repository<T> : IRepository<T>
{
    private readonly Dictionary<int, T> storage = new Dictionary<int, T>();

    public void Add(T item)
    {
        int id = storage.Count + 1;
        storage[id] = item;
    }

    public T Get(int id)
    {
        return storage.ContainsKey(id) ? storage[id] : default;
    }
}

class Program
{
    static void Main()
    {
        IRepository<string> repo = new Repository<string>();
        repo.Add("Item 1");
        repo.Add("Item 2");

        Console.WriteLine(repo.Get(1)); // Output: Item 1
        Console.WriteLine(repo.Get(2)); // Output: Item 2
    }
}
```

---

## Constraints in Generics

You can restrict the types that can be used with generics by applying constraints.

### Common Constraints

- `where T : struct` (value type)
- `where T : class` (reference type)
- `where T : new()` (default constructor)
- `where T : BaseClass` (inherits a specific class)
- `where T : IInterface` (implements a specific interface)

### Example

```csharp
using System;

class GenericConstraintExample<T> where T : IComparable
{
    public bool Compare(T x, T y)
    {
        return x.CompareTo(y) > 0;
    }
}

class Program
{
    static void Main()
    {
        GenericConstraintExample<int> comparer = new GenericConstraintExample<int>();
        Console.WriteLine(comparer.Compare(10, 5)); // Output: True
    }
}
```

---

## Generic Delegates

Delegates can also be made generic to handle different types.

### Example

```csharp
using System;

public delegate T Operation<T>(T a, T b);

class Program
{
    static void Main()
    {
        Operation<int> add = (x, y) => x + y;
        Console.WriteLine(add(5, 10)); // Output: 15

        Operation<string> concatenate = (x, y) => x + y;
        Console.WriteLine(concatenate("Hello, ", "World!")); // Output: Hello, World!
    }
}
```

---

## Summary

Generics in C# are a powerful feature that enhance code flexibility, maintainability, and performance. By mastering generics, you can:

1. Reduce code duplication.
2. Improve type safety.
3. Write highly reusable and efficient code.

Generics are extensively used in the .NET framework, such as in collections (`List<T>`, `Dictionary<TKey, TValue>`), LINQ, and many other areas. Familiarity with them is essential for writing modern C# applications.
