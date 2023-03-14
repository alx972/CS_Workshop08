// Напишите программу, которая заполнит спирально квадратный массив. 

int len = 0;
int value = 1; // заполняющее инкрементное значение матрицы
int x=0; // отступ от внешнего края матрицы

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

bool CheckMatrixParams(int len) // проверка правильности размерности матрицы
{
    if (len > 0)
    {
        return true;
    }
    System.Console.WriteLine("ОШИБКА: Неверная размерность матрицы!");
    return false;
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
    Console.WriteLine();
}


void FillRing(int[,] matrix, int x) // заполняем матрицу кольцом
{
    int len = matrix.GetLength(0);
    for (int i = x; i < len-x-1; i++) // >>>>
    {
        matrix[x,i] = value++;
    }

    for (int i = x; i < len-x-1; i++) // vvvv
    {
        matrix[i,len-x-1] = value++;
    }

    for (int i=len-x-1; i > x; i--) // <<<<
    {
        matrix[len-x-1,i] = value++;
    }

    for (int i=len-x-1; i > x; i--) // ^^^^
    {
        matrix[i, x] = value++;
    }
}

void FillCenter(int[,] matrix, int midEdge) // заполняем центр матрицы, если число элементов ребра нечетное 
{
    int len = matrix.GetLength(0);
    if (len % 2 == 1) 
    {
        matrix[midEdge, midEdge] = value;
    }
}

do
{
    len = InputInt("Введите размерность квадратной матрицы");
} while (!CheckMatrixParams(len));
int[,] matrix = new int[len,len];
int halfEdge = len / 2; // половина длины ребра матрицы
for (x=0; x < halfEdge; x++)
{
    FillRing(matrix, x);
}
FillCenter(matrix, halfEdge);

PrintMatrix(matrix);