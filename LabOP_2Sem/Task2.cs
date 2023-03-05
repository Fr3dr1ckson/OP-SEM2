using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text.Json;
using static LabOP_2Sem.UsefulFunctions;

namespace LabOP_2Sem
{
    public class Task2 : ITask
    {
        private static readonly string path = @"C:\Users\onarg\RiderProjects\LabOP_2Sem\LabOP_2Sem\json\dictionary.json";
        public void Run()
        {
            int input = GetInput();
            uint size = 0;
            while (true)
            {
                Console.Clear();
                Console.Write("Введіть довжину словника: ");
                if (uint.TryParse(Console.ReadLine(), out size))
                {
                    break;
                }
                Console.Write("Введть валідний розмір словника. Допустимі значення: ");
                Thread.Sleep(1200);
            }

            IDictionary<string,int> dictionary = input == 1 ? GenerateDictionary(size) : CreateDictionary(size);
            dictionary = SortDictionaryByValue(dictionary);
            ToJson(dictionary);
            Console.Write("Success");
        }


        private static async void ToJson(IDictionary<string,int> dictionary)
        {
            using FileStream fs = new FileStream(path,FileMode.Create);
            await JsonSerializer.SerializeAsync(fs,dictionary);
        }
        private static int GetInput()
        {
            Console.Clear();
            Console.Write("Оберіть цифру, залежно від того, як хочете заповнити словник: \n" +
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

        private static Dictionary<string, int> GenerateDictionary(uint size)
        {
            var dictionary = new Dictionary<string, int>();
            var r = new Random();
            for (int i = 1; i < size+1; i++)
            {
                dictionary.Add($"{i}", r.Next(0,40));
            }
            return dictionary;
        }

        private static Dictionary<string, int> CreateDictionary(uint size)
        {
            var dictionary = new Dictionary<string, int>();
            for (int i = 1; i < size + 1; i++)
            {
                if(int.TryParse(Console.ReadLine(), out int value)) dictionary.Add($"{i}",value);
                else
                {
                    Console.Write("Введено не валідне число");
                    i--;
                }
            }

            return dictionary;
        }
        private static Dictionary<string, int> MultiplyDicValues(Dictionary<string, int> dictionary)
        {
            for (int i = 0; i < dictionary.Count; i++)
            {
                var r = new Random();
                dictionary[$"{i}"] *= r.Next(-40, 40);
            }

            return dictionary;
        }
    }
}