using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace _28.Implement_strStr__
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (haystack == "" && needle == "") {
                return 0;
            }
            if (haystack == "")
            {
                return -1;
            }
            if (needle == "")
            {
                return 0;
            }
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack.Length - needle.Length - i < 0)
                {
                    return -1;
                }
                if (haystack[i] == needle[0])
                {
                    for (int j = 1; j < needle.Length; j++)
                    {
                        if (i + j > haystack.Length - 1 || haystack[i + j] != needle[j])
                        {
                            goto end; //Fancied trying a goto statement here. Probably not the best solution, can't use break however, as I just need to exit the inner loop, not the outer one
                        }
                    }
                    return i;
                }
                end:;
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.StrStr("heee", "eeee"));
            Console.ReadLine();
        }
    }
}
