using NUnit.Framework;
using Strategies.OrderStrategy;
using Strategies.SortStrategy;
using Strategies.SwapStrategy;
using Tests.Data;
using Tests.UserUtils;

namespace Tests;

[TestFixture]
public class Strategies {
    [Test]
    [Category("Order strategy")]
    [TestCaseSource(typeof(OrderStrategyTestData), nameof(OrderStrategyTestData.GetAscendingData))]
    public void AscendingOrder(IOrderStrategy order, int a, int b, int expected) {
        Assert.AreEqual(order.Compare(a, b), expected);
    }

    [Test]
    [Category("Order strategy")]
    [TestCaseSource(typeof(OrderStrategyTestData), nameof(OrderStrategyTestData.GetDescendingData))]
    public void DescendingOrder(IOrderStrategy order, int a, int b, int expected) {
        Assert.AreEqual(order.Compare(a, b), expected);
    }

    [Test]
    [Category("Sort strategy")]
    [TestCaseSource(typeof(SortStrategyTestData), nameof(SortStrategyTestData.GetLinearSortData))]
    public void LinearSort(ISortStrategy sort, ISwapStrategy swap, double[][] matrix, double[][] expected) {
        sort.Sort(ref matrix, swap);
        Utils.CompareMatrixItems(matrix, expected);
    }

    [Test]
    [Category("Sort strategy")]
    [TestCaseSource(typeof(SortStrategyTestData), nameof(SortStrategyTestData.GetRowSumSortData))]
    public void RowSumSort(ISortStrategy sort, ISwapStrategy swap, double[][] matrix, double[][] expected) {
        sort.Sort(ref matrix, swap);
        Utils.CompareMatrixItems(matrix, expected);
    }

    [Test]
    [Category("Sort strategy")]
    [TestCaseSource(typeof(SortStrategyTestData), nameof(SortStrategyTestData.GetRowMaxSortData))]
    public void RowMaxSort(ISortStrategy sort, ISwapStrategy swap, double[][] matrix, double[][] expected) {
        sort.Sort(ref matrix, swap);
        Utils.CompareMatrixItems(matrix, expected);
    }

    [Test]
    [Category("Sort strategy")]
    [TestCaseSource(typeof(SortStrategyTestData), nameof(SortStrategyTestData.GetRowMinSortData))]
    public void RowMinSort(ISortStrategy sort, ISwapStrategy swap, double[][] matrix, double[][] expected) {
        sort.Sort(ref matrix, swap);
        Utils.CompareMatrixItems(matrix, expected);
    }
}