namespace Broker;

public interface ISubscriber {
    string Info { get; }
    void Update(string message);
    string ToString();
}