using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Rosalind.Utils;

namespace RNA_Splicing
{

    class Program
    {
        public static string TranscribeRNAToProtein (string rnaString, string[] introns)
        {
            foreach (string intron in introns)
            {
                rnaString = rnaString.Remove(rnaString.IndexOf(intron), intron.Length);
            }

            return StringUtils.ComputeProtein(rnaString);
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
            List<Fasta> fastaList = Fasta.DecodeFasta(lines);
            string[] dnaStrings = new string[fastaList.Count];
            for (int i = 0; i < fastaList.Count; i++)
            {
                dnaStrings[i] = fastaList[i].DNA;
            }
            string[] introns = dnaStrings.Skip(1).ToArray();
            for (int i = 0; i < introns.Length; i++)
            {
                introns[i] = introns[i].Replace('T', 'U');
            }
            Console.WriteLine(TranscribeRNAToProtein(dnaStrings[0].Replace('T', 'U'), introns));

            Console.ReadLine();
        }
    }
}
