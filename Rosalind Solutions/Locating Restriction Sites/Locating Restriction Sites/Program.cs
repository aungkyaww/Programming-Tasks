using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Rosalind.Utils;

namespace Locating_Restriction_Sites
{


    class Program
    {
        //I answered the wrong question initially in this exercise... 
        private static int?[][] FindPalindromes(string mainString, int minLen = 1, int maxLen = int.MaxValue)
        {
            if (minLen - 1 >= maxLen)
            {
                throw new Exception("Difference between minLen and MaxLen is too small.");
            }
            if (minLen != 0 || minLen != 1)
            {
                minLen--;
            }
            char[] chars = mainString.ToCharArray();
            List<int?[]> finalSegments = new List<int?[]>();
            int loopLength = chars.Length - minLen;
            if (maxLen > chars.Length)
            {
                maxLen = chars.Length;
            }
            for (int i = 0; i < loopLength; i++)
            {
                if (mainString.Length == 1 || mainString.Length < minLen)
                {
                    return null;
                }
                for (int j = minLen; j < maxLen; j++)
                {
                    if (j + i > chars.Length - 1)
                    {
                        continue;
                    }
                    if (chars[i] == chars[j + i])
                    {
                        char[] mainCharArray = new char[j + 1];
                        char[] subCharArray = new char[j + 1];
                        for (int k = 0; k <= j; k++)
                        {
                            mainCharArray[k] = chars[k + i];
                            subCharArray[k] = chars[k + i];
                        }
                        subCharArray = subCharArray.Reverse().ToArray();

                        if (StringUtils.MatchSubstring(mainCharArray, subCharArray))
                        {
                            finalSegments.Add(new int?[] { i + 1, j + 1 });
                        }
                    }
                }
            }
            return finalSegments.ToArray();
        }

        public static char[] ReverseCompliment(char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case 'A': chars[i] = 'T'; break;
                    case 'C': chars[i] = 'G'; break;
                    case 'T': chars[i] = 'A'; break;
                    case 'G': chars[i] = 'C'; break;
                }
            }
            return chars.Reverse().ToArray(); ;
        }

        private static int?[][] FindDNAReversePalindrome(string mainString, int minLen = 1, int maxLen = int.MaxValue)
        {
            if (minLen - 1 >= maxLen)
            {
                throw new Exception("Difference between minLen and MaxLen is too small.");
            }
            if (minLen != 0 || minLen != 1)
            {
                minLen--;
            }
            char[] chars = mainString.ToCharArray();
            List<int?[]> finalSegments = new List<int?[]>();
            int loopLength = chars.Length - minLen;
            if (maxLen > chars.Length)
            {
                maxLen = chars.Length;
            }
            for (int i = 0; i < loopLength; i++)
            {
                if (mainString.Length == 1 || mainString.Length < minLen)
                {
                    return null;
                }
                for (int j = minLen; j < maxLen; j++)
                {
                    if (j + i > chars.Length - 1)
                    {
                        break;
                    }
                    char[] mainCharArray = new char[j + 1];
                    char[] subCharArray = new char[j + 1];
                    for (int k = 0; k <= j; k++)
                    {
                        mainCharArray[k] = chars[k + i];
                        subCharArray[k] = chars[k + i];
                    }
                    subCharArray = ReverseCompliment(subCharArray);

                    if (StringUtils.MatchSubstring(mainCharArray, subCharArray))
                    {
                        Console.WriteLine((i + 1) + " " + (j + 1));
                        finalSegments.Add(new int?[] { i + 1, j + 1 });
                    }
                }
            }
            return finalSegments.ToArray();
        }





        static void Main(string[] args)
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string[] files = Directory.GetFiles(strPath + @"\Rosalind", "*.txt"); //Assumes only one txt file in this directory - the data set
            string[] lines = { "" };
            foreach (string file in files)
            {
                lines = File.ReadAllLines(file);
            }

            Fasta fasta = Fasta.DecodeFasta(lines)[0];


            int?[][] palindromes = FindDNAReversePalindrome(fasta.DNA, 4, 12);



            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
