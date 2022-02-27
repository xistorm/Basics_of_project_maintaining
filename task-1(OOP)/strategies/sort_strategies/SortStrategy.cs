using System;
using Strategies.OrderStrategy;
using Strategies.SwapStrategy;

namespace Strategies.SortStrategy;

public abstract class SortStrategy : ISortStrategy {

    protected void Swap(ref double a, ref double b) => (a, b) = (b, a);

    protected void Swap(ref double[] a, ref double[] b) {
        for (int i = 0; i < a.Length; ++i) {
            Swap(ref a[i], ref b[i]);
        }
    }

    public void Sort(ref double[][] matrix) => Sort(ref matrix, new AscendingOrder());
    public void Sort(ref double[][] matrix, IOrderStrategy order) => Sort(ref matrix, order, new LinearSwap());
    public void Sort(ref double[][] matrix, ISwapStrategy swap) => Sort(ref matrix, new AscendingOrder(), swap);
    public abstract void Sort(ref double[][] matrix, IOrderStrategy order, ISwapStrategy needToSwap);
}