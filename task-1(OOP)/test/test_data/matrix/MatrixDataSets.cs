using System.Collections.Generic;
using System.Linq;
using Strategies.SwapStrategy;
using Strategies.SwapStrategy.Array;
using Strategies.SortStrategy;
using Strategies.SortStrategy.BubbleSort;

namespace Tests.DataSets;

public static class MatrixDataSets {
    public static readonly List<(int Rows, int Columns, double[,] InitData)> ConstructorsDataSets = new () {
        ( 2, 2, new double[,] { {1, 2}, {1, 2} } ),
        ( 3, 4, new double[,] { {1, 1, 1, 1}, {2, 2, 2, 2}, {3, 3, 3, 3} } ),
        ( 0, 3, new double[,] { } ),
        ( -1, -1, new double[,] { } ),
    };

    public static readonly List<(int Rows, int Columns, double[,] InitData)> FieldsDataSets = new () {
        ( 2, 2, new double[,] { {1, 2}, {1, 2} } ),
        ( 3, 4, new double[,] { {1, 1, 1, 1}, {2, 2, 2, 2}, {3, 3, 3, 3} } ),
        ( 0, 0, new double[,] { } ),
    };

    public static readonly List<(int Rows, int Columns, double[,] Expected)> EmptyDataSets = new () {
        ( 2, 2, new double[,] { {0, 0}, {0, 0} } ),
        ( 3, 3, new double[,] { {0, 0, 0}, {0, 0, 0}, {0, 0, 0} } ),
        ( 2, 4, new double[,] { {0, 0, 0, 0}, {0, 0, 0, 0} } ),
        ( -3, -1, new double[,] { } ),
    };

    public static readonly List<(double[,] InitData, string Expected)> ToStringDataSets = new () {
        ( new double [,] { {1, 2}, {1, 2} }, "1 2\n1 2" ),
        ( new double [,] { {1, 1, 1, 1}, {2, 2, 2, 2}, {3, 3, 3, 3} }, "1 1 1 1\n2 2 2 2\n3 3 3 3" ),
        ( new double [,] { {-1, 3}, {4, 0} }, "-1 3\n4 0" ),
    };

    public static readonly List<(string InitData, bool Success, double[,]? Expected)> TryParseDataSets = new () {
        ( "1 2, 1 2", true, new double [,] { {1, 2}, {1, 2} } ),
        ( "1 1 1 1, 2 2 2 2, 3 3 3 3", true, new double [,] { {1, 1, 1, 1}, {2, 2, 2, 2}, {3, 3, 3, 3} } ),
        ( "-1 3, 4", false, null ),
        ( "a 2, 3 b", false, null ),
    };

    public static readonly List<(ISortStrategy Sort, ISwapStrategy Swap, double[,] InitData, double[,] Expected)> SortDataSets = new () {
        (
            new LinearBubbleSort(),
            new LinearSwap(),
            new double[,]{ {1, 2}, {1, 3}, {1, 4} }, 
            new double[,]{ {1, 1}, {1, 2}, {3, 4} }
        ),
        (
            new RowBubbleSort(),
            new ArraySumSwap(),
            new double[,]{ {2, 3}, {2, 4}, {2, 3} }, 
            new double[,]{ {2, 3}, {2, 3}, {2, 4} }
        ),
        (
            new RowBubbleSort(), 
            new ArrayMaxSwap(),
            new double[,]{ {0, -2}, {-1, 1}, {2, 3} }, 
            new double[,]{ {0, -2}, {-1, 1}, {2, 3} }
        ),
        (
            new RowBubbleSort(),
            new ArrayMinSwap(),
            new double[,]{ {0, -2}, {-1, 1}, {2, 3} }, 
            new double[,]{ {0, -2}, {-1, 1}, {2, 3} }
        ),
    };
}