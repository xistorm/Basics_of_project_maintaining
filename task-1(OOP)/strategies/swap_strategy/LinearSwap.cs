using Strategies.OrderStrategy;

namespace Strategies.SwapStrategy;

public class LinearSwap : ISwapStrategy {
    public virtual bool NeedToSwap(IOrderStrategy order, double[] a, double[] b) => throw new InvalidOperationException();
    public bool NeedToSwap(IOrderStrategy order, double a, double b) => order.Compare(a, b) == -1;
}