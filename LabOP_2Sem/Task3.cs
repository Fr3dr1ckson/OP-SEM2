using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static LabOP_2Sem.UsefulFunctions;

namespace LabOP_2Sem
{
    public class Task3 : ITask
    {
        public void Run()
        {
            int input = GetInput();
            var searchChar = GetSearchParam();
            uint size = 0;
            var strings = input == 1 ? GenerateDictionary(searchChar) : CreateDictionary();
            ShowCollection(strings);
            Console.Write($"\nКількість слів, які починаються і закінчуються на букву {searchChar}: " +
                          StartAndEndsWithQuantity(searchChar, strings));
        }

        private static ICollection<string> GenerateDictionary(char c)
        {
            var dictionary = new List<string>
            { 
                $"{c}1234{c}",
                "abcdef",
                "boat",
                "float",
                "danger",
                "interface",
                "c minor",
                "random",
                "FICE",
                "glasses",
                "sheep",
                "train",
                $"{c}432"
            };
            
            return dictionary;
        }

        private static ICollection<string> CreateDictionary()
        {
            uint size;
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
            var dictionary = new List<string>();
            for (int i = 1; i < size + 1; i++)
            {
                Console.Clear();
                Console.Write("Введіть слово: ");
                dictionary.Add(Console.ReadLine());
            }

            return dictionary;
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

        private static char GetSearchParam()
        {
            Console.Clear();
            Console.Write("Введіть символ, по якому буде здійснюватись пошук: ");
            while (true)
            {
                int[] cursor = { Console.CursorLeft, Console.CursorTop };
                Console.CursorVisible = false;
                Console.SetCursorPosition(cursor[0], cursor[1]);
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadLine();
                    if (input != null && input.Length < 2) return input[0];
                    Console.Write("Введіть будь-ласка лише 1 символ");
                    Thread.Sleep(1500);
                }
            }
        }
        private int StartAndEndsWithQuantity(char c, ICollection<string> collection)
        {
            var search = (from word in collection
                where word.First() == word.Last() && word.First() == c
                select word).Count();
            return search;
        }
    }
}