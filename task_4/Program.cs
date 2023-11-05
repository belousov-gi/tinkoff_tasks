using System;
using System.Collections.Generic;


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
            long maxSubstraction = 0;
            
            string inputNumbers = Console.ReadLine();
            int[] numbers = Array.ConvertAll(inputNumbers.Split(' '),input => int.Parse(input));
            Array.Sort(numbers);

            Dictionary<int, List<int>> numbersByRank = new Dictionary<int, List<int>>();
            int currentNumberOfRank = 0;
            long deviderForRank = 10;

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
                    if (!numbersByRank.ContainsKey(currentNumberOfRank))
                    {
                        var addList = new List<int>();
                        numbersByRank.Add(currentNumberOfRank, addList);
                    }
                    numbersByRank[currentNumberOfRank].Add(value);
                }
                

                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            int currentSubstraction;
            for (; currentNumberOfRank >= 0 && amountOfAvailableChanges > 0; currentNumberOfRank--)
            {
                List<int> currentRankList = numbersByRank[currentNumberOfRank];
                int tempDevider = (int)Math.Pow(10, currentNumberOfRank);
                // int tempNumberForSubstr = Int32.Parse(CreateNumberForSubtraction(currentNumberOfRank));

                for (int j = 0, maxIndex = currentRankList.Count - 1;
                     j <= maxIndex && amountOfAvailableChanges > 0;
                     j++ )
                {
                    int numberOfMaxRankInValue = currentRankList[j] / tempDevider;
                    
                    currentRankList[j] -= numberOfMaxRankInValue * tempDevider;
                    
                    if (numberOfMaxRankInValue == 9) { continue; }

                    amountOfAvailableChanges--;
                    currentSubstraction = (9 - numberOfMaxRankInValue) * tempDevider;
                    maxSubstraction += currentSubstraction;
                    
                }
                
                //Add elements to list with less rank for future comparing
                if (numbersByRank.ContainsKey(currentNumberOfRank - 1))
                {
                    numbersByRank[currentNumberOfRank - 1].AddRange(numbersByRank[currentNumberOfRank]);
                    numbersByRank[currentNumberOfRank - 1].Sort();
                    
                }
                else
                {
                    numbersByRank.Remove(currentNumberOfRank);
                    currentRankList.Sort();
                    numbersByRank[currentNumberOfRank - 1] = currentRankList;
                }
            }
            
            Console.WriteLine(maxSubstraction);
        }

    }
}