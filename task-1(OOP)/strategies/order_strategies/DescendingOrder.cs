namespace Strategies.OrderStrategy;

public class DescendingOrder : IOrderStrategy {
    public int Compare<T>(T a, T b) where T : IComparable => a.CompareTo(b);
}