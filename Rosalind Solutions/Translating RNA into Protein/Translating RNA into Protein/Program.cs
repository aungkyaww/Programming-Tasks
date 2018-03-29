using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Translating_RNA_into_Protein
{


    class Program
    {
        private static Dictionary<string, char> codonTable = new Dictionary<string, char>() {
            {"UUU", 'F'}, {"CUU", 'L'}, {"AUU", 'I'}, {"GUU", 'V'}, {"UUC", 'F'}, {"CUC", 'L'}, {"AUC", 'I'},
            {"GUC", 'V'}, {"UUA", 'L'}, {"CUA", 'L'}, {"AUA", 'I'}, {"GUA", 'V'}, {"UUG", 'L'}, {"CUG", 'L'},
            {"AUG", 'M'}, {"GUG", 'V'}, {"UCU", 'S'}, {"CCU", 'P'}, {"ACU", 'T'}, {"GCU", 'A'}, {"UCC", 'S'},
            {"CCC", 'P'}, {"ACC", 'T'}, {"GCC", 'A'}, {"UCA", 'S'}, {"CCA", 'P'}, {"ACA", 'T'}, {"GCA", 'A'},
            {"UCG", 'S'}, {"CCG", 'P'}, {"ACG", 'T'}, {"GCG", 'A'}, {"UAU", 'Y'}, {"CAU", 'H'}, {"AAU", 'N'},
            {"GAU", 'D'}, {"UAC", 'Y'}, {"CAC", 'H'}, {"AAC", 'N'}, {"GAC", 'D'}, {"UAA", '.'}, {"CAA", 'Q'},
            {"AAA", 'K'}, {"GAA", 'E'}, {"UAG", '.'}, {"CAG", 'Q'}, {"AAG", 'K'}, {"GAG", 'E'}, {"UGU", 'C'},
            {"CGU", 'R'}, {"AGU", 'S'}, {"GGU", 'G'}, {"UGC", 'C'}, {"CGC", 'R'}, {"AGC", 'S'}, {"GGC", 'G'},
            {"UGA", '.'}, {"CGA", 'R'}, {"AGA", 'R'}, {"GGA", 'G'}, {"UGG", 'W'}, {"CGG", 'R'}, {"AGG", 'R'},
            {"GGG", 'G'}
        };

        public static string ComputeProtein(string dna)
        {
            char[] dnaChars = dna.ToCharArray();
            List<char> protein = new List<char>();

            for (int i = 0; i < dnaChars.Length; i += 3)
            {
                string key = new string(dnaChars, i, 3);
                char aminoAcid = codonTable[key];
                if (aminoAcid == '.')
                {
                    break;
                }
                else
                {
                    protein.Add(aminoAcid);
                }
            }
            return new string(protein.ToArray());
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


            Console.WriteLine(ComputeProtein(lines[0]));
            Console.ReadLine();
        }
    }
}
