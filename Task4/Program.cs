/* Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
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

//создаём трёхмерный массив из неповторяющихся двузначных чисел с заданным кол-вом элементов.
int [,,] InitRandArray(int w, int h, int d) {
    int [,,] randArray = new int [w, h, d];
    Random rnd = new Random();
    for (int i = 0; i < w; i++) {
        for (int j = 0; j < h; j++) {
            for (int k = 0; k < d; k++) {
                int newNumber = 0;
                do {
                    newNumber = rnd.Next(10,99);
                    //Console.WriteLine($"Сгенерили номер {newNumber}, проверяем...");
                }
                while(CheckIfNumberExistsInArray(randArray, newNumber));
                randArray[i,j,k] = newNumber;
                //Console.WriteLine($"Номер {randArray[i,j,k]} записан в позицию: ({i}, {j}, {k})");
            }
        }      
    }
    return randArray;
}

//получаем уникальный номер массива
bool CheckIfNumberExistsInArray (int [,,] array, int number) {
    for (int w = 0; w < array.GetLength(0); w++) {
        for(int h = 0; h < array.GetLength(1); h++) {
            for (int d = 0; d < array.GetLength(2); d++) {
                //Console.WriteLine($"Смотрим позицию {w}, {h}, {d}");
                if (array[w, h, d] == number) {
                    //Console.WriteLine($"Номер {number} уже есть в позиции ({w}, {h}, {d})");
                    return true;
                }                    
            }
        }
    }
    //Console.WriteLine($"Номер {number} отсутствует в массиве.");
    return false;
}

//выводим значения массива
void PrintArray (int [,,] array) {
    for (int w = 0; w < array.GetLength(0); w++) {
        for (int h = 0; h < array.GetLength(1); h++) {
            for (int d = 0; d < array.GetLength(2); d++)
            {
                Console.Write($"{array[w, h, d]}({w},{h},{d}) ");
            } 
        Console.WriteLine();
        }    
    }
}


int w = GetNumber("Укажите ширину массива: ");
int h = GetNumber("Укажите высоту массива: ");
int d = GetNumber("Укажите глубину массива: ");
int [,,] rndArray = InitRandArray(w, h, d);
Console.WriteLine();
Console.WriteLine("Созданный массив с неповторяющимися числами:");
PrintArray(rndArray);