using Strategies.OrderStrategy;

namespace Strategies.SwapStrategy;

public interface ISwapStrategy {
    bool NeedToSwap(IOrderStrategy order, double a, double b);
    bool NeedToSwap(IOrderStrategy order, double[] a, double[] b);
}