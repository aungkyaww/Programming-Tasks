using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler28 //Should've simplified the terms first, and calculated one expression each iteration
{
    class Program
    {
        static long v1 (long n)
        {
           // Console.Write("Adding: " + (n * n));
            
            return n * n;
        }
        static long v2(long n)
        {
           // Console.Write(" + " + (((n - 1) * (n - 1)) - (n - 2)));
            return (((n - 1) * (n - 1)) - (n-2));
        }
        static long v3(long n)
        {
            //Console.Write(" + " + (((n - 1) * (n - 1)) + 1));
            return (((n - 1) * (n - 1))  + 1);
        }
        static long v4(long n)
        {
           // Console.WriteLine(" + " + (((n) * (n)) - (n - 1)));
            return (((n) * (n))  -  (n - 1));
        }
        static void Main(string[] args)
        {
            int sizeOfFrame = 1001;
            long sum = 1;
            for (int i = 3; i <= sizeOfFrame; i += 2)
            {
                sum += v1(i);
                sum += v2(i);
                sum += v3(i);
                sum += v4(i);
            }
            Console.WriteLine("Total sum for diagonals is: " + sum);
            Console.ReadKey();
        }
    }
}
