using System;

namespace task_5
{
    internal class Program
    {
        public static void Main()
        {
                long[] inputData = Array.ConvertAll(Console.ReadLine().Split(' '), input => Int64.Parse(input));
                long firstNumber = inputData[0];
                long secondNumber = inputData[1];

                int firstRankValue = GetRankOfValue(firstNumber);
                int secondRankValue = GetRankOfValue(secondNumber);


                int currentRank = firstRankValue;
                long deviderForRank = Int64.Parse(GetDeviderForRank(currentRank));

                //calculate position of max digit in start value
                int positionOfMaxDigitFirstValue = (int)Math.Ceiling((decimal)firstNumber / deviderForRank);

                int possibleTests = 0;

                while (currentRank <= secondRankValue)
                {
                    if (currentRank != secondRankValue)
                    {
                        // we add 1 for including second bound in calculating
                        possibleTests += 9 - positionOfMaxDigitFirstValue + 1;

                        //next rank starts from {1 * 10^rank} value therefore position of max digit equals 1
                        positionOfMaxDigitFirstValue = 1;
                        currentRank++;
                    }
                    else
                    {
                        deviderForRank = Int64.Parse(GetDeviderForRank(currentRank));
                        int positionOfMaxDigitSecondValue = (int)Math.Floor((decimal)secondNumber / deviderForRank);
                        possibleTests += positionOfMaxDigitSecondValue - positionOfMaxDigitFirstValue + 1;
                        break;
                    }
                }

                Console.WriteLine(possibleTests);
        }

        public static int GetRankOfValue(long inputValue)
        {
            int numberOfRank = 0;
            long deviderForRank = 10;
            
            while (inputValue / deviderForRank >= 1)
            {
                deviderForRank *= 10;
                numberOfRank += 1;
            }
            return numberOfRank;
        }

        public static string GetDeviderForRank(int rank)
        {
            if (rank == 0) { return "1";}
            return GetDeviderForRank(rank - 1) + "1";
        }
    }
}