using System;
using Strategies.OrderStrategy;
using Strategies.SwapStrategy;

namespace Strategies.SortStrategy.BubbleSort;

public class LinearBubbleSort : SortStrategy {
    public sealed override void Sort(ref double[][] matrix, IOrderStrategy order, ISwapStrategy swap) {
        int index = 0;
        int length = matrix.Select(row => row.Length).Sum();
        double[] linearArray = new double[length];

        foreach (var row in matrix) {
            foreach (var item in row) {
                linearArray[index++] = item;
            }
        }

        for (int i = 0; i < length - 1; ++i) {
            for (int j = i + 1; j < length; ++j) {
                if (swap.NeedToSwap(order, linearArray[i], linearArray[j])) {
                    Swap(ref linearArray[i], ref linearArray[j]);
                }
            }
        }

        index = 0;
        for (int i = 0; i < matrix.Length; ++i) {
            for (int j = 0; j < matrix[i].Length; ++j) {
                matrix[i][j] = linearArray[index++];
            }
        }
    }
}