using System;
using System.Threading;

namespace LabOP_2Sem
{
    public static class UsefulFunctions
    {
        public static int[] CreateRandArr(uint size)
        {
            int[] arr = new int[size];
            var r = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i]= r.Next(-50, 50);
            }

            return arr;
        }
        
        
        public static int[] CreateArr(uint size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Clear();
                Console.Write("Додайте елемент, можливі значення (-2,147,483,648 до 2,147,483,647)");
                var checkInput = Console.ReadLine();
                int element;
                while(true)
                    if (int.TryParse(checkInput, out element))
                    {
                        arr[i] = element;
                        break;
                    }
                    else
                    {
                        Console.Write("Введіть будь-ласка число від -2,147,483,648 до 2,147,483,647");
                    }
            }

            return arr;
        }
        
        
        public static int GetInput()
        {
            Console.Clear();
            Console.Write("Оберіть цифру, залежно від того, як хочете заповнити масив: \n" +
                          "1: Автоматичне заповнення\n" +
                          "2: Заповнення вручну");
            while (true)
            {
                int[] cursor = { Console.CursorLeft, Console.CursorTop };
                Console.CursorVisible = false;
                Console.SetCursorPosition(cursor[0], cursor[1]);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.D2) return 2;
                    if (key == ConsoleKey.D1) return 1;
                    Console.Write("Можна обрати лише 1 або 2");
                    Thread.Sleep(1500);
                }
            }
        }
        
        public static void ShowArr(Array array)
        {
            foreach (var element in array)
            {
                Console.Write($"{element}\t");
            }
        }
    }
}