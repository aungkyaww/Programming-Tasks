using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Rosalind.Utils
{
    public static class Constants
    {
        //. = STOP, @ = START
        public static Dictionary<string, char> CodonTable = new Dictionary<string, char>() {
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

        public static Dictionary<char, double> MonoisotopicMassTable = new Dictionary<char, double>() {
            {'A', 71.03711}, {'C',103.00919}, {'D',115.02694}, {'E',129.04259}, {'F',147.06841},
            {'G',57.02146}, {'H',137.05891}, {'I',113.08406}, {'K',128.09496}, {'L',113.08406},
            {'M',131.04049}, {'N',114.04293}, {'P',97.05276}, {'Q',128.05858}, {'R',156.10111},
            {'S',87.03203}, {'T',101.04768}, {'V',99.06841}, {'W',186.07931}, {'Y',163.06333}
        };
    }
    public class Fasta
    {
        public string ID { get; set; }
        public string DNA { get; set; }


        public double GCContent { get; private set; }

        public Fasta(string id, string dna)
        {
            DNA = dna;
            ID = id;
        }

        private Fasta(string id)
        {
            ID = id;
        }

        private Fasta()
        {

        }

        public double CalculateGCContent()
        {
            char[] dnaChars = DNA.ToCharArray();
            int totalGC = 0;

            for (int i = 0; i < dnaChars.Length; i++)
            {
                if (dnaChars[i] == 'G' || dnaChars[i] == 'C')
                {
                    totalGC++;
                }
            }
            return (double)totalGC / (double)dnaChars.Length;
        }


        public static double CalculateGCContent(string DNA)
        {
            char[] dnaChars = DNA.ToCharArray();
            int totalGC = 0;

            for (int i = 0; i < dnaChars.Length; i++)
            {
                if (dnaChars[i] == 'G' || dnaChars[i] == 'C')
                {
                    totalGC++;
                }
            }
            return (double)totalGC / (double)dnaChars.Length;
        }

        public static int count;

        public static List<Fasta> DecodeFasta(string[] lines)
        {
            count++;
            List<Fasta> fastaList = new List<Fasta>();
            Fasta fasta = new Fasta();
            foreach (string line in lines)
            {
                if (line.StartsWith(">"))
                {
                    fasta = new Fasta(line);
                    fasta.ID = line;
                    fastaList.Add(fasta);
                }
                else
                {
                    fastaList.Last().DNA += line;
                }
            }
            return fastaList;
        }


    }
    public static class StringUtils
    {
        public static bool MatchSubstring(char[] mainString, char[] substring)
        {
            int reverseIndex = mainString.Length - 1;
            bool match = true;

            for (int i = 0; i < (mainString.Length / 2) + 1; i++)
            {
                if (mainString[i] != substring[i])
                {
                    match = false;
                    break;
                }
                if (mainString[reverseIndex] != substring[reverseIndex])
                {
                    match = false;
                    break;
                }
                reverseIndex--;
            }

            return match;
        }

        public static string ReverseCompliment(string dnaString)
        {
            char[] chars = dnaString.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case 'A': chars[i] = 'T'; break;
                    case 'C': chars[i] = 'G'; break;
                    case 'T': chars[i] = 'A'; break;
                    case 'G': chars[i] = 'C'; break;
                }
            }
            chars = chars.Reverse().ToArray();
            return new string(chars);
        }

        public static string ComputeProtein(string rna)
        {
            char[] rnaChars = rna.ToCharArray();
            List<char> protein = new List<char>();

            for (int i = 0; i < rnaChars.Length; i += 3)
            {
                string key = new string(rnaChars, i, 3);
                char aminoAcid = Constants.CodonTable[key];
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

    }


}
