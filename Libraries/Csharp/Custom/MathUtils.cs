using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtils
{
    public class PrimeUtils
    {
        public Boolean IsPrime(long n)
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

    }
    public class DivUtils
    {
        public int GCD(int a, int b)
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
    public class NumberUtils
    {
        public long Factorial(long a)
        {
            if (a <= 0)
            {
                return 0;
            }

            int sum = 1;
            for (int i = 1; i < a; i++)
            {
                sum *= i;
            }
            return sum;
        }
    }


}
