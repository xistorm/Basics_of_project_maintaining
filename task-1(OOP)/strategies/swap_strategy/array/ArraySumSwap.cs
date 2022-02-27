using System;
using System.Linq;
using Strategies.OrderStrategy;
using Strategies.SwapStrategy;

namespace Strategies.SwapStrategy.Array;

public class ArraySumSwap : LinearSwap {
    public sealed override bool NeedToSwap(IOrderStrategy order, double[] a, double[] b) => order.Compare(a.Max(), b.Max()) == -1;
}