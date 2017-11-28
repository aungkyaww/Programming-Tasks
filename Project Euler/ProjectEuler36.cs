using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtils;
namespace ProjectEuler36
{
    public static class StringExtensions
    {
        public static string ReverseString(this string str)
        {
            string final = "";
            for (int i = (str.Length - 1); i >= 0; i--)
            {
                final += str[i];
            }
            return final;
        }
    }
    class Program
    {
        

        static void Main(string[] args)
        {
            NumberUtils nu = new NumberUtils();
            int sum = 0;
            for (int i = 0; i < 1000001; i++)
            {
                string a = i.ToString();
                if (a == a.ReverseString())
                {
                    a = nu.DecToBin(i);
                    if(a.ReverseString() == a)
                    {
                        Console.WriteLine("Found dobule palindromic number: " + i);
                        sum += i;

                    }
                }
            }

            Console.WriteLine("Sum is: " + sum);
            Console.WriteLine("finished".ReverseString());
            Console.ReadLine();
        }
    }
}
