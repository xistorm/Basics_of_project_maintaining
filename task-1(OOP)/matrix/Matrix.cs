using System;
using System.Linq;
using Strategies.SortStrategy;
using Strategies.SwapStrategy;
using Strategies.OrderStrategy;

namespace UserMatrix;

public class Matrix {
    private double[][] _data;

    public int Rows => _data.Length;
    public int Columns => Rows == 0 ? 0 : _data.Select(row => row.Length).Max();

    public double this[int i, int j] => _data[i][j];

    public Matrix() => _data = new double[0][] {};

    public Matrix(int size) => GetEmpty(size);

    public Matrix(int rows, int columns) => GetEmpty(rows, columns);

    public Matrix(double[][] initData) => _data = initData;

    public Matrix(double[,] initData) {
        int rows = initData.GetLength(0);
        int columns = initData.GetLength(1);

        _data = new double[rows][];
        for (int i = 0; i < rows; ++i) {
            _data[i] = new double[columns];
            for (int j = 0; j < columns; ++j) {
                _data[i][j] = initData[i, j];
            }
        }
    }

    public static Matrix GetEmpty(int size) => GetEmpty(size, size);

    public static Matrix GetEmpty(int rows, int columns) {
        rows = Math.Max(rows, 0);
        columns = Math.Max(columns, 0);

        double[][] initData = new double[rows][].Select(row => row = new double[columns].Select(item => item = 0).ToArray()).ToArray();
        return new Matrix(initData);
    }

    public override string ToString() => String.Join("\n", _data.Select(row => String.Join(" ", row)));

    public static bool TryParse(string input, out Matrix matrix) {
        try {
            double[][] initData = input.Split(", ").Select(row => row.Split(" ").Select(double.Parse).ToArray()).ToArray();
            int width = initData[0].Length;
            if (initData.Any(row => row.Length != width)) throw new InvalidDataException();
            matrix = new(initData);
            return true;
        } catch (Exception e) {
            matrix = new();
            return false;
        }
    }

    public void Sort(ISortStrategy sortStrategy) {
        sortStrategy.Sort(ref _data);
    }

    public void Sort(ISortStrategy sortStrategy, IOrderStrategy order) {
        sortStrategy.Sort(ref _data, order);
    }

    public void Sort(ISortStrategy sortStrategy, ISwapStrategy swap) {
        sortStrategy.Sort(ref _data, swap);
    }

    public void Sort(ISortStrategy sortStrategy, IOrderStrategy order, ISwapStrategy swap) {
        sortStrategy.Sort(ref _data, order, swap);
    }
}
