using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace EnumeratingKmersLexicographically
{
   

    class Program
    {

        public static List<string> CalculateSetPermutations(char[] alphabet, int count)
        {
            List<string> stringList = new List<string>();
            CalculateSetPermutationsRecursively(alphabet, "", 0, count, ref stringList);
            return stringList;

        }

        public static List<string> CalculateSetPermutationsRecursively(char[] alphabet, string str, int pos, int count, ref List<string> stringList)
        {
            if (pos == count)
            {
                stringList.Add(str);
                return stringList;
            }
            for (int i = 0; i < alphabet.Length; i++)
            {

                CalculateSetPermutationsRecursively(alphabet, str + alphabet[i], pos + 1, count, ref stringList);
            }
            return stringList;
        }

        static void Main(string[] args)
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string[] files = Directory.GetFiles(strPath + @"\Rosalind", "*.txt"); //Assumes only one txt file in this directory - the data set
            string[] lines = new string[2];
            foreach (var file in files)
            {
                lines = File.ReadAllLines(file);
            }
            char[] symbols = lines[0].Split(' ').ToList().ConvertAll(s => char.Parse(s)).ToArray();
            int len = int.Parse(lines[1]);

            foreach (string str in CalculateSetPermutations(symbols, len)) 
            {

                Console.WriteLine(str);
            }
    
            Console.ReadLine();
        }
    }
}
