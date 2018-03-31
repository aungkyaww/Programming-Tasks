using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Rosalind.Utils;

namespace Open_Reading_Frames
{

    class Program
    {
        public static List<string> ReadFrames(string dnaString, List<string> currentProteinList = default(List<string>))
        {
            char[] rnaChars = dnaString.Replace('T', 'U').ToCharArray();
            bool stop = currentProteinList == null ? false : true;
            //When stop = true, frames 4-6 are read in this pass.
            List<string> proteins = currentProteinList == null ? new List<string>() : currentProteinList;
            int i = 0;
            while (i < rnaChars.Length - 4)
            {
                string aminoAcid = new string(rnaChars, i, 3);
                if (Constants.CodonTable.ContainsKey(aminoAcid))
                {
                    if (Constants.CodonTable[aminoAcid] == 'M')
                    {
                        StringBuilder sb = new StringBuilder();
                        int j = i;
                        while (Constants.CodonTable[aminoAcid] != '.' && i < rnaChars.Length - 4 && j < rnaChars.Length - 4)
                        {
                            aminoAcid = new string(rnaChars, j, 3);
                            if (Constants.CodonTable[aminoAcid] != '.')
                            {
                                sb.Append(Constants.CodonTable[aminoAcid]);
                                j += 3;
                            }
                        }
                        if (!proteins.Contains(sb.ToString()) && Constants.CodonTable[aminoAcid] == '.')
                        {
                            proteins.Add(sb.ToString());
                        }
                    }
                }
                i++;
            }

            //Read frames 4-6
            if (!stop)
            {
             ReadFrames(StringUtils.ReverseCompliment(dnaString).Replace('T', 'U'), proteins);
            }

            return proteins;
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

            List<string> proteins = ReadFrames(fasta.DNA);

            proteins.ForEach((s) => Console.WriteLine(s));
            Console.ReadLine();
        }
    }
}
