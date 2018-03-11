using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtils;
namespace ProjectEuler34
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<long> digitFacts = new HashSet<long>();
            NumberUtils f = new NumberUtils();
            int iterInterval = 100000;
            int iterCount = 0;
            long finalSum = 0;
            for (int i = 10; i < 2540160; i++) //9!*7 = 2540160, 9!*8 is still 7 digits, therefore upper limit is 2540160
            {
                //Console.Write("Number is: " + i + "\t");
                long sum = 0;
                string number = i.ToString();

                for (int j = 0; j < i.ToString().Length; j++)
                {
                    if (int.Parse((number[j]).ToString()) == 0)
                    {
                        sum += 1;
                    }
                    else
                    {

                        sum += f.Factorial(int.Parse((number[j]).ToString())); //Use modulo in future
                    }
                    
                }
                if (sum == i)
                {
                    digitFacts.Add(sum);
                    Console.WriteLine("Found value: " + sum);
                    finalSum += sum;
                }
                iterCount++;
                if (iterCount == iterInterval)
                {
                    iterInterval += 100000;
                    Console.WriteLine("Considered: " + iterInterval + " numbers");
                }
            }
            Console.WriteLine("Finished....");
            Console.WriteLine("Number of values: " + digitFacts.Count);
            Console.WriteLine("Final Sum of values is: " + finalSum);
            Console.ReadLine();
        }
    }
}
