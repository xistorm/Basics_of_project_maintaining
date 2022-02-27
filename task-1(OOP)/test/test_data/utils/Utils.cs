using NUnit.Framework;
using System.Linq;
using UserMatrix;

namespace Tests.UserUtils;

public static class Utils {
    public static void CompareMatrixItems(Matrix matrix, double[,] toCompare) {
        int rows = toCompare.GetLength(0);
        int columns = toCompare.GetLength(1);

        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < columns; ++j) {
                Assert.AreEqual(toCompare[i, j], matrix[i, j]);
            }
        }
    }

    public static void CompareMatrixItems(double[][] matrix, double[][] toCompare) {
        int rows = toCompare.Length;
        int columns = rows == 0 ? 0 : toCompare.Select(row => row.Length).Max();

        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < columns; ++j) {
                Assert.AreEqual(toCompare[i][j], matrix[i][j]);
            }
        }
    }
}