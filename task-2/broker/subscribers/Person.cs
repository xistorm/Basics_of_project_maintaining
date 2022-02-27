using System;

namespace Broker;

public class Person : ISubscriber {
    protected string _name;
    protected string _status;
    public virtual string Info => $"{_name} {_status}.";

    protected static void ValidateString(string name) {
        if (name.Length == 0) throw new NullReferenceException();
    }

    public Person(string name) {
        ValidateString(name);
        _name = name;
    }

    public virtual void Update(string message) {
        ValidateString(message);
        _status = $"услышал: \"{message}\"";
        Console.WriteLine(Info);
    }

    public override string ToString() => _name;
}