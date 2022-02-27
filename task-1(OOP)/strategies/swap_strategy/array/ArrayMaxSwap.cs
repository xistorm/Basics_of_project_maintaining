using System;
using System.Linq;
using Strategies.OrderStrategy;
using Strategies.SwapStrategy;

namespace Strategies.SwapStrategy.Array;

public class ArrayMaxSwap : LinearSwap {
    public sealed override bool NeedToSwap(IOrderStrategy order, double[] a, double[] b) => order.Compare(a.Sum(), b.Sum()) == -1;
}