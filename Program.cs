using System;

class Program
{
    static void Main(string[] args)
    {
        // Установка кодировки для корректного отображения кириллицы
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int m, n;

        // Ввод размеров матрицы с защитой от ошибок ввода
        Console.Write("Введите количество строк (m): ");
        while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
        {
            Console.Write("Ошибка. Введите положительное целое число для количества строк: ");
        }

        Console.Write("Введите количество столбцов (n): ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Ошибка. Введите положительное целое число для количества столбцов: ");
        }

        double[,] matrix = new double[m, n];

        Console.WriteLine("\nВведите элементы матрицы:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Элемент [{i},{j}]: ");
                while (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                {
                    Console.Write($"Ошибка. Введите число для элемента [{i},{j}]: ");
                }
            }
        }

        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(matrix, m, n);

        // Обработка строк матрицы
        for (int i = 0; i < m; i++)
        {
            double sum = 0;

            for (int j = 0; j < n; j++)
            {
                sum += matrix[i, j];
            }

            double average = sum / n;

            // Вычитание среднего арифметического из всех элементов строки, кроме последнего
            for (int j = 0; j < n - 1; j++)
            {
                matrix[i, j] -= average;
            }
        }

        // Вывод измененной матрицы
        Console.WriteLine("\nРезультат (после вычитания среднего арифметического, кроме последнего элемента в строке):");
        PrintMatrix(matrix, m, n);
    }

    // Вспомогательный метод для красивого вывода матрицы
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
