using NUnit.Framework;
using UserMatrix;
using Strategies.SortStrategy;
using Strategies.SwapStrategy;
using Tests.Data;
using Tests.UserUtils;

namespace Tests;

[TestFixture]
public class MatrixTests {

    [Test]
    [Category("Constructors")]
    public void EmptyConstructor() {
        Matrix matrix = new ();
        Assert.IsNotNull(matrix);
    }

    [Test]
    [Category("Constructors")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetSizeConstructorsData))]
    public void SizeConstructor(int size) {
        Matrix matrix = new (size);
        Assert.IsNotNull(matrix);
    }

    [Test]
    [Category("Constructors")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetDimentionsConstructorsData))]
    public void DimentionsConstructor(int rows, int columns) {
        Matrix matrix = new (rows, columns);
        Assert.IsNotNull(matrix);
    }

    [Test]
    [Category("Constructors")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetInitDataConstructorsData))]
    public void IntiDataConstructor(double[,] initData) {
        Matrix matrix = new (initData);
        Assert.IsNotNull(matrix);
    }

    [Test]
    [Category("Fields")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetFieldsData))]
    public void Fileds(int rows, int columns, double[,] initData) {
        Matrix matrix = new (initData);

        Assert.AreEqual(rows, matrix.Rows);
        Assert.AreEqual(columns, matrix.Columns);

        Utils.CompareMatrixItems(matrix, initData);
    }

    [Test]
    [Category("Methods")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetSizeEmptyData))]
    public void SizeGetEmpty(int size, double[,] expected) {
        Matrix matrix = Matrix.GetEmpty(size);

        Utils.CompareMatrixItems(matrix, expected);
    }

    [Test]
    [Category("Methods")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetDimentionsEmptyData))]
    public void DimentionsGetEmpty(int rows, int columns, double[,] expected) {
        Matrix matrix = Matrix.GetEmpty(rows, columns);

        Utils.CompareMatrixItems(matrix, expected);
    }

    [Test]
    [Category("Methods")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetToStringData))]
    public void ToString(double[,] initData, string expected) {
        Matrix matrix = new (initData);

        Assert.AreEqual(matrix.ToString(), expected);
    }

    [Test]
    [Category("Methods")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetTryParseData))]
    public void TryParse(string initData, bool success, double[,]? expected) {
        Matrix matrix;
        bool parsed = Matrix.TryParse(initData, out matrix);

        Assert.AreEqual(success, parsed);
        if (parsed) {
            Utils.CompareMatrixItems(matrix, expected);
        }
    }

    [Test]
    [Category("Methods")]
    [TestCaseSource(typeof(MatrixTestData), nameof(MatrixTestData.GetSortData))]
    public void Sort(ISortStrategy sort, ISwapStrategy swap, double[,] initData, double[,] expected) {
        Matrix matrix = new (initData);
        matrix.Sort(sort, swap);
        Utils.CompareMatrixItems(matrix, expected);
    }
}