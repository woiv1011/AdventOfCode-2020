using System;
using System.IO;
using System.Linq;

namespace Day_1___Report_Repair
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1(); // 381699
            Part2(); // 111605670
        }

        /// <summary>
        /// Find two numbers that add up to 2020
        /// </summary>
        /// <returns>
        /// Product of both numbers
        /// </returns>
        static int Part1()
        {

            var inputs = File.ReadAllLines(@"input.txt").Select(str => Int32.Parse(str));

            foreach (int number in inputs)
            {
                int diff = 2020 - number;
                if (inputs.Any(otherNum => otherNum == diff))
                {
                    var result = number * diff;
                    Console.WriteLine(result);
                    return result; //should return 381699
                }
            }
            return -1;
        }

        /// <summary>
        /// Find three numbers that add up to 2020
        /// TODO performance
        /// </summary>
        /// <returns>
        /// Product of the three numbers
        /// </returns>
        static int Part2()
        {
            var inputs = File.ReadAllLines(@"input.txt").Select(str => Int32.Parse(str));

            foreach (int currentInputNumber in inputs)
            {
                //try out if two numbers can be found that add up to diff betwenn 2020 and current input
                int sum2Target = 2020 - currentInputNumber;

                //find two numbers that add up to sum2Target
                foreach (int summand1 in inputs)
                {
                    try
                    {
                        int summand2 = inputs.First<int>(num => num + summand1 == sum2Target); //TODO very slow, 60? seconds
                        int result = currentInputNumber * summand1 * summand2;
                        Console.WriteLine(result);
                        return result; //should return 111605670
                    }
                    catch (InvalidOperationException)
                    {
                        //continue;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return -1;
        }
    }
}
