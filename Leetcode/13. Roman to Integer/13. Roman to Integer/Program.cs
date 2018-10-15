using System;

namespace _13.Roman_to_Integer
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            int i = 0;
            int total = 0;
            if (s == "")
            {
                return 0;
            }

            while (i < s.Length)
            {
                if (s[i] == 'M')
                {
                    total += 1000;
                    i++;
                }
                else if (i < s.Length - 1 && s[i] == 'C' && s[i + 1] == 'M')
                {
                    total += 900;
                    i += 2;
                }
                else if (s[i] == 'D')
                {
                    total += 500;
                    i++;
                }
                else if (i < s.Length - 1 && s[i] == 'C' && s[i + 1] == 'D')
                {
                    total += 400;
                    i += 2;
                }
                else if (s[i] == 'C')
                {
                    total += 100;
                    i++;
                }
                else if (i < s.Length - 1 && s[i] == 'X' && s[i + 1] == 'C')
                {
                    total += 90;
                    i += 2;
                }
                else if (s[i] == 'L')
                {
                    total += 50;
                    i++;
                }
                else if (i < s.Length - 1 && s[i] == 'X' && s[i + 1] == 'L')
                {
                    total += 40;
                    i += 2;
                }
                else if (s[i] == 'X')
                {
                    total += 10;
                    i++;
                }
                else if (i < s.Length - 1 && s[i] == 'I' && s[i + 1] == 'X')
                {
                    total += 9;
                    i += 2;
                }
                else if (s[i] == 'V')
                {
                    total += 5;
                    i++;
                }
                else if (i < s.Length - 1 && s[i] == 'I' && s[i + 1] == 'V')
                {
                    total += 4;
                    i += 2;
                }
                else if (s[i] == 'I')
                {
                    total += 1;
                    i++;
                }
             
            }
            return total;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.RomanToInt("IV"));
            Console.WriteLine(solution.RomanToInt("MCMXCIV"));
            Console.WriteLine(solution.RomanToInt("MCDXLIX"));
            Console.ReadLine();
        }
    }
}
