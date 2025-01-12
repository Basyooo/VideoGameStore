using System;
using System.Collections.Generic;

public interface ICartObserver
{
    void Update(string message);
}

public class User : ICartObserver
{
    public string UserName { get; set; }

    public void Update(string message)
    {
        Console.WriteLine($"Notification for {UserName}: {message}");
    }
}

public class Cart
{
    private readonly List<ICartObserver> _observers = new List<ICartObserver>();

    public void AddObserver(ICartObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(ICartObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }

    public void AddItem(string itemName)
    {
        NotifyObservers($"{itemName} has been added to the cart.");
    }
}
