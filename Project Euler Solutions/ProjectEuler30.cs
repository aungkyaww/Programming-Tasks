using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler30
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 355000;
            int sum = 0;
            double power = 5;
            for (int i = 10; i < limit; i++)
            {
                int total = 0;
                int number = i;
                string digits = i.ToString();
                
                for (int j = 0; j < digits.Length; j++)
                {
                    total += (int) Math.Pow(double.Parse(digits.Substring(j, 1)), power);
                }

                if (total == number)
                {
                    sum += number;
                }

            }
            Console.WriteLine("Sum of numbers is: " + sum);
            Console.ReadLine();
        }
    }
}
