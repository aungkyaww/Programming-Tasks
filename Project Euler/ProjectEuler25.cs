using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEuler25 //Now trivial with BigInteger class.
{
    class Program
    {

        
        static void Main(string[] args)
        {
            BigInteger num1 = new BigInteger(1);
            BigInteger num2 = new BigInteger(1);
            BigInteger num3 = new BigInteger(2);
            int index = 2;
            while (num3.ToString().Length < 1000)
            {
                num3 = BigInteger.Add(num1, num2);
                num1 = num2;
                num2 = num3;
                index++;
            }
            Console.WriteLine(index);
            Console.ReadLine();
        }
    }
}
