using Strategies.OrderStrategy;
using Strategies.SwapStrategy;

namespace Strategies.SortStrategy;

public interface ISortStrategy {
    void Sort(ref double[][] matrix);
    void Sort(ref double[][] matrix, IOrderStrategy order);
    void Sort(ref double[][] matrix, ISwapStrategy needToSwap);
    void Sort(ref double[][] matrix, IOrderStrategy order, ISwapStrategy needToSwap);
}