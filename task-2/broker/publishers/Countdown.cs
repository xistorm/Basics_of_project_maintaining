using System.Collections.Generic;
using System;

namespace Broker;

public class Countdown : IPublisher {
    public List<ISubscriber> Subscribers { get; private set; }

    public Countdown() => Subscribers = new ();

    public Countdown(ICollection<ISubscriber> subscribers) : this() => Subscribers.AddRange(subscribers);

    public void AddSubscriber(ISubscriber subscriber) => Subscribers.Add(subscriber);

    public void RemoveSubscriber(ISubscriber subscriber) => Subscribers.Remove(subscriber);

    public void NotifySubscribers(string message) => NotifySubscribers(message, 0);

    public void NotifySubscribers(string message, int delay) {
        if (Subscribers.Count == 0) throw new ArgumentException();

        Thread.Sleep(delay);
        Subscribers.ForEach(subscriber => subscriber.Update(message));
    }
}