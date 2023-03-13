// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int InputInt (string msg) // ввод с консоли целого числа
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
    } while (!CheckMatrixParams(row, col));
    (int row, int col, int min, int max) result = (
        row,
        col,
        InputInt("Введите минимально допустимое значение матрицы"),    
        InputInt("Введите максимально допустимое значение матрицы")
    );
    return result;
}

int[,] GenerateMatrix((int rows, int cols, int min, int max) param) // заполнение матрицы случайными числами
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

void PrintMatrix(int[,] matrix) // вывод матрицы на экран
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j], 5} ");
        }
        Console.WriteLine();
    }
}

int[] SumMatrixRow(int[,] matrix) // суммируем значения строк матрицы
{
    int[] result = new int[matrix.GetLength(0)];
    for (int i = 0; i < result.Length; i++)
    {
        result[i] = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            result[i] += matrix[i, j];
        }
    }
    return result;
}

int FindMinIndexInArray(int[] array) // находим индекс с минимальным значением элемента массива
{
    int result = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[result] > array[i])
        {
            result = i;
        }        
    }
    return result;
}

(int rows, int columns, int minValue, int maxValue) matrixParams = SetMatrixParams();
int[,] matrix = new int[matrixParams.rows, matrixParams.columns];
int[] arrSum = new int[matrixParams.rows];
matrix = GenerateMatrix(matrixParams); // матрица
arrSum = SumMatrixRow(matrix); // массив с суммами строк
int rowWithMinSum = FindMinIndexInArray(arrSum); // индекс строки с минимальной суммой
Console.WriteLine("Исходная матрица");
PrintMatrix(matrix);
Console.WriteLine($"Строка №{rowWithMinSum + 1} матрицы имеет минимальную сумму {arrSum[rowWithMinSum]}");