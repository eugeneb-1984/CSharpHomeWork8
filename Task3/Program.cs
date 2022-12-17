/*
Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

/* Алгоритм перемножения:
1. Сформируй строку матрицы 1. int [] Row
2. Сформируй столбец матрицы 2. int [] Col
3. Перемножь сформированное: resultElement = Row[i]*Col[i]
4. Запиши результат: resultMatrix[i,j] = resultElement
5. Повтори 1-4 для оставшихся строк и столбцов.
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

//создаём матрицу случайных целых чисел с заданным кол-вом элементов.
int [,] InitMatrix(int row, int col) {

    Random rnd = new Random();
    int [,] matrix = new int [row, col];
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            matrix[i,j] = rnd.Next(0,10);
        }     
    }
    return matrix;
}

//проверяем согласованность матриц
bool CheckMatrixAlignment (int [,] matr1, int [,] matr2) {
    int matr1col = matr1.GetLength(1);
    int matr2row = matr2.GetLength(0);

    if (matr1col == matr2row) return true;
    else return false;
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

//перемножаем две матрицы
int [,] MultiplyMatrix (int [,] matr1, int[,] matr2) {
    int [,] resultMatrix = new int [matr1.GetLength(0), matr2.GetLength(1)];
    for (int i = 0; i < matr1.GetLength(0); i++) {
        int [] row = GetRow(matr1, i);
        for (int j = 0; j < matr2.GetLength(1); j++) {
            int [] col = GetCol(matr2, j);
            resultMatrix[i,j] = MultiplyLines(row, col);
        }
    }
    return resultMatrix;
}

//Сформируй строку матрицы
int [] GetRow (int[,] matr, int rowNumber) {
    if (rowNumber  >= matr.GetLength(0)) {
        Console.WriteLine($"Ошибка: в этой матрице нет ряда c номером {rowNumber}");
        return null;
    }
    else {
        int [] row = new int [matr.GetLength(1)];
        // Console.WriteLine();
        for (int i = 0; i < matr.GetLength(1); i++) {
            row [i] = matr[rowNumber,i];
            // Console.Write(row [i] + " ");
        }
        return row;
    }
} 

//Сформируй столбец матрицы
int [] GetCol (int[,] matr, int colNumber) {
    if (colNumber  >= matr.GetLength(1)) {
        Console.WriteLine($"Ошибка: в этой матрице нет столбца с номером {colNumber}");
        return null;
    }
    else {
        int [] column = new int [matr.GetLength(0)];
        // Console.WriteLine();
        for (int i = 0; i < matr.GetLength(0); i++) {
            column [i] = matr[i,colNumber];
            // Console.Write(column [i] + " ");
        }
        return column;
    }
} 

//Перемножь сформированное
int MultiplyLines(int [] row, int [] col) {
    int result = 0;
    for (int i = 0; i < row.Length; i++) {
        result += row[i]*col[i];
    }
    return result;
}

// Задаём матрицы:
Random rnd = new Random();
int col1 = GetNumber("Сколько столбцов нужно в матрице 1? ");
int row2 = GetNumber("Сколько строк нужно в матрице 2? ");
int [,] matrix1 = InitMatrix(rnd.Next(2,5), col1); 
int [,] matrix2 = InitMatrix(row2, rnd.Next(2,5));

// Печатаем заданные матрицы:a
Console.WriteLine("Матрица 1:");
PrintArray(matrix1);
Console.WriteLine();
Console.WriteLine("Матрица 2:");
PrintArray(matrix2);

// Проверяем согласованность матриц, если ОК, то перемножаем:
if (CheckMatrixAlignment(matrix1, matrix2)) {
    int [,] resultMatrix = MultiplyMatrix(matrix1, matrix2);
    Console.WriteLine();
    Console.WriteLine("Произведение матриц:");
    PrintArray(resultMatrix);
}
else {
    Console.WriteLine("Матрицы не согласованы, перемножение невозможно");
}