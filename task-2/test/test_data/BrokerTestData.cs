using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Test.Utils;
using Broker;

namespace Test.Data;

public static class BrokerTestData {
    private static readonly List<(Type Type, string Name, string Expected, bool ExpectedException)> personDataSets = new () {
        (typeof(Person), "Lukas", "Lukas", false),
        (typeof(Person), "Tom123321", "Tom123321", false),
        (typeof(Person), "", "", true),
        (typeof(Student), "Lukas", "Студент Lukas", false),
        (typeof(Student), "Tom123321", "Студент Tom123321", false),
        (typeof(Student), "", "", true),
        (typeof(Employee), "Lukas", "Сотрудник Lukas", false),
        (typeof(Employee), "Tom123321", "Сотрудник Tom123321", false),
        (typeof(Employee), "", "", true),
    };

    private static readonly List<(Type Type, ISubscriber[] subscribers, string Message, bool ExpectedException)> publisherDataSets = new () {
        (typeof(Countdown), new ISubscriber[] { new Person("Lukas") }, "kekW", false),
        (typeof(Countdown), new ISubscriber[] { new Person("Lukas"), new Student("Tom123321"), new Employee("Bob") }, "kekU", false),
        (typeof(Countdown), new ISubscriber[] { }, "jijaRot", true),
        (typeof(Countdown), new ISubscriber[] { null }, "", true),
    };

    public static IEnumerable<object[]> GetPersonData() => personDataSets.Select(dataSet => new object[] { dataSet.Type, dataSet.Name, dataSet.Expected, dataSet.ExpectedException });
    public static IEnumerable<object[]> GetCountdownData() => publisherDataSets.Select(dataSet => new object[] { dataSet.Type, dataSet.subscribers, dataSet.Message, dataSet.ExpectedException });
}