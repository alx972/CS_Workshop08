// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

const string EMPTYSTR = ""; // вместо String.Empty для введения опционального параметра

int InputInt (string msg) // ввод с консоли целого числа
{
    Console.Write($"{msg} ->");
    int result;
    if (int.TryParse(Console.ReadLine(), out result))
    {
        return result;
    }
    Console.WriteLine("ОШИБКА: Введено не целочисленное значение.");
    Environment.Exit(1);
    return 0;
}

bool CheckMatrixParams(int row, int col) // проверка правильности размерности матрицы
{
    if (row > 0 && col > 0)
    {
        return true;
    }
    Console.WriteLine("ОШИБКА: Неверная размерность матрицы!");
    return false;
}

(int row, int col, int min, int max) SetMatrixParams(string msg = EMPTYSTR) // устанавливаем параметры матрицы
{
    int row, col;
    if (msg != EMPTYSTR) // вместо Empty.String, чтоб не ругался на отсутствие использования EMPTYSTR
    {
        Console.WriteLine();
        Console.WriteLine(msg);
    }
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

void PrintMatrix(int[,] matrix, string msg = EMPTYSTR) // вывод матрицы на экран
{
    if (msg != EMPTYSTR)
    {
        Console.WriteLine(msg);
    }
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j], 5} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

bool ValidMatrix(int row1, int col2) // проверка на валидность матриц
{
    if (row1 == col2) 
    {
        return true;
    } 
    return false;
}

int[,] MatrixMultiply(int[,] m1, int[,] m2) // перемножение матриц
{
    int[,] result = new int[m1.GetLength(0), m2.GetLength(1)];
    for (int r = 0; r < result.GetLength(0); r++) // перебор строк
    {
        for (int c = 0; c < result.GetLength(1); c++) // перебор столбцов
        {
            result[r, c] = 0;
            for (int m1c = 0; m1c < m1.GetLength(1); m1c++) // перебор столбцов 1й матрицы и строк 2й
            {
                result[r, c] += m1[r, m1c] * m2[m1c, c];
            }
        }
    }
    return result;
}

(int rows, int columns, int minValue, int maxValue) matrixPar1 = SetMatrixParams("Введите параметры первой матрицы");
(int rows, int columns, int minValue, int maxValue) matrixPar2 = SetMatrixParams("Введите параметры второй матрицы");
if (!ValidMatrix(matrixPar1.rows, matrixPar2.columns)) 
{
    Console.WriteLine("Матрицы не валидны. Произведение невозможно.");
    Environment.Exit(2); // Код выхода для скриптового использования
};
int[,] matrix1 = new int[matrixPar1.rows, matrixPar1.columns];
int[,] matrix2 = new int[matrixPar2.rows, matrixPar2.columns];
int[,] matrixMultiply = new int[matrixPar1.rows, matrixPar2.columns];
matrix1 = GenerateMatrix(matrixPar1); // матрица 1 
matrix2 = GenerateMatrix(matrixPar2); // матрица 2
matrixMultiply = MatrixMultiply(matrix1, matrix2);
PrintMatrix(matrix1, "Матрица 1");
PrintMatrix(matrix2, "Матрица 2");
PrintMatrix(matrixMultiply, "Произведение матриц");