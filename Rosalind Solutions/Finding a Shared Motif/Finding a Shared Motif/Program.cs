using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Rosalind.Utils;
using System.Diagnostics;

namespace Finding_a_Shared_Motif
{


    class Program
    {
        public static string LongestCommonSubstring(List<string> strings)
        {
            if (strings.Count <= 1)
            {
                return strings.Count == 0 ? null : strings[0];
            }
            List<string> substrings = new List<string>();
            string str1;
            string str2;
            if (strings[0].Length > strings[1].Length)
            {
                str1 = strings[1];
                str2 = strings[0];
            }
            else
            {
                str1 = strings[0];
                str2 = strings[1];
            }
            char[] chars1 = str1.ToCharArray();
            char[] chars2 = str2.ToCharArray();
            int offset = 0;
            int string1Length = 1;
            while (offset < str1.Length)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    string substring2;
                    string substring1;

                    //Bunch of checks to avoid allocating a new string if it's not needed
                    if (string1Length + j <= str2.Length - 1 && string1Length + offset <= str1.Length - 1 && chars1[offset] == chars2[j] && (j != 0 || string1Length != 0) && chars1[offset + string1Length - 1] == chars2[j + string1Length - 1])
                    {
                        //Then allocate the strings
                        substring1 = new string(chars1, offset, string1Length);

                        if (string1Length + j <= str2.Length - 1)
                        {
                            substring2 = new string(chars2, j, substring1.Length);
                        }
                        else
                        {
                            continue;
                        }

                        if (substring1 == substring2)
                        {

                            if (!substrings.Contains(substring1))
                            {
                                substrings.Add(substring1);
                            }
                        }

                    }
                }

                if (string1Length == str1.Length - 1)
                {
                    string1Length = 0;
                    offset++;
                }
                else
                {
                    string1Length++;
                }
            }

            for (int i = 2; i < strings.Count; i++)
            {
                List<string> stringsToRemove = new List<string>();
                foreach (string substring in substrings)
                {
                    if (!strings[i].Contains(substring))
                    {
                        stringsToRemove.Add(substring);
                    }

                }
                foreach (string str in stringsToRemove)
                {
                    substrings.Remove(str);
                }
            }
            return substrings.Aggregate(string.Empty, (seed, str) => str.Length > seed.Length ? str : seed);
        }

        static void Main(string[] args)
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string[] files = Directory.GetFiles(strPath + @"\Rosalind", "*.txt"); //Assumes only one txt file in this directory - the data set
            string[] lines = { "" };
         
                lines = File.ReadAllLines(files[0]);
            
            List<Fasta> fastas = Fasta.DecodeFasta(lines);

            Stopwatch itime = new Stopwatch();

            string[] dnaOnly = new string[fastas.Count];
            for (int i = 0; i < fastas.Count; i++)
            {
                dnaOnly[i] = fastas[i].DNA;
            }
            itime.Start();
            Console.WriteLine(LongestCommonSubstring(dnaOnly.ToList()));
            itime.Stop();
            Console.WriteLine("Took: {0}ms", itime.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
