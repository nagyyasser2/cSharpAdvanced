# Events in C#

## Introduction

Events in C# provide a way to enable communication between objects. They are a key feature of the observer design pattern, allowing objects to notify other objects when something of interest happens. Events are extensively used in graphical user interfaces, where user interactions like button clicks trigger corresponding responses.

## Table of Contents

1. [What Are Events?](#what-are-events)
2. [Defining an Event](#defining-an-event)
3. [Subscribing to an Event](#subscribing-to-an-event)
4. [Unsubscribing from an Event](#unsubscribing-from-an-event)
5. [Examples](#examples)
   - [Basic Event Example](#basic-event-example)
   - [Custom Event Example](#custom-event-example)
6. [Best Practices](#best-practices)

---

## What Are Events?

An event is a way for a class to notify other classes or objects that something has occurred. Events in C# are based on delegates, which are type-safe function pointers. The typical use case involves:

1. **Publishing an Event**: The class that raises the event is called the publisher.
2. **Subscribing to an Event**: The classes that handle the event are called subscribers.

---

## Defining an Event

To define an event, you:

1. Declare a delegate that specifies the signature of the event handler methods.
2. Use the `event` keyword to define an event based on that delegate.

```csharp
public delegate void MyEventHandler(string message);

public class Publisher
{
    public event MyEventHandler OnMessagePublished;

    public void PublishMessage(string message)
    {
        OnMessagePublished?.Invoke(message);
    }
}
```

---

## Subscribing to an Event

To handle an event, you need to subscribe to it by assigning a method that matches the delegate signature:

```csharp
public class Subscriber
{
    public void HandleMessage(string message)
    {
        Console.WriteLine($"Received message: {message}");
    }
}

// Usage
Publisher publisher = new Publisher();
Subscriber subscriber = new Subscriber();

publisher.OnMessagePublished += subscriber.HandleMessage;
publisher.PublishMessage("Hello, World!");
```

---

## Unsubscribing from an Event

Unsubscribing from an event is as simple as using the `-=` operator:

```csharp
publisher.OnMessagePublished -= subscriber.HandleMessage;
```

This step is essential to prevent memory leaks, especially in long-running applications.

---

## Examples

### Basic Event Example

```csharp
using System;

public class Timer
{
    public event Action Tick;

    public void Start(int interval)
    {
        while (true)
        {
            System.Threading.Thread.Sleep(interval);
            Tick?.Invoke();
        }
    }
}

class Program
{
    static void Main()
    {
        Timer timer = new Timer();
        timer.Tick += () => Console.WriteLine("Tick event triggered");
        timer.Start(1000); // Triggers every second
    }
}
```

### Custom Event Example

```csharp
using System;

public class BankAccount
{
    public delegate void BalanceChangedHandler(decimal newBalance);
    public event BalanceChangedHandler BalanceChanged;

    private decimal balance;

    public void Deposit(decimal amount)
    {
        balance += amount;
        BalanceChanged?.Invoke(balance);
    }

    public void Withdraw(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            BalanceChanged?.Invoke(balance);
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();
        account.BalanceChanged += newBalance => Console.WriteLine($"New balance: {newBalance}");

        account.Deposit(100);
        account.Withdraw(50);
        account.Withdraw(100);
    }
}
```

---

## Best Practices

1. **Use `EventHandler` and `EventHandler<T>`**: For most cases, these predefined delegates are sufficient and follow standard conventions.
2. **Check for Null**: Always check if the event has subscribers before invoking it using `?.Invoke`.
3. **Avoid Exposing Events Directly**: Use methods to add or remove event handlers to encapsulate event logic.
4. **Detach Event Handlers**: Always detach event handlers to avoid memory leaks.

---

## Conclusion

Events in C# are a powerful feature for enabling communication between objects in a loosely coupled way. By understanding how to define, subscribe to, and manage events, you can build more robust and maintainable applications.

Feel free to explore and experiment with events to harness their full potential!
