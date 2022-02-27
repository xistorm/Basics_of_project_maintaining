using System.Collections.Generic;
using System.Linq;
using Tests.DataSets;

namespace Tests.Data;

public static class MatrixTestData {
    public static IEnumerable<int> GetSizeConstructorsData() => MatrixDataSets.ConstructorsDataSets.Select(dataSet => dataSet.Rows);
    public static IEnumerable<object[]> GetDimentionsConstructorsData() => MatrixDataSets.ConstructorsDataSets.Select(dataSet => new object[] { dataSet.Rows, dataSet.Columns });  
    public static IEnumerable<double[,]> GetInitDataConstructorsData() => MatrixDataSets.ConstructorsDataSets.Select(dataSet => dataSet.InitData);
    public static IEnumerable<object[]> GetFieldsData() => MatrixDataSets.FieldsDataSets.Select(dataSet => new object[] { dataSet.Rows, dataSet.Columns, dataSet.InitData });
    public static IEnumerable<object[]> GetSizeEmptyData() => MatrixDataSets.EmptyDataSets.Where(dataSet => dataSet.Rows == dataSet.Columns).Select(dataSet => new object[] { dataSet.Rows, dataSet.Expected });    
    public static IEnumerable<object[]> GetDimentionsEmptyData() => MatrixDataSets.EmptyDataSets.Select(dataSet => new object[] { dataSet.Rows, dataSet.Columns, dataSet.Expected });
    public static IEnumerable<object[]> GetToStringData() => MatrixDataSets.ToStringDataSets.Select(dataSet => new object[] { dataSet.InitData, dataSet.Expected });
    public static IEnumerable<object[]> GetTryParseData() => MatrixDataSets.TryParseDataSets.Select(dataSet => new object[] { dataSet.InitData, dataSet.Success, dataSet.Expected });
    public static IEnumerable<object[]> GetSortData() => MatrixDataSets.SortDataSets.Select(dataSet => new object[] { dataSet.Sort, dataSet.Swap, dataSet.InitData, dataSet.Expected });
}