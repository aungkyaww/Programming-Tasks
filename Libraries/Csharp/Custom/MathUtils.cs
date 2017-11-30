using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtils
{/// <summary>
/// A collection of utilies for generating or checking prime numbers
/// </summary>
    public static class PrimeUtils
    {


        private static void Fill<T>(this T[] arr, T value)
        {

            for (int i = 0; i < arr.Length; i++)
            {

                arr[i] = value;
            }
        }


        /// <summary>
        /// Checks a positive integer for primality
        /// </summary>
        /// <param name="n">Number to check for primality</param>
        /// <returns>bool</returns>
        public static Boolean IsPrime(long n)
        {

            if (n <= 0)
                return false;
            if (n == 1)
                return false;
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;
            if (n == 3)
                return true;
            if (n == 5)
                return true;

            long x = (long)Math.Ceiling(Math.Sqrt(n));

            for (int i = 3; i <= x; i += 2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Uses a prime seive to generate primes up to n
        /// </summary>
        /// <param name="n">inclusive of n</param>
        /// <returns>int[] array of primes</returns>
        public static int[] Sieve(int n)
        {
            List<int> primes = new List<int>();
            bool[] c = new bool[n];
            c.Fill(false);
            primes.Add(2);

            int p = 3;
            int i = 3;
            //int nSquared = n * n;
            while (p <= n)
            {

                if (!c[p])
                {
                    primes.Add(p);
                    i = p * p;
                    while (i < n)
                    {
                        c[i] = true; //considered
                        i += p;
                    }
                }
                p += 2;
            }
            int[] a = primes.ToArray();
            return a;
        }

    }/// <summary>
    /// a GCD algorithm. There may be other fractional related utilies added here in future
    /// </summary>
    public static class DivUtils
    {
        /// <summary>
        /// Finds the General Common Divisor of two integers.
        /// </summary>
        /// <param name="a">first</param>
        /// <param name="b">second</param>
        /// <returns>int</returns>
        public static int GCD(int a, int b)
        {
            {
                int temp = 0;
                if (b > a)
                {
                    temp = b;
                    b = a;
                    a = temp;
                }
                while (b != 0)
                {
                    temp = b;
                    b = a % b;
                    a = temp;

                }
                return a;
            }
        }
    }
    /// <summary>
    /// Factorials and Base conversions
    /// </summary>
    public static class NumberUtils
    {


        /// <summary>
        /// returns the factorial of a number
        /// </summary>
        /// <param name="a">n</param>
        /// <returns>long</returns>
        public static long Factorial(long a)
        {
            if (a <= 0)
            {
                return 0;
            }

            long sum = 1;
            for (int i = 1; i <= a; i++)
            {
                sum *= i;
            }

            return sum;
        }
        /// <summary>
        /// Takes a Decimal Value and converts it to Binary
        /// </summary>
        /// <param name="dec">A decimal number</param>
        /// <returns>A String of the binary representation of the value</returns>
        public static string DecToBin(int dec)
        {
            string bin = "";
            while (dec != 0)
            {
                bin += (dec % 2);
                dec = dec / 2;
            }
            return bin;
        }

        /// <summary>
        /// Takes a Decimal Value and converts it to Binary
        /// </summary>
        /// <param name="dec">A decimal number</param>
        /// <returns>A String of the binary representation of the value</returns>
        public static string DecToBin(long dec)
        {
            string bin = "";
            while (dec != 0)
            {
                bin += (dec % 2);
                dec = dec / 2;
            }
            return bin;
        }

        /// <summary>
        /// Takes a Decimal Value and converts it to Binary
        /// </summary>
        /// <param name="dec">A decimal number</param>
        /// <returns>A String of the binary representation of the value</returns>
        public static string DecToBin(double dec)
        {
            string bin = "";
            while (dec != 0)
            {
                bin += (dec % 2);
                dec = dec / 2;
            }
            return bin;
        }

        /// <summary>
        /// Takes a Decimal Value and converts it to Binary
        /// </summary>
        /// <param name="dec">A decimal number</param>
        /// <returns>A String of the binary representation of the value</returns>
        public static string DecToBin(byte dec)
        {
            string bin = "";
            while (dec != 0)
            {
                bin += (dec % 2);
                dec = (byte) (dec / 2);
            }
            return bin;
        }

        /// <summary>
        /// Takes a binary string and converts it into a 32-bit integer
        /// </summary>
        /// <param name="bin">A string representing binary values</param>
        /// <returns>A 32-bit integer</returns>
        public static int BinToDec(string bin)
        {
            int dec = 0;
            int multiplier = 1;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                dec += int.Parse(bin[i].ToString()) * multiplier;
                multiplier *= 2;
            }
            return dec;
        }

        /// <summary>
        /// Takes a binary string and converts it into a 64-bit long
        /// </summary>
        /// <param name="bin">A string representing binary values</param>
        /// <returns>A 64-bit integer</returns>
        public static long BinToDecLong(string bin)
        {
            long dec = 0;
            int multiplier = 1;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                dec += long.Parse(bin[i].ToString()) * multiplier;
                multiplier *= 2;
            }
            return dec;
        }
    }



}
