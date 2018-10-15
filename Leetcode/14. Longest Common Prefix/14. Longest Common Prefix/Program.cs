using System;
using System.Linq;


namespace _14.Longest_Common_Prefix
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1)
            {
                return strs[0];
            }
            if (strs.Length == 0)
            {
                return "";
            }
            int minLength = int.MaxValue;

            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < minLength)
                {
                    minLength = strs[i].Length;
                }
            }
            if (minLength == 0)
            {
                return "";
            }
            int j = 0;
            bool end = false;
            string finalPrefix = "";
            while (j < minLength && !end)
            {
                char c = strs[0][j];
                for (int i = 1; i < strs.Length; i++)
                {
                    if (strs[i][j] != c)
                    {
                        end = true;
                        break;
                    } 
                }
                j++;
                if (!end)
                {
                    finalPrefix += c;
                }
            }
            return finalPrefix;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
            Console.WriteLine(solution.LongestCommonPrefix(new string[] { "", ""}));
            Console.WriteLine(solution.LongestCommonPrefix(new string[] { "flow", "flow", "flow" }));
            Console.WriteLine(solution.LongestCommonPrefix(new string[] { "c", "c"}));
            Console.ReadLine();
        }
    }
}
