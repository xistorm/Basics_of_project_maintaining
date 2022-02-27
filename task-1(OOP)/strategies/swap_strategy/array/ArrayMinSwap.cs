using System;
using System.Linq;
using Strategies.OrderStrategy;
using Strategies.SwapStrategy;

namespace Strategies.SwapStrategy.Array;

public class ArrayMinSwap : LinearSwap {
    public sealed override bool NeedToSwap(IOrderStrategy order, double[] a, double[] b) => order.Compare(a.Min(), b.Min()) == -1;
}