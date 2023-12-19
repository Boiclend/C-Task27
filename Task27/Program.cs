// Разработать функцию обнуления столбца в двумерном массиве. Обнулить 3 столбца. 
// Результат вывести на печать. Согласно условию задачи, какие именно столбцы необходимо обнулить — не оговаривается.
// Например, в существующем решении этой задачи, обнуляются первые три четных столбца. Пример работы программы смотрим ниже:


int Message(string text) { 
    Console.WriteLine(text);
    int num = int.Parse(Console.ReadLine());
    return num;
}

int[,] FillArray(int r, int c) // заполнение матрицы
{
    Random rnd = new Random();
    int[,] arr = new int[r,c];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i,j] = rnd.Next(-1,9);
        }
    }
    return arr;
}

void PrintArray(int[,] arr) { // печать матрицы
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,3}", arr[i, j])); // красивый вывод матрицы
        }
        Console.WriteLine();
    }
}

int[,] ZeroingColumns(int[,] arr, int[] zero) 
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if(zero.Length == arr.GetLength(1)) 
            {
                arr[i,j] = 0;
            }
            if(zero.Contains(j)) 
            {
                arr[i,j] = 0;
            }
        }
    }
    return arr;

}

int rows = Message("Введите количество строк");
int columns = Message("Введите количество столбцов");
int[,] DoubleArr = FillArray(rows,columns);
PrintArray(DoubleArr);

int size =  Message("Сколько столбцов вы хотите обнулить?:");
int[] zeroing = new int[size];
if(zeroing.Length == DoubleArr.GetLength(1)) {
    DoubleArr = ZeroingColumns(DoubleArr,zeroing);
    PrintArray(DoubleArr);
    return;
}
for (int i = 0; i < zeroing.Length; i++)
{
    Console.WriteLine($"Введите {i + 1} номер столбца для обнуления : ");
    zeroing[i] = int.Parse(Console.ReadLine());
    zeroing[i] = zeroing[i] - 1;
}

DoubleArr = ZeroingColumns(DoubleArr,zeroing);
Console.WriteLine();
PrintArray(DoubleArr);