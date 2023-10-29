using System;
namespace task_1
{

    public class Program
    {
        public static void Main()
        {
            string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (inputData.Length != 4)
            {
                throw new Exception("Invalid amount of input parameters");
            }

            byte[] convetedInputData = Array.ConvertAll(inputData, byte.Parse);
            foreach (var variable in convetedInputData)
            {
                if (variable < 1 || variable > 100)
                {
                    throw new Exception($"Invalid input parameter {variable}");
                }
            }

            try
            {
                byte monthPayement = convetedInputData[0];
                byte availiableTraffic = convetedInputData[1];
                byte extraPayementForMb = convetedInputData[2];
                byte trafficConsuming = convetedInputData[3];
                sbyte traffiсSubtraction = (sbyte)(availiableTraffic - trafficConsuming);

                short generalPayment = monthPayement;

                if (traffiсSubtraction < 0)
                {
                    generalPayment += (short)(Math.Abs(traffiсSubtraction) * extraPayementForMb);
                }

                Console.WriteLine(generalPayment);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}