using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Rosalind.Utils;

namespace Inferring_mRNA_from_Protein
{

    class Program
    {
        private static Dictionary<char,int> BuildFrequencyTable()
        {
            Dictionary<char, int> frequencyDict = new Dictionary<char, int>();

            foreach (KeyValuePair<string, char> kvp in Constants.CodonTable)
            {
                if (!frequencyDict.ContainsKey(kvp.Value))
                {
                    frequencyDict[kvp.Value] = 1;
                }
                else
                {
                    frequencyDict[kvp.Value]++;
                }
            }
            return frequencyDict;
        }

        public static int mRNAInProtein(string protein)
        {
            Dictionary<char, int> frequencyTable = BuildFrequencyTable();
            int answer = 1;
            for (int i = 0; i < protein.Length; i++)
            {
                answer = ((answer * frequencyTable[protein[i]]) % 1000000);
            }
            //Also add stop codon (3 possibilities)
            answer = (answer * 3) % 1000000;
            return answer;
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
            string protein = lines[0];

            Console.WriteLine(mRNAInProtein(protein));

            Console.ReadLine();
        }
    }
}
