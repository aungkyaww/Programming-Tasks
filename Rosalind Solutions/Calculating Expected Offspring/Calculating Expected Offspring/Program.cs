using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Rosalind.Utils;

namespace Calculating_Expected_Offspring
{

    class Program
    {
        public static double CalculateExpectedOffspring(int HGD_HGD,int HGD_HZ, int HGD_HGR, int HZ_HZ, int HZ_HGR, int HGR_HGR, int numOfOffspring)
        {
            //HGD Homogenous Dominant, HGR Homogenous Recessive, HZ Heterozygous
            //pHGD_HZ number of offspring displaying the dominant phenotype

            int total = HGD_HGD + HGD_HZ + HGD_HGR + HZ_HZ + HZ_HGR + HGR_HGR;
            double pHGD = numOfOffspring * HGD_HGD;
            double pHGD_HZ = numOfOffspring * HGD_HZ;
            double pHGD_HGR = numOfOffspring * HGD_HGR;
            double pHZ_HZ = (numOfOffspring * HZ_HZ) * 0.75;
            double pHZ_HGR = (numOfOffspring * HZ_HGR) * 0.50;
            double pHGR = 0;

            return pHGD + pHGD_HZ + pHGD_HGR + pHZ_HZ + pHZ_HGR + pHGR;

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

            int[] numbers = lines[0].Split(' ').ToList().ConvertAll<int>(s => int.Parse(s)).ToArray();


            Console.WriteLine(CalculateExpectedOffspring(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], numbers[5], 2));
            Console.ReadLine();
        }
    }
}
