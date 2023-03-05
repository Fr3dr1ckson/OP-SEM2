using System;
using System.Collections.Generic;
using System.Linq;
using static LabOP_2Sem.UsefulFunctions;

namespace LabOP_2Sem
{
    public class Task1
    {
        public static void Run()
        {
            int input = GetInput();
            Console.Clear();
            int counter = 0;
            
            Console.Write("Введіть розмірність масиву: ");
            var checkInput = Console.ReadLine();
            
            if (!uint.TryParse(checkInput, out uint size))
            {
                Console.Write("Введіть будь-ласка корректне число (Від 0 to 4,294,967,295)");
            }
            
            int[] arr = input == 1 ? CreateRandArr(size) : CreateArr(size);
            ShowArr(arr);
            
            var arrToList = arr.ToList();
            int counterV2 = QuantityOfPairs(arrToList);
            
            
            while (FindFirstPair(arrToList))
            {
                counter++;
            }


            Console.Write($"\nКількість пар в масиві: {counter}");
            Console.Write($"\nКількість пар в масиві: {counterV2}");
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

        private static int QuantityOfPairs(List<int> nums)
        {
            int numberOfPairs = 0;
            for (int i = 0; i < nums.Count-1; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        numberOfPairs++;
                        Console.Write($"\n{nums[i]} == {nums[j]}");
                    }
                }
            }
            return numberOfPairs;
        }
    } 
}
