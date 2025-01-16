# Task-Based Asynchronous Pattern in C#

---

## Table of Contents

1. [What is Task-Based Asynchronous Pattern?](#what-is-task-based-asynchronous-pattern)
2. [Benefits of Using TAP](#benefits-of-using-tap)
3. [Key Components of TAP](#key-components-of-tap)
4. [How to Use TAP in C#](#how-to-use-tap-in-c)
    - [Example: Basic Usage](#example-basic-usage)
    - [Example: Handling Exceptions](#example-handling-exceptions)
    - [Example: Chaining Tasks](#example-chaining-tasks)
    - [Example: Using WhenAll and WhenAny](#example-using-whenall-and-whenany)
    - [Example: Canceling Tasks](#example-canceling-tasks)
5. [Best Practices](#best-practices)
6. [Resources](#resources)

---

## What is Task-Based Asynchronous Pattern?

The **Task-Based Asynchronous Pattern (TAP)** is a programming model introduced in .NET Framework 4 to simplify writing asynchronous code. It uses the `Task` and `Task<T>` types to represent asynchronous operations, allowing developers to write cleaner and more maintainable code.

TAP enables asynchronous methods to be defined using the `async` and `await` keywords, providing a straightforward way to perform non-blocking I/O operations or computations.

---

## Benefits of Using TAP

- **Simplifies asynchronous code**: Makes the code more readable and easier to write.
- **Non-blocking operations**: Frees up threads, improving application responsiveness.
- **Improved performance**: Efficiently handles multiple asynchronous operations without unnecessary thread creation.
- **Error propagation**: Exceptions are automatically captured and can be handled using `try-catch` blocks.
- **Support for cancellation and progress reporting**.

---

## Key Components of TAP

1. **`Task` and `Task<T>`**: Represent the result of an asynchronous operation.
2. **`async` and `await` keywords**:
   - `async`: Marks a method as asynchronous.
   - `await`: Suspends the execution of an async method until the awaited task is complete.
3. **CancellationToken**: Enables cancellation of a task.
4. **TaskContinuationOptions**: Allows customization of task continuation behavior.

---

## How to Use TAP in C#

### Example: Basic Usage
```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting asynchronous operation...");

        int result = await PerformCalculationAsync();

        Console.WriteLine($"Result: {result}");
    }

    static async Task<int> PerformCalculationAsync()
    {
        await Task.Delay(2000); // Simulate a delay
        return 42; // Simulated result
    }
}
```

### Example: Handling Exceptions
```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            int result = await PerformCalculationAsync();
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static async Task<int> PerformCalculationAsync()
    {
        await Task.Delay(1000);
        throw new InvalidOperationException("Calculation failed.");
    }
}
```

### Example: Chaining Tasks
```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        int result = await PerformCalculationAsync()
            .ContinueWith(t => t.Result * 2);

        Console.WriteLine($"Chained Result: {result}");
    }

    static async Task<int> PerformCalculationAsync()
    {
        await Task.Delay(1000);
        return 21;
    }
}
```

### Example: Using WhenAll and WhenAny

#### WhenAll
`Task.WhenAll` waits for all provided tasks to complete before continuing.

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Task<int> task1 = PerformCalculationAsync(10);
        Task<int> task2 = PerformCalculationAsync(20);

        int[] results = await Task.WhenAll(task1, task2);

        Console.WriteLine($"Results: {string.Join(", ", results)}");
    }

    static async Task<int> PerformCalculationAsync(int value)
    {
        await Task.Delay(1000);
        return value * 2;
    }
}
```

#### WhenAny
`Task.WhenAny` continues as soon as any of the provided tasks completes.

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Task<int> task1 = PerformCalculationAsync(10);
        Task<int> task2 = PerformCalculationAsync(20);

        Task<int> completedTask = await Task.WhenAny(task1, task2);

        Console.WriteLine($"First completed task result: {await completedTask}");
    }

    static async Task<int> PerformCalculationAsync(int value)
    {
        await Task.Delay(value * 100); // Simulate variable delay
        return value * 2;
    }
}
```

### Example: Canceling Tasks
You can cancel tasks using a `CancellationToken`.

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using CancellationTokenSource cts = new CancellationTokenSource();

        Task task = PerformCalculationAsync(cts.Token);

        cts.CancelAfter(1500); // Cancel the task after 1.5 seconds

        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task was canceled.");
        }
    }

    static async Task PerformCalculationAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 5; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(1000, cancellationToken);
            Console.WriteLine($"Step {i + 1} completed.");
        }

        Console.WriteLine("Calculation completed.");
    }
}
```

---

## Best Practices

1. **Avoid blocking calls**: Do not use `.Wait()` or `.Result` on tasks in an async context.
2. **Use `ConfigureAwait(false)`**: For library code, to avoid capturing the synchronization context.
3. **Handle exceptions**: Always wrap asynchronous calls with proper exception handling.
4. **Cancellation tokens**: Provide a way to cancel long-running tasks.
5. **Test asynchronous code**: Use appropriate test frameworks that support async methods.

---

## Resources

- [Microsoft Documentation: Asynchronous Programming with async and await](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)
- [Task-Based Asynchronous Pattern (TAP) Overview](https://learn.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap)
- [Async Best Practices in C#](https://learn.microsoft.com/en-us/dotnet/csharp/async)

---

Feel free to contribute to this guide or share your feedback by submitting an issue or pull request!