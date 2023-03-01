using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LabOP_2Sem
{
    public class MainC
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Run();
        }

        private static void Run()
        {
            int input = GetInput();
            Console.Clear();
            int counter = 0;
            Console.Write("Введіть розмірність масиву: ");
            var checkInput = Console.ReadLine();
            uint size;
            if (!uint.TryParse(checkInput, out size))
            {
                Console.Write("Введіть будь-ласка корректне число (Від 0 to 4,294,967,295)");
            }
            int[] arr;
            if (input == 1)
            {
                arr = CreateRandArr(size);
            }
            else
            {
                arr = CreateArr(size);
            }
            ShowArr(arr);
            var arrToList = arr.ToList();
            while (FindFirstPair(arrToList))
            {
                counter++;
            }

            Console.Write($"\nКількість пар в масиві: {counter}");
        }

        private static void ShowArr(Array array)
        {
            foreach (var element in array)
            {
                Console.Write($"{element}\t");
            }
        }

        private static int[] CreateRandArr(uint size)
        {
            int[] arr = new int[size];
            var r = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i]= r.Next(-50, 50);
            }

            return arr;
        }

        private static int[] CreateArr(uint size)
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
        private static int GetInput()
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
        private static bool FindFirstPair(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = 0; j < nums.Count; j++)
                {
                    if (nums[j] == nums[i] && i != j)
                    {
                        var remove = nums[j];
                        nums.Remove(remove);
                        nums.Remove(remove);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}