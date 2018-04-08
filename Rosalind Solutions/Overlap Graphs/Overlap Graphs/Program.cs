using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Rosalind.Utils;

namespace Overlap_Graphs
{

    class Program
    {
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


            Console.ReadLine();
        }
    }
}
