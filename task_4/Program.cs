using System;
using System.Collections.Generic;
using System.Linq;

namespace task_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string inputData = Console.ReadLine();
            string[] inputDataArr = inputData.Split(' ');
            int amountOfNumbers = int.Parse(inputDataArr[0]);
            int amountOfAvailableChanges = int.Parse(inputDataArr[1]);
            
            string inputNumbers = Console.ReadLine();
            int[] numbers = Array.ConvertAll(inputNumbers.Split(' '),input => int.Parse(input));
            Array.Sort(numbers);

            Dictionary<int, List<int>> numbersByRank = new Dictionary<int, List<int>>();
            int currentNumberOfRank = 0;
            int deviderForRank = 10;

            //devide numbers on ranks
            foreach (var value in numbers)
            {
                while (value / deviderForRank >= 1)
                {
                    deviderForRank *= 10;
                    currentNumberOfRank += 1;
                }

                try
                {
                    numbersByRank[currentNumberOfRank]?.Add(value);
                }
                
                catch (KeyNotFoundException e)
                {
                    var addList = new List<int>();
                    numbersByRank.Add(currentNumberOfRank, addList);
                    numbersByRank[currentNumberOfRank].Add(value);
                }

            }

            //TODO: add logic with replacement
            for (int i = currentNumberOfRank; i < 0; i--)
            {
                
            }
        }
    }
}