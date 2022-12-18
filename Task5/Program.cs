/*
Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

//выводим значения массива
void PrintArray (string [,] array) {

    for (int row = 0; row < array.GetLength(0); row++) {
        for (int column = 0; column < array.GetLength(1); column++) {
            Console.Write($"{array[row, column]} ");
        }    
        Console.WriteLine();
    }
}

//заполняем массив по спирали
void FillArraySpiral(string [,] array) {
    int rowLen = array.GetLength(0);
    int colLen = array.GetLength(1);
    int fillValue = 1;
    int i = 0;
    int j = 0;
    
    int rowBeg = 0;
    int rowEnd = 0;
    int colBeg = 0;
    int colEnd = 0;

    for (int cellNum = 0; cellNum < rowLen*colLen; cellNum++) {
        array[i,j] = fillValue.ToString("D2");
        if (i == rowBeg && j < rowLen - colEnd - 1)
            j++;
        else if (j == rowLen - colEnd - 1 && i < colLen - rowEnd - 1)
            i++;
        else if (i == colLen - rowEnd - 1 && j > colBeg)
            j--;
        else
            i--;

        if ((i == rowBeg + 1) && (j == colBeg) && (colBeg != rowLen - colEnd - 1)){
            rowBeg++;
            rowEnd++;
            colBeg++;
            colEnd++;
        }
        fillValue++;
    }
}

string [,] arraySpiral = new string [4,4];
FillArraySpiral(arraySpiral);
PrintArray(arraySpiral);