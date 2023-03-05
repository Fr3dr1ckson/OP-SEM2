using System;
using System.Collections.Generic;
using System.Linq;
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

        public static Dictionary<string, int> SortDictionaryByValue(IDictionary<string,int> dictionary)
        {
            return dictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
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
        
        
        public static void ShowArr(Array array)
        {
            foreach (var element in array)
            {
                Console.Write($"{element}\t");
            }
        }
    }
}