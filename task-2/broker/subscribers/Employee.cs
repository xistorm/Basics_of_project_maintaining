using System;

namespace Broker;

public class Employee : Person {
    public override string Info => $"Сотрудник {_name} {_status}.";

    public Employee(string name) : base(name) {}

    public override void Update(string message)
    {
        ValidateString(message);
        _status = $"прочитал на электронной почте: \"{message}\"";
        Console.WriteLine(Info);
    }

    public override string ToString() => $"Сотрудник {_name}";
}