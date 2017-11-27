using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEuler29
{
    class Program
    {
        static void Main(string[] args)
        {
            // BigInteger a = new BigInteger(2);
           // int exponent = 2;
            HashSet<BigInteger> sequence = new HashSet<BigInteger>();

            for (int i = 2; i < 101; i++)
            {
                for (int j = 2; j < 101; j++)
                {
                    BigInteger a = new BigInteger(j);
                    a = BigInteger.Pow(a, i);
                    sequence.Add(a);
                }

            }
            Console.WriteLine("Length: " + sequence.Count);
            Console.ReadLine();
        }
    }
}
