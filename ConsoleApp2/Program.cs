using System;
using System.Numerics;

public class Matrix
{
    int x;
    int y;
    string name;
    public static int Matrixcount = 0;
    private double[,] elements;

    public Matrix(int in_x, int in_y)
    {
        x = in_x;
        y = in_y;
        string s;
        elements = new double[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Console.Write($"a[{i},{j}] = ");
                s = Console.ReadLine();
                int.TryParse(s, out int number);
                elements[i, j] = number;
            }
        }
        Matrixcount++;
        name = $"Матрица {Matrixcount}";
    }
    public Matrix(int n, Matrix m)
    {
        x = m.x;
        y = m.y;
        elements = new double[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                elements[i,j] = m.elements[i, j] + n;
            }
        }
        Matrixcount++;
        name = $"Матрица {Matrixcount}";
    }
    public void PrintMatrix()
    {
        int columnWidth = 8; // Задаем ширину столбцов
        Console.Write(name);
        Console.WriteLine();
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                string formattedValue = elements[i, j].ToString(); // Форматируем значение
                Console.Write(formattedValue.PadLeft(columnWidth)); // Выводим с выравниванием по ширине
            }
            Console.WriteLine(); // Переход на новую строку для следующей строки матрицы
        }
        Console.WriteLine();
    }
    double calculateAverage()
    {
        double sum = 0.0;
        for (int i = 0; i<x; i++) {
            for (int j = 0; j<y; j++) {
                sum += elements[i,j];
            }
        }

        return sum / (x * y);
    }
    ~Matrix()
    {
        Console.WriteLine($"Уничтожен объект матрица {Matrixcount})");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Matrix m1 = new Matrix(2, 2);
        Matrix m2 = new Matrix(8, m1);
        m1.PrintMatrix();
        m2.PrintMatrix();
        Console.ReadLine();
    }
}