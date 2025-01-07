# Delegates in C#

## Introduction

Delegates in C# are type-safe function pointers that allow methods to be passed as parameters. They provide a way to encapsulate and invoke methods dynamically at runtime. Delegates are widely used in scenarios such as event handling, callback methods, and designing extensible systems.

## Key Features

1. **Type Safety**: Delegates are type-safe, ensuring that the method signature matches the delegate definition.
2. **Encapsulation**: Delegates encapsulate methods and allow them to be invoked at runtime.
3. **Multicasting**: A delegate can hold references to multiple methods, enabling multicasting.

---

## Syntax

### Declaring a Delegate
```csharp
// Syntax: access_modifier delegate return_type DelegateName(parameter_list);
public delegate void MyDelegate(string message);
```

### Instantiating a Delegate
```csharp
MyDelegate del = new MyDelegate(MethodName);
```

### Invoking a Delegate
```csharp
del("Hello, Delegates!");
```

---

## Types of Delegates

1. **Single-Cast Delegate**
   - A delegate that references a single method.

2. **Multi-Cast Delegate**
   - A delegate that references multiple methods. Methods are invoked in the order they are added.

---

## Example

### Single-Cast Delegate Example
```csharp
using System;

public class Program
{
    public delegate void GreetDelegate(string name);

    public static void Greet(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }

    public static void Main()
    {
        GreetDelegate greetDel = new GreetDelegate(Greet);
        greetDel("Alice");
    }
}
```

### Multi-Cast Delegate Example
```csharp
using System;

public class Program
{
    public delegate void Notify();

    public static void NotifyAdmin()
    {
        Console.WriteLine("Admin notified.");
    }

    public static void NotifyUser()
    {
        Console.WriteLine("User notified.");
    }

    public static void Main()
    {
        Notify notifyDel = NotifyAdmin;
        notifyDel += NotifyUser;

        notifyDel();
    }
}
```

---

## Built-in Delegates

C# provides three commonly used built-in delegate types in the `System` namespace:

1. **Action**: Represents a method that performs an action and does not return a value.
   ```csharp
   Action<string> print = Console.WriteLine;
   print("Hello Action!");
   ```

2. **Func**: Represents a method that returns a value.
   ```csharp
   Func<int, int, int> add = (a, b) => a + b;
   Console.WriteLine(add(3, 5));
   ```

3. **Predicate**: Represents a method that returns a boolean value.
   ```csharp
   Predicate<int> isPositive = x => x > 0;
   Console.WriteLine(isPositive(10));
   ```

---

## Use Cases

1. **Event Handling**
   - Delegates are extensively used in designing event-driven applications.

2. **Callback Methods**
   - Delegates enable passing methods as arguments for callbacks.

3. **LINQ and Functional Programming**
   - Delegates are heavily utilized in LINQ queries and functional programming paradigms.

---

## Advantages

- Encourages code reusability and modularity.
- Facilitates event-driven programming.
- Provides a way to invoke methods dynamically.

---

## Conclusion

Delegates are a powerful feature in C# that enable developers to write flexible and extensible code. Understanding and leveraging delegates can significantly enhance your ability to write maintainable and dynamic applications.

For more information, refer to the [Microsoft Documentation on Delegates](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/).
