using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Computing_GC_Content
{

    class Program
    {
        public class FASTA
        {
            public string ID { get; set; }
            public string DNA { get; set; }
            public double _GCContent;
            public double GCContent { get { return _GCContent; } set { _GCContent = value; } }
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

        public static List<FASTA> DecodeFasta(string data)
        {
            List<FASTA> fastaList = new List<FASTA>();
            string[] splitData = data.Split('>');
            foreach (string item in splitData)
            {
                FASTA fasta = new FASTA();
                string[] temp = item.Split('\n');
                fasta.ID = temp[0];
            }
            return fastaList;
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
            string data = "";
            foreach (var line in lines)
            {
                 data += line;
            }

            DecodeFasta(data);

            FASTA dna = new FASTA();
            List<FASTA> fastaList = new List<FASTA>();
            foreach (string str in lines)
            {
                if (str.StartsWith(">"))
                {
                    fastaList.Add(dna);
                    dna = new FASTA();
                    dna.ID = str;
                }
                else
                {
                    dna.DNA += str;
                }
            }
            fastaList.RemoveAt(0); //Remove initial empty FASTA format DNA string
            fastaList.Add(dna); //Add last remaining.

            FASTA largestGCContent = new FASTA
            {
                GCContent = 0
            };

            foreach (var fasta in fastaList)
            {
                fasta.GCContent = CalculateGCContent(fasta.DNA);

                Console.WriteLine(fasta.ID);
                Console.WriteLine(fasta.GCContent * 100);

                if (fasta.GCContent > largestGCContent.GCContent)
                {
                    largestGCContent.GCContent = fasta.GCContent;
                    largestGCContent.ID = fasta.ID;
                }
            }


            Console.WriteLine(largestGCContent.ID.Remove(0,1)); //Remove '>' Character
            Console.WriteLine(largestGCContent.GCContent * 100);

            Console.ReadLine();
        }
    }
}
