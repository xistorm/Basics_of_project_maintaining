using Strategies.OrderStrategy;
using Strategies.SwapStrategy;

namespace Strategies.SortStrategy.BubbleSort;

public class RowBubbleSort : SortStrategy {
    public sealed override void Sort(ref double[][] matrix, IOrderStrategy order, ISwapStrategy swap) {
        for (int i = 0; i < matrix.Length - 1; ++i) {
            for (int j = i + 1; j < matrix.Length; ++j) {
                if (swap.NeedToSwap(order, matrix[i], matrix[j])) {
                    Swap(ref matrix[i], ref matrix[j]);
                }
            }
        }
    }
}