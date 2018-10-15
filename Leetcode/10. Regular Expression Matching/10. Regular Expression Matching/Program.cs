using System;

namespace _10.Regular_Expression_Matching
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            //find char, find qualifier, if q = *, then match 0-1, if q = . match once, if q=* and c=., match all until reaching next char in pattern in main

            if (s == "" && p == "")
            {
                return true;
            }
            if (p == "" && s != "")
            {
                return false;
            }
            if (s == p)
            {
                return true;
            }


            int i = 0; int j = 0;
            char prevChar = '\0';
            char boundary;
            char prevMatchedChar = '\0';
            while (i < p.Length || j < s.Length)
            {

                if (!(i < p.Length))
                {
                    return false;
                }
                if (!(j < s.Length))
                {
                    return false;
                }

                //Boundary == . and s[j] != p[i + 1]      
                if (i < p.Length - 1 && p[i + 1] == '*' && (prevChar == '\0' || prevMatchedChar == '\0' || prevMatchedChar == prevChar || prevChar == '.'))
                {
                    i++;
                    boundary = p[i - 1];
                    //If boundary == ., skip the character it would automatically match (or P[i+1] could match s[j], as the index wouldn't have yet moved)
                    if (boundary == '.')
                    {
                        j++;
                    }
                    //if c = a, p = a* match at least once
                    if (boundary == s[j] && p[i] == '*' )
                    {
                        j++;
                    }
                    while (j < s.Length && (boundary == s[j] || boundary == '.') && !(i < p.Length - 1 &&  p[i + 1] == s[j]))
                    {
                        j++;                  
                    }
                    prevMatchedChar = boundary;
                    i++;
                }
                else if ((p[i] == s[j] || p[i] == '.'))
                {
                    prevChar = s[j];
                    if (p[i] == s[j] || p[i] == '.')
                    {
                        prevMatchedChar = s[j];
                        j++;
                    }
                    i++;
                }
                else
                {
                    //Doesn't fit the pattern
                    return false;
                }
            }
            return true;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.IsMatch("aab", "c*a*b") + "T");
            Console.WriteLine(solution.IsMatch("aa", "a") + "F");
            Console.WriteLine(solution.IsMatch("aab", "caab") + "F");
            Console.WriteLine(solution.IsMatch("aab", "aab") + "T");
            Console.WriteLine(solution.IsMatch("mississippi", "mis*is*p*.") + "F");
            Console.WriteLine(solution.IsMatch("aa", "a*") + "T");
            Console.WriteLine(solution.IsMatch("aa", ".*") + "T");
            Console.WriteLine(solution.IsMatch("aabaabaa", ".*") + "T");
            Console.WriteLine(solution.IsMatch("abcabcaabbcc", "abc.*aabbcd*.") + "T");
            Console.WriteLine(solution.IsMatch("aaa", "a*a") + "T");
            Console.ReadLine();
        }
    }
}
