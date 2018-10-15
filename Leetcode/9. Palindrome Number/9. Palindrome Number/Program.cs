using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _9.Palindrome_Number
{
    class Program
    {
        public static bool IsPalindromeNumer(int num)
        {
                int reversed = 0;
            int operand = num;
                while (num > 0)
                {
                    reversed = reversed * 10 + num % 10;
                    num /= 10;
                }
            return (operand ^ reversed) == 0;
        }
        public static bool IsPalindromeNumerString(int num)
        {
            return num.ToString().Reverse().ToString() == num.ToString();
        }

        public static int ReverseInt(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }

        static double Profile(string description, int iterations, Action func)
        {
            //Run at highest priority to minimize fluctuations caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // warm up 
            func();

            var watch = new Stopwatch();

            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            Console.Write(description);
            Console.WriteLine(" Time Elapsed {0} ms", watch.Elapsed.TotalMilliseconds);
            return watch.Elapsed.TotalMilliseconds;
        }

        static void Main(string[] args)
        {
            int iterations = 100000000;
            Profile("Int Only", iterations, () => IsPalindromeNumer(123123123));
            Profile("String Compare", iterations, () => IsPalindromeNumerString(123123123));
            Console.ReadLine();
        }
    }
}
