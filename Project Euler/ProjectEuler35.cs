using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtils;

namespace ProjectEuler35
{
    class Program
    {
        static int RotateDigits(int n)
        {
            string d = n.ToString();
            d = (d[d.Length - 1].ToString()) + d;

            return int.Parse(d.Remove(d.Length - 1));


        }
        static void Main(string[] args)
        {

            HashSet<int> circularPrimes = new HashSet<int>();

            PrimeUtils pu = new PrimeUtils();
            for (int i = 0; i < 1000001; i++)
            {
                int len = i.ToString().Length - 1;
                int j = 0;
                int num = i;
                bool stillPrime = true;
                while (stillPrime && j <= len)
                {


                    if (pu.IsPrime(num))
                    {
                        //Console.WriteLine(num + " is prime");
                        
                        num = RotateDigits(num);

                        j++;
                    }
                    else
                    {
                        stillPrime = false;
                    }


                }


                if (stillPrime)
                {
                    Console.WriteLine("Found circular prime: " + i);
                    circularPrimes.Add(i);
                }
            }
            Console.WriteLine("Number of Values: " + circularPrimes.Count);
            Console.ReadLine();

        }
    }
}
