using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mendel_s_First_Law
{


    class Program
    {
       //From http://thagomizer.com/blog/2014/11/19/approaching-rosalind-problems.html
        public static double CalculateProbability(int dominant, int heterozygous ,int recessive)
        {
            double total = dominant + heterozygous + recessive;
            double recess_recess = (recessive / total) * ((recessive - 1) / (total - 1));
            double hetero_hetero = (heterozygous / total) * ((heterozygous - 1) / ( total - 1));
            double hetero_recess = ((heterozygous / total) * (recessive / (total - 1))) + ((recessive / total) *  (heterozygous / (total - 1)));

            return 1 - (hetero_recess * 0.5) - (hetero_hetero * 0.25) - recess_recess;

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

            string[] str = lines[0].Split(' ');
            var arr = str.Select(int.Parse).ToArray<int>();

            int k = arr[0];
            int m = arr[1];
            int n = arr[2];

           Console.WriteLine(CalculateProbability(k, m, n));

            Console.ReadLine();
        }
    }
}
