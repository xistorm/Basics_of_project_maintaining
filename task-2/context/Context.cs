using System;
using System.Linq;
using Broker;

namespace UserContext;

public class Context {
    private bool _exit = false;
    private int _option = -1;
    private List<ISubscriber> _avaliable_subscribers = new ();
    private List<ISubscriber> _active_subscribers = new ();
    private IPublisher _countdouwn = new Countdown();

    public void Run() {
        string header = "Выберите категорию:";
        string[] optionList = { "Добавить нового пользователя", "Подписать пользователя на рассылку", "Убрать пользователя из рассылки", "Разослать сообщение", "Выход" };

        while(!_exit) {
            Menu(header, optionList);

            switch(_option) {
                case 1:
                    AddAvaliableSubscriber();
                    break;
                case 2:
                    AddSubscriber();
                    break;
                case 3:
                    RemoveSubscriber();
                    break;
                case 4:
                    NotifySubscribers();
                    break;
                case 5:
                    _exit = true;
                    break;
                default:
                    break;
            }
        } 
    }

    private void Menu(string header, string[] optionList) {
        Console.Clear();
        if (optionList.Length == 0) {
            _option = -1;
            return;
        }

        string menu = $"{header}\n{String.Join("\n", optionList.Select((option, index) => $"{index + 1} - {option}"))}";
        Console.WriteLine(menu);
        while (!int.TryParse(Console.ReadLine(), out _option) && _option <= 0 && _option > optionList.Length);
    }

    private void AddAvaliableSubscriber() {
        string header = "Кем является новый пользователь:";
        string[] optionList = { "Сотрудник", "Студент", "Не уточняется" };
        string details = "Его имя: ";

        Menu(header, optionList);
        Console.WriteLine(details);
        string name = Console.ReadLine();

        switch (_option) {
            case 1:
                _avaliable_subscribers.Add(new Employee(name));
                break;
            case 2:
                _avaliable_subscribers.Add(new Student(name));
                break;
            case 3:
                _avaliable_subscribers.Add(new Person(name));
                break;
        }
    }

    private void AddSubscriber() {
        string header = "Кого добавить на рассылку:";
        string[] optionList = _avaliable_subscribers.Select(item => item.ToString()).ToArray();

        Menu(header, optionList);
        if (_option == -1) return;

        _countdouwn.AddSubscriber(_avaliable_subscribers[_option - 1]);
        _active_subscribers.Add(_avaliable_subscribers[_option - 1]);
        _avaliable_subscribers.RemoveAt(_option - 1);
    }

    private void RemoveSubscriber() {
        string header = "Кого убрать из рассылки:";
        string[] optionList = _active_subscribers.Select(item => item.ToString()).ToArray();

        Menu(header, optionList);
        if (_option == -1) return;

        _countdouwn.RemoveSubscriber(_active_subscribers[_option - 1]);
        _avaliable_subscribers.Add(_active_subscribers[_option - 1]);
        _active_subscribers.RemoveAt(_option - 1);
    }

    private void NotifySubscribers() {
        Console.WriteLine($"Введите сообщение, которое хотите отправить {_active_subscribers.Count} людям:");
        string message = Console.ReadLine();
        Console.WriteLine($"Укажите задержку перед отправлением (ms): ");
        int delay = 0;
        while(!int.TryParse(Console.ReadLine(), out delay)) {};
        _countdouwn.NotifySubscribers(message, delay);
        Console.WriteLine("Для продолжения нажмите любую кнопку...");
        Console.ReadKey();
    }
}