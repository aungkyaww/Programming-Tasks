using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Reverse_Integer
{
    class Program
    {
        public static int ReverseDigits(int x)
        {
            string num = x.ToString();
            bool neg = num.StartsWith("-");
            char[] chars = neg ? num.Skip(1).ToArray() : num.ToCharArray();
           
            for (int i = 0; i < chars.Length / 2; i++)
            {
                char temp = chars[i];
                chars[i] = chars[chars.Length - 1 - i];
                chars[chars.Length - 1 - i] = temp;
            }
            string final = new string(chars);
            return int.TryParse(neg ? "-" + final : final, out int number) ? number : 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ReverseDigits(12345));
            Console.WriteLine(ReverseDigits(123456789));
            Console.WriteLine(ReverseDigits(-123456));
            Console.ReadLine();
        }
    }
}
