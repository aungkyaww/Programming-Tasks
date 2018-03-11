using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtils;

namespace ProjectEuler37
{
    class Program
    {
        static Boolean CheckTruncPrime(int n)
        {
            PrimeUtils pu = new PrimeUtils();
            int num = n;
            while (num != 0)
            {
                if (!pu.IsPrime(num))
                {
                    return false;
                }
                else
                {
                    num /= 10; //right to left truncate
                }

            }
            num = n;
            string digits = n.ToString().Substring(1); //remove leading digit
            while (digits != "")
            {

                if (!pu.IsPrime(int.Parse(digits)))
                {
                    return false;
                }
                if (digits.Length == 1) //Checked the string in above statement.
                {
                    digits = "";
                }
                else
                {
                    digits = digits.Substring(1);
                }

            }
            return true;
        }

        static void Main(string[] args)
        {
            int sum = 0;
            int truncPrimeCount = 0;
            int i = 23;

            while (truncPrimeCount < 11)
              {
                 if ((i % 10 == 1))
                {
                    i += 2; //Skip when a number ends in 1 (1 isn't prime, therefore won't form a truncatable prime)
                }
                 if (CheckTruncPrime(i))
                {
                    truncPrimeCount++;
                    Console.WriteLine("Found Truncatable Prime: " + i);
                    sum += i;
                }
                i += 2;
              }

            Console.WriteLine("Sum is: " + sum);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
