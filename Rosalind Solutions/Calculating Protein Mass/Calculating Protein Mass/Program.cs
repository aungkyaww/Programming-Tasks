using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculating_Protein_Mass
{


    class Program
    {

        public static double CalculateProteinMass(string proteinString)
        {
            char[] chars =  proteinString.ToCharArray();
            double totalWeight = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                totalWeight += Utils.Constants.MonoisotopicMassTable[chars[i]];
            }
            return totalWeight;
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

            Console.WriteLine(CalculateProteinMass(lines[0]));
            






            Console.ReadLine();
        }
    }
}
