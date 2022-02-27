using System.Collections.Generic;
using System.Linq;
using Strategies.OrderStrategy;
using Tests.DataSets;

namespace Tests.Data;

public static class SortStrategyTestData {
    public static IEnumerable<object[]> GetLinearSortData() => SortStrategyDataSets.LinearSortDataSets.Select(dataSet => new object[] { dataSet.Sort, dataSet.Swap, dataSet.Matrix, dataSet.Expected });
    public static IEnumerable<object[]> GetRowSumSortData() => SortStrategyDataSets.RowSumSortDataSets.Select(dataSet => new object[] { dataSet.Sort, dataSet.Swap, dataSet.Matrix, dataSet.Expected });
    public static IEnumerable<object[]> GetRowMaxSortData() => SortStrategyDataSets.RowMaxSortDataSets.Select(dataSet => new object[] { dataSet.Sort, dataSet.Swap, dataSet.Matrix, dataSet.Expected });
    public static IEnumerable<object[]> GetRowMinSortData() => SortStrategyDataSets.RowMinSortDataSets.Select(dataSet => new object[] { dataSet.Sort, dataSet.Swap, dataSet.Matrix, dataSet.Expected });
}