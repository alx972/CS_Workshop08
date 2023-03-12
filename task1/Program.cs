// Задайте двумерный массив. Напишите программу, которая упорядочивает по убыванию элементы каждой строки двумерного массива.

int InputInt (string msg)
{
    Console.Write($"{msg} ->");
    int result;
    if (int.TryParse(Console.ReadLine(), out result))
    {
        return result;
    }
    System.Console.WriteLine("ОШИБКА: Введено не целочисленное значение.");
    Environment.Exit(1);
    return 0;
}

bool CheckMatrixParams(int row, int col) // проверка правильности размерности матрицы
{
    if (row > 0 && col > 0)
    {
        return true;
    }
    System.Console.WriteLine("ОШИБКА: Неверная размерность матрицы!");
    return false;
}

(int row, int col, int min, int max) SetMatrixParams() // устанавливаем параметры матрицы
{
    int row, col;
    do
    {
        row = InputInt("Введите количество строк в матрице");
        col = InputInt("Введите количество столбцов в матрице");
    } while (CheckMatrixParams(row, col));
    (int row, int col, int min, int max) result = (
        row,
        col,
        InputInt("Введите минимально допустимое значение матрицы"),    
        InputInt("Введите максимально допустимое значение матрицы")
    );
    return result;
}

int[,] GenerateMatrix((int rows, int cols, int min, int max) param)
{
    int[,] result = new int[param.rows, param.cols];
    Random rnd = new Random();
    for (int i = 0; i < param.rows; i++)
    {
        for (int j = 0; j < param.cols; j++)
        {
            result[i, j] = rnd.Next(param.min, param.max);
        }
    }
    return result;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; i < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j], 5} ");
        }
        Console.WriteLine();
    }
}

(int rows, int columns, int minValue, int maxValue) matrixParams = SetMatrixParams();
int[,] matrix = new int[matrixParams.rows, matrixParams.columns];
matrix = GenerateMatrix(matrixParams);
PrintMatrix(matrix);