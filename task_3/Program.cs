using System;

namespace task_3
{
    internal class Program
    {
        public static void Main()
        {
            int employeesAmount = 0;
            int timeDeadline = 0;
            int[] floors = null;
            int targetEmployee = 0;
            int minFloorsAmount = 0;

            for (int i = 1; i < 4; i++)
            {
                string inputData = Console.ReadLine();

                if (inputData == "")
                {
                    Console.WriteLine("Invalid input parameter, try again");
                    i--;
                    continue;
                }

                try
                {
                    switch (i)
                    {
                        case 1:
                            string[] inputDataArr = inputData.Split(' ');
                            employeesAmount = int.Parse(inputDataArr[0]);
                            timeDeadline = int.Parse(inputDataArr[1]);
                            break;
                    
                        case 2:
                            floors = Array.ConvertAll(inputData.Split(' '),input => int.Parse(input));
                            break;
                    
                        case 3:
                            targetEmployee = int.Parse(inputData);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Try to input data again");
                    i--;
                }
            }
            
            
            int targetEmployeeInArr = (targetEmployee - 1);
            int maxIndexArr = (employeesAmount - 1);
            
            int maxFloor = floors[maxIndexArr];
            int firstFloor = floors[0];
            
            int targetFloor= floors[targetEmployeeInArr];

            if (maxFloor - targetFloor <= timeDeadline || targetFloor - firstFloor <= timeDeadline)
            {
                minFloorsAmount = maxFloor - firstFloor;
            }

            else
            {
                if (targetFloor - firstFloor < maxFloor - targetFloor )
                {
                    // first go down
                    minFloorsAmount += targetFloor - firstFloor;
                }
                else
                {
                    //first go up
                    minFloorsAmount += maxFloor - targetFloor;
                }
                
                minFloorsAmount += maxFloor - firstFloor;
            }
            Console.WriteLine(minFloorsAmount);
        }
    }
}