using System;

class Program
{
    static void Main(string[] args)
    {
        // Установка кодировки для корректного отображения кириллицы
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // Ввод размеров матрицы
        Console.Write("Введите количество строк (m): ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов (n): ");
        int n = int.Parse(Console.ReadLine());

        double[,] matrix = new double[m, n];
        
        Console.WriteLine("\nВведите элементы матрицы:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"элемент [{i},{j}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(matrix, m, n);


        for (int i = 0; i < m; i++)
        {
            double sum = 0;

            for (int j = 0; j < n; j++)
            {
                sum += matrix[i, j];
            }

            double average = sum / n;

            for (int j = 0; j < n - 1; j++)
            {
                matrix[i, j] -= average;
            }
        }

        // Вывод измененной матрицы
        Console.WriteLine("\nРезультат (после вычитания среднего арифметического, кроме последнего элемента в строке):");
        PrintMatrix(matrix, m, n);
    }
    
    static void PrintMatrix(double[,] matrix, int m, int n)
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],8:F2} ");
            }
            Console.WriteLine();
        }
    }
}