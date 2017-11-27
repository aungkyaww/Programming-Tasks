using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtils;

namespace ProjectEuler27
{
    class Program
    {


        static long calculateQuadratic(int n, int a, int b)
        {
           
            long value = (n * n) + (a*n) + b;
           
            return value;
        }

        static void Main(string[] args)
        {
            //n^2 + an + b
       
            long productForLongestPrimeCoefficients = 0;
            int longestValueForN = 0;
            PrimeUtils pu = new PrimeUtils();
            int LIMIT = 1000;
            int START = -1000;
            for (int coefficientA = START; coefficientA <= LIMIT; coefficientA++)
            {
                for (int coefficientB = START; coefficientB <= LIMIT; coefficientB++)
                {
                    int n = 0;
                    int count = 0;
                    long solution = 0;
                    bool endLoop = false;
                    long product;

                    while (!endLoop)
                    {
                        solution = calculateQuadratic(n, coefficientA, coefficientB);
                        if (pu.isPrime(solution))
                        {
                            n++;
                            //Console.WriteLine(solution + " is prime");
                            count++;
                        }
                        else
                        {
                            if (coefficientA == 1 && coefficientB == 41)
                            {
                               /// Console.WriteLine("a is 1, b is 41, n is " + count);
                            }

                            product = (coefficientA) * (coefficientB);
                            if (longestValueForN < count)
                            {
                                longestValueForN = count;
                                productForLongestPrimeCoefficients = product;
                                Console.WriteLine("Found new highest length at: a = " + coefficientA + " b = " + coefficientB + " with a length of " + count + " and a product of " + product);
                            }
                               
                            endLoop = true;
                        }
                    }
                }
            }


          

            Console.WriteLine("finished");
            Console.ReadLine();
            
        }
    }
}
