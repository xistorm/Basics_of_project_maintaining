using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using Test.Utils;
using Test.Data;
using Broker;

namespace Test;

public class BrokerTest {
    private ConsoleReader _consoleReader;
    private Dictionary<Type, Func<string, ISubscriber>> _createSubscriber;
    private Dictionary<Type, Func<IPublisher>> _createPublisherEmpty;
    private Dictionary<Type, Func<ICollection<ISubscriber>, IPublisher>> _createPublisherInitData;

    [SetUp]
    public void Setup() {
        _consoleReader = new ConsoleReader();
        _createSubscriber = new () {
            { typeof(Person), (string name) => new Person(name) },
            { typeof(Student), (string name) => new Student(name) },
            { typeof(Employee), (string name) => new Employee(name) },
        };
        _createPublisherEmpty = new () {
            { typeof(Countdown), () => new Countdown() },
        };
        _createPublisherInitData = new () {
            { typeof(Countdown), (ICollection<ISubscriber> subscribers) => new Countdown(subscribers) },
        };
    }

    [Test]
    [Category("Subscriber")]
    [TestCaseSource(typeof(BrokerTestData), nameof(BrokerTestData.GetPersonData))]
    public void SubscriberToStringTest(Type type, string name, string expected, bool expectedException) {
        if (expectedException) {
            Assert.Catch(() => _createSubscriber[type](name));
        } else {
            Assert.AreEqual(expected, _createSubscriber[type](name).ToString());
        }
    }

    [Test]
    [Category("Subscriber")]
    [TestCaseSource(typeof(BrokerTestData), nameof(BrokerTestData.GetPersonData))]
    public void SubscriberUpdateTest(Type type, string name, string expected, bool expectedException) {
        if (expectedException) {
            Assert.Catch(() => _createSubscriber[type](name));
        } else {
            ISubscriber subscriber = _createSubscriber[type](name);
            string prevInfo = subscriber.Info;
            subscriber.Update("a");
            string newInfo = subscriber.Info;

            Assert.AreNotEqual(prevInfo, newInfo);
        }
    }

    [Test]
    [Category("Publisher")]
    [TestCaseSource(typeof(BrokerTestData), nameof(BrokerTestData.GetCountdownData))]
    public void PublisherConstructorInitDataTest(Type type, ISubscriber[] subscribers, string expected, bool expectedException) {
        IPublisher publisher = _createPublisherInitData[type](subscribers);
        Assert.AreEqual(publisher.Subscribers.Count, subscribers.Length);
    }

    [Test]
    [Category("Publisher")]
    [TestCaseSource(typeof(BrokerTestData), nameof(BrokerTestData.GetCountdownData))]
    public void PublisherAddSubscriberTest(Type type, ISubscriber[] subscribers, string message, bool expectedException) {
        IPublisher publisher = _createPublisherEmpty[type]();

        for (int i = 0; i < subscribers.Length; ++i) {
            publisher.AddSubscriber(subscribers[i]);
            Assert.AreEqual(publisher.Subscribers.Count, i + 1);
        }
    }

    [Test]
    [Category("Publisher")]
    [TestCaseSource(typeof(BrokerTestData), nameof(BrokerTestData.GetCountdownData))]
    public void PublisherRemoveSubscriberTest(Type type, ISubscriber[] subscribers, string message, bool expectedException) {
        IPublisher publisher = _createPublisherInitData[type](subscribers);

        for (int i = subscribers.Length - 1; i >= 0; --i) {
            publisher.RemoveSubscriber(subscribers[i]);
            Assert.AreEqual(publisher.Subscribers.Count, i);
        }
    }

    [Test]
    [Category("Publisher")]
    [TestCaseSource(typeof(BrokerTestData), nameof(BrokerTestData.GetCountdownData))]
    public void PublisherNotifyTest(Type type, ISubscriber[] subscribers, string message, bool expectedException) {
        IPublisher publisher = _createPublisherInitData[type](subscribers);
        if (expectedException) {
            Assert.Catch(() => publisher.NotifySubscribers(message));
        } else {
            publisher.NotifySubscribers(message);
            string output = _consoleReader.GetOutput();
            output = output.Remove(output.Length - 1);

            foreach(var row in output.Split("\n")) {
                Assert.That(row, Does.Contain(message));
            }
        }
    }
}