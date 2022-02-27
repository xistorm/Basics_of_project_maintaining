using System;
using System.Linq;

namespace Solution;

public class Program {
    public delegate int Order(double a, double b);
    public delegate bool NeedSwap(double[] a, double[] b, Order order);
    public delegate void Sort(ref double[][] matrix, NeedSwap needSwap, Order order);

    public static int AscendingOrder(double a, double b) => a.CompareTo(b);
    public static int DescendingOrder(double a, double b) => b.CompareTo(a);

    public static bool RowSumNeedSwap(double[] a, double[] b, Order order) => order(a.Sum(), b.Sum()) == -1;
    public static bool RowMaxNeedSwap(double[] a, double[] b, Order order) => order(a.Max(), b.Max()) == -1;
    public static bool RowMinNeedSwap(double[] a, double[] b, Order order) => order(a.Min(), b.Min()) == -1;

    public static void BubbleSort(ref double[][] matrix, NeedSwap needSwap, Order order) {
        for (int i = 0; i < matrix.Length - 1; ++i) {
            for (int j = i + 1; j < matrix.Length; ++j) {
                if (needSwap(matrix[i], matrix[j], order)) {
                    SwapArrays(ref matrix[i], ref matrix[j]);
                }
            }
        }
    }

    public static void SwapArrays(ref double[] a, ref double[] b) {
        if (a.Length != b.Length) return;

        for (int i = 0; i < a.Length; ++i) {
            (a[i], b[i]) = (b[i], a[i]);
        }
    }

    public static void DisplayMatrix(double[][] matrix, string header = "") {
        if (header.Length > 0) Console.WriteLine(header);

        foreach (var row in matrix) {
            foreach (var item in row) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) {
        Sort sort = BubbleSort;
        double[][] matrix = new [] { new double[] {1, 2, 3}, new double[] {1, 0, 4}, new double[] {2, 0, 6} };

        DisplayMatrix(matrix, "Изначальная матрица");

        sort(ref matrix, RowSumNeedSwap, DescendingOrder);
        DisplayMatrix(matrix, "Сортировка по сумме элементов в строке по убыванию");
        
        sort(ref matrix, RowMaxNeedSwap, AscendingOrder);
        DisplayMatrix(matrix, "Сортировка по максимальному элементу в строке по возрастанию");

        sort(ref matrix, RowMinNeedSwap, AscendingOrder);
        DisplayMatrix(matrix, "Сортировка по минимальному элементу в строке в строке по возрастанию");
    }
}