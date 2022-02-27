namespace Strategies.OrderStrategy;

public interface IOrderStrategy {
    int Compare<T>(T a, T b) where T : IComparable;
}