/*
Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

/*
Алгоритм сортировки массива:
1. Запомни число с позицией n
2. Найди мин(макс) число в массиве
3. Поменяй числа из п.2 и п.1 местами
4. Перейди к следующей позиции.
5. Повтори п. 1-4.
*/

//Принимаем число на ввод
int GetNumber(string message) {
    bool isNumber = false;
    int Number = 0;
    while(!isNumber) {
        Console.Write(message);
        string input = Console.ReadLine();
        if(Int32.TryParse(input, out Number)) {
            isNumber = true;
        }
        else {
            Console.WriteLine("Вы ошиблись при вводе. Введите число.");
        }
    }
    return Number;
}

//создаём двумерный массив случайных целых чисел с заданным кол-вом элементов.
int [,] InitRandArray(int row, int col) {

    Random rnd = new Random();
    int [,] randArray = new int [row, col];
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            randArray[i,j] = rnd.Next(0,10);
        }     
    }
    return randArray;
}

//выводим значения массива
void PrintArray (int [,] array) {

    for (int row = 0; row < array.GetLength(0); row++) {
        for (int column = 0; column < array.GetLength(1); column++) {
            Console.Write($"{array[row, column]} ");
        }    
        Console.WriteLine();
    }
}

//сортируем строки массива по убыванию
void SortArrayRowsDesc(int [,] array) {
    for (int row = 0; row < array.GetLength(0); row++) {
        for (int col = 0; col < array.GetLength(1); col++) {
        int maxPos = col;
        for (int i = col + 1; i < array.GetLength(1); i++)
        {
            if (array[row,i] > array[row, maxPos]) maxPos = i;
        }
        int temp = array[row, col];
        array[row, col] = array[row, maxPos];
        array [row, maxPos] = temp;
        }
    }
}


int row = GetNumber("Сколько строк? ");
int col = GetNumber("Сколько столбцов?" );
int [,] userArray = InitRandArray(row, col);
Console.WriteLine("Неотсортированный массив:");
PrintArray(userArray);
SortArrayRowsDesc(userArray);
Console.WriteLine();
Console.WriteLine("Отсортированный массив:");
PrintArray(userArray);