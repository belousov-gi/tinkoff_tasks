using System;

namespace task_2
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                int guestsAmount;
                var inputData = Console.ReadLine();
                if (inputData != "")
                {
                    guestsAmount = Int32.Parse(inputData);
                    if (guestsAmount < 1)
                    {
                        throw new Exception("Invalid amount of guests");
                    }  
                }
                else
                {
                    throw new Exception("Invalid amount of guests");
                }
              
                int numbersOfCut = (int)Math.Ceiling(Math.Log(guestsAmount, 2));

                Console.WriteLine(numbersOfCut);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}