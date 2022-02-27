using System.Collections.Generic;
using Strategies.SwapStrategy;
using Strategies.SwapStrategy.Array;
using Strategies.SortStrategy;
using Strategies.SortStrategy.BubbleSort;

namespace Tests.DataSets;

public static class SortStrategyDataSets {
    public static readonly List<(ISortStrategy Sort, ISwapStrategy Swap, double[][] Matrix, double[][] Expected)> LinearSortDataSets = new () {
        (
            new LinearBubbleSort(), 
            new LinearSwap(),
            new []{ new double[] {1, 2}, new double[] {1, 3}, new double[] {1, 4} }, 
            new []{ new double[] {1, 1}, new double[] {1, 2}, new double[] {3, 4} }
        ),
        (
            new LinearBubbleSort(),
            new LinearSwap(),
            new []{ new double[] {4, 3}, new double[] {2, 1}, new double[] {2, 3} }, 
            new []{ new double[] {1, 2}, new double[] {2, 3}, new double[] {3, 4} }
        ),
        (
            new LinearBubbleSort(),
            new LinearSwap(),
            new []{ new double[] {0, -2}, new double[] {-1, 0}, new double[] {2, 1} }, 
            new []{ new double[] {-2, -1}, new double[] {0, 0}, new double[] {1, 2}, }
        ),
    };

    public static readonly List<(ISortStrategy Sort, ISwapStrategy Swap, double[][] Matrix, double[][] Expected)> RowSumSortDataSets = new () {
        (
            new RowBubbleSort(),
            new ArraySumSwap(),
            new []{ new double[] {1, 2}, new double[] {2, 3}, new double[] {2, 3} }, 
            new []{ new double[] {1, 2}, new double[] {2, 3}, new double[] {2, 3} }
        ),
        (
            new RowBubbleSort(),
            new ArraySumSwap(),
            new []{ new double[] {2, 3}, new double[] {2, 4}, new double[] {2, 3} }, 
            new []{ new double[] {2, 3}, new double[] {2, 3}, new double[] {2, 4} }
        ),
        (
            new RowBubbleSort(),
            new ArraySumSwap(),
            new []{ new double[] {2, 3}, new double[] {4, 3}, new double[] {2, 1} }, 
            new []{ new double[] {2, 1}, new double[] {2, 3}, new double[] {4, 3} }
        ),
    };

    public static readonly List<(ISortStrategy Sort, ISwapStrategy Swap, double[][] Matrix, double[][] Expected)> RowMaxSortDataSets = new () {
        (
            new RowBubbleSort(),
            new ArrayMaxSwap(),
            new []{ new double[] {1, 2}, new double[] {1, 3}, new double[] {2, 3} }, 
            new []{ new double[] {1, 2}, new double[] {1, 3}, new double[] {2, 3} }
        ),
        (
            new RowBubbleSort(),
            new ArrayMaxSwap(), 
            new []{ new double[] {4, 3}, new double[] {2, 1}, new double[] {2, 3} }, 
            new []{ new double[] {2, 1}, new double[] {2, 3}, new double[] {4, 3} }
        ),
        (
            new RowBubbleSort(),
            new ArrayMaxSwap(), 
            new []{ new double[] {0, -2}, new double[] {-1, 1}, new double[] {2, 3} }, 
            new []{ new double[] {0, -2}, new double[] {-1, 1}, new double[] {2, 3} }
        ),
    };

    public static readonly List<(ISortStrategy Sort, ISwapStrategy Swap, double[][] Matrix, double[][] Expected)> RowMinSortDataSets = new () {
        (
            new RowBubbleSort(),
            new ArrayMinSwap(),
            new []{ new double[] {1, 2}, new double[] {1, 3}, new double[] {2, 3} }, 
            new []{ new double[] {1, 2}, new double[] {1, 3}, new double[] {2, 3} }
        ),
        (
            new RowBubbleSort(),
            new ArrayMinSwap(),
            new []{ new double[] {4, 3}, new double[] {2, 1}, new double[] {2, 3} }, 
            new []{ new double[] {2, 1}, new double[] {2, 3}, new double[] {4, 3} }
        ),
        (
            new RowBubbleSort(),
            new ArrayMinSwap(),
            new []{ new double[] {0, -2}, new double[] {-1, 1}, new double[] {2, 3} }, 
            new []{ new double[] {0, -2}, new double[] {-1, 1}, new double[] {2, 3} }
        ),
    };
}