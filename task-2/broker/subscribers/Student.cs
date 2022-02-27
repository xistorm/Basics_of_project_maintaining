using System;

namespace Broker;

public class Student : Person {
    public override string Info => $"Студент {_name} {_status}.";

    public Student(string name) : base(name) {}

    public override void Update(string message)
    {
        ValidateString(message);
        _status = $"получил смс: \"{message}\"";
        Console.WriteLine(Info);
    }

    public override string ToString() => $"Студент {_name}";
}