using System.Collections.Generic;
using Strategies.OrderStrategy;

namespace Tests.DataSets;

public static class OrderStrategyDataSets {
    public static readonly List<(IOrderStrategy Order, int a, int b, int Expected)> AscendingDataSets = new () {
        (new AscendingOrder(), 1, 2, 1),
        (new AscendingOrder(), 2, 1, -1),
        (new AscendingOrder(), 2, 2, 0),
    };
    public static readonly List<(IOrderStrategy Order, int a, int b, int Expected)> DescendingDataSets = new () {
        (new DescendingOrder(), 1, 2, -1),
        (new DescendingOrder(), 2, 1, 1),
        (new DescendingOrder(), 2, 2, 0),
    };
}