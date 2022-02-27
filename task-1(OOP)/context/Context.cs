using UserMatrix;
using Strategies.OrderStrategy;
using Strategies.SortStrategy;
using Strategies.SwapStrategy;
using Strategies.SwapStrategy.Array;
using Strategies.SortStrategy.BubbleSort;

namespace UserContext;

public class Context {
    private bool _exit;
    private int _option;
    private Matrix? _matrix;
    private ISortStrategy? _sortStrategy;
    private ISwapStrategy? _swapStrategy;
    private IOrderStrategy? _orderStrategy;

    public void Run() {
        string header = "Выберите действие";
        string[] optionList = { "Ввести матрицу", "Выбрать тип сортировки", "Установить тип сравнения", "Вывести результат", "Выйти" };

        while (!_exit) {
            Menu(header, optionList);

            switch (_option) {
                case 1:
                    SetMatrix();
                    break;
                case 2:
                    SetSortStrategy();
                    break;
                case 3:
                    SetOrderStrategy();
                    break;
                case 4:
                    PrintResult();
                    break;
                case 5:
                    _exit = true;
                    break;
            }
        }
    }

    private void Menu(string header, string[] optionList) {
        Console.Clear();
        string menu = $"{header}\n{String.Join("\n", optionList.Select((option, index) => $"{index + 1} - {option}"))}";

        Console.WriteLine(menu);
        while (!int.TryParse(Console.ReadLine(), out _option) && _option <= 0 && _option > optionList.Length) {};
    }

    private void SetMatrix() {
        do {
            Console.Clear();
            Console.WriteLine("Введите матрицу в формате a a a, a a a, ...");
        } while (!Matrix.TryParse(Console.ReadLine(), out _matrix));
    }

    private void SetSortStrategy() {
        string header = "Сортировка по:";
        string[] optionList = { "Cумме элементов строки", "Максимальному элементу строки", "Минимальному элементу строки", "Линейная" };
        Menu(header, optionList);
        

        switch(_option) {
            case 1:
                _sortStrategy = new RowBubbleSort();
                _swapStrategy = new ArraySumSwap();
                break;
            case 2:
                _swapStrategy = new ArrayMaxSwap();
                _sortStrategy = new RowBubbleSort();
                break;
            case 3:
                _swapStrategy = new ArrayMinSwap();
                _sortStrategy = new RowBubbleSort();
                break;
            case 4:
                _swapStrategy = new LinearSwap();
                _sortStrategy = new LinearBubbleSort();
                break;
        }
    }

    private void SetOrderStrategy() {
        string header = "Сортировка по:";
        string[] optionList = { "Возрастанию", "Убыванию" };
        Menu(header, optionList);

        switch(_option) {
            case 1:
                _orderStrategy = new AscendingOrder();
                break;
            case 2:
                _orderStrategy = new DescendingOrder();
                break;
            default:
                _orderStrategy = new AscendingOrder();
                break;
        }
    }

    private void PrintResult() {
        Console.Clear();
        if(_matrix == null || _sortStrategy == null || _orderStrategy == null || _swapStrategy == null) {
            Console.WriteLine("А сортировать то нечего...");
        } else {
            Console.WriteLine("Сортируем...");
            int delay = new Random().Next() % 500 + 500;
            Thread.Sleep(delay);
            _matrix.Sort(_sortStrategy, _orderStrategy, _swapStrategy);
            Console.WriteLine("Результат сортировки: ");
            Console.WriteLine(_matrix);
        }
        Console.WriteLine("Чтобы продолжить нажмите любую кнопку...");
        Console.ReadKey();
    }
}
