namespace Strategies.OrderStrategy;

public class AscendingOrder : IOrderStrategy {
    public int Compare<T>(T a, T b) where T : IComparable => b.CompareTo(a);
}