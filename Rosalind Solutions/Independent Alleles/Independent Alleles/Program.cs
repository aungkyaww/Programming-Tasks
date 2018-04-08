using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Numerics;
using Rosalind.Utils;


namespace Independent_Alleles
{

    class Program
    {
        //From: https://stackoverflow.com/questions/12983731/algorithm-for-calculating-binomial-coefficient
        public static ulong GetBinCoeff(ulong N, ulong K)
        {
            // This function gets the total number of unique combinations based upon N and K.
            // N is the total number of items.
            // K is the size of the group.
            // Total number of unique combinations = N! / ( K! (N - K)! ).
            // This function is less efficient, but is more likely to not overflow when N and K are large.
            // Taken from:  http://blog.plover.com/math/choose.html
            //
            ulong r = 1;
            ulong d;
            if (K > N) return 0;
            for (d = 1; d <= K; d++)
            {
                r *= N--;
                r /= d;
            }
            return r;
        }

        public static double CalculateProbabilityOffspring(uint k, uint n, double pS)
        {
            uint N = (uint)Math.Pow(2, k);
            double pF = 1 - pS;
            double probability = 0;
            for (uint i = n; i <= N; i++)
            {
                probability += GetBinCoeff(N, i) * (Math.Pow(pS, i)) * (Math.Pow(pF, N - i));
            }
            return probability;
        }

        public static double CalculateProbabilityOffspringVerbose(uint generations, uint minimumOffspring, double probabilityOfSuccess)
        {
            //The number of offspring at the k-th generation.
            uint numberOfTrials = (uint)Math.Pow(2, generations);
            double probabilityOfFailure = 1 - probabilityOfSuccess;
            double probability = 0;

            for (uint i = minimumOffspring; i <= numberOfTrials; i++)
            {
                //The number of "combinations" of each generation. For example, the 1st child could be a success, and the 2nd a failure (incorrect alleles),
                //Or the 2nd child could be a success, and the 1st child a failure.
                ulong numberOfCombinations =  GetBinCoeff(numberOfTrials, i);
                //The probability that a mating will result in a desired combination of alleles.
                double success = Math.Pow(probabilityOfSuccess, i);
                //The probability that a mating will result in an undesired combination of alleles.
                double failure = Math.Pow(probabilityOfFailure, numberOfTrials - i);
                //The probability that *exactly* i organisms have the desired traits.
                double prob = numberOfCombinations * success * failure;
                //Add this to a total, as we want the probability of a minimum number of organisms having a genotype. 
                //All values above minimumOffspring added together equal this probability.
                probability += prob;
            }
            return probability;
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
            uint[] values = lines[0].Split(' ').ToList().ConvertAll<uint>(s => uint.Parse(s)).ToArray();
            uint generations = values[0];
            uint minOffspring = values[1];

            Console.WriteLine(Math.Round(CalculateProbabilityOffspring(generations, minOffspring, 0.25),3).ToString("F99").TrimEnd('0'));
            Console.ReadLine();
        }
    }
}
