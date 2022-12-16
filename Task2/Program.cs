/*
Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку
с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки
с наименьшей суммой элементов: 1 строка
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

//вывод строки с наименьшей суммой элементов
void FindLowSumLine (int [,] array) {
    int [] sumLineArray = new int [array.GetLength(0)];
    for (int row = 0; row < array.GetLength(0); row++) {
        int sumLine = 0;
        for (int col = 0; col < array.GetLength(1); col++) {
            sumLine += array[row, col];
        }
        Console.WriteLine($"Сумма строки {row + 1}: {sumLine}");
        sumLineArray[row] = sumLine;
    }

    int sumLineMin = 0;
    for (int i = 0; i < sumLineArray.Length; i++) {
        if (sumLineArray[i] < sumLineArray[sumLineMin]) sumLineMin = i;
    }
    Console.WriteLine($"Номер строки с наименьшей суммой элементов: {sumLineMin + 1}");
}

int row = GetNumber("Сколько строк? ");
int col = GetNumber("Сколько столбцов?" );
int [,] userArray = InitRandArray(row, col);
Console.WriteLine("Заданный массив:");
PrintArray(userArray);
FindLowSumLine(userArray);
