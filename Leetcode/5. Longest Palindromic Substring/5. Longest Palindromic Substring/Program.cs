using System;
using System.Linq;

namespace _5._Longest_Palindromic_Substring
{
    public class Solution
    {
        public string LongestPalindromicSubstring(string s)
        {
            if (s.Length == 0)
                return "";

            if (s.Length == 1)
            {
                return s;
            }
            string longestPalindrome = "";
            string currentPalindrome = "";
            for (int i = 0; i < s.Length; i++)
            {
                currentPalindrome = Expand(s, i, i);
                if (currentPalindrome.Length > longestPalindrome.Length)
                {
                    longestPalindrome = currentPalindrome;
                }
                currentPalindrome = Expand(s, i, i + 1);
                if (currentPalindrome.Length > longestPalindrome.Length)
                {
                    longestPalindrome = currentPalindrome;
                }
            }

            return longestPalindrome;
        }

        private string Expand(string s, int index1, int index2)
        {

            while (index1 >= 0 && index2 <= s.Length - 1 && s[index1] == s[index2])
            {
                index1--;
                index2++;
            }
            return s.Substring(index1 + 1, index2 - (index1 + 1));
        }


        public string LongestPalindromicSubstringBruteForce(string s)
        {
            if (s.Length == 0)
            {
                return "";
            }

            if (s.Length == 1)
            {
                return s;
            }

            string longestPalindrome = s[0].ToString();
            char[] chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = i + 1; j < chars.Length; j++)
                {

                    if (j - i > longestPalindrome.Length - 1)
                    {
                        var arrSeg = new ArraySegment<char>(chars, i, j - i + 1).ToArray();
                        Array.Reverse(arrSeg);
                        if (Enumerable.SequenceEqual(arrSeg, new ArraySegment<char>(chars, i, j - i + 1).ToArray()))
                        {
                            longestPalindrome = new string(arrSeg);
                        }
                    }
                }
            }
            return longestPalindrome;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.LongestPalindromicSubstring("abbaabba"));
            Console.WriteLine(solution.LongestPalindromicSubstring("a"));
            Console.WriteLine(solution.LongestPalindromicSubstring(""));
            Console.WriteLine(solution.LongestPalindromicSubstring("aa"));
            Console.WriteLine(solution.LongestPalindromicSubstring("bhhbaaabbbaaaaaccuiyq"));
            Console.ReadLine();
        }
    }
}
