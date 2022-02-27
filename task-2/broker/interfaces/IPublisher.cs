using System.Collections.Generic;

namespace Broker;

public interface IPublisher {
    List<ISubscriber> Subscribers { get; }
    public void AddSubscriber(ISubscriber subscriber);
    public void RemoveSubscriber(ISubscriber subscriber);
    public void NotifySubscribers(string message);
    public void NotifySubscribers(string message, int delay);
}