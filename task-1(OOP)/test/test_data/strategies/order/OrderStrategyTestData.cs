using System.Collections.Generic;
using System.Linq;
using Strategies.OrderStrategy;
using Tests.DataSets;

namespace Tests.Data;

public static class OrderStrategyTestData {
    public static IEnumerable<object[]> GetAscendingData() => OrderStrategyDataSets.AscendingDataSets.Select(dataSet => new object[] { dataSet.Order, dataSet.a, dataSet.b, dataSet.Expected });
    public static IEnumerable<object[]> GetDescendingData() => OrderStrategyDataSets.DescendingDataSets.Select(dataSet => new object[] { dataSet.Order, dataSet.a, dataSet.b, dataSet.Expected });
}