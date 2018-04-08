using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Rosalind.Utils;
using System.Net;
using System.Text.RegularExpressions;

namespace Finding_a_Protein_Motif
{
    class Program
    {
        public static string MakeGetRequest(string url)
        {
            string text = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
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

            Regex regex = new Regex(@"N[^P][ST][^P]", RegexOptions.Multiline);

            string url = @"http://www.uniprot.org/uniprot/";
            List<(string id, int[] positions)> tuples = new List<(string id, int[] positions)>();
            foreach (string protein in lines)
            {
                List<int> positions = new List<int>();
                (string id, int[] positions) tuple;
                tuple.id = protein;
                string html = MakeGetRequest(url + protein + ".fasta");
                Fasta fasta = Fasta.DecodeFasta(html.Split('\n'))[0];
                for (int i = 0; i < fasta.DNA.Length - 4; i++)
                {
                    if (regex.IsMatch(fasta.DNA.Substring(i, 4)))
                    {
                        positions.Add(i + 1);
                    }
                }
                if (positions.Count != 0)
                {
                    tuple.positions = positions.ToArray();
                    tuples.Add(tuple);
                }
            }


            for (int i = 0; i < tuples.Count; i++)
            {
                if (tuples[i].positions.Length != 0)
                {
                    Console.WriteLine(tuples[i].id);
                    tuples[i].positions.ToList().ForEach(s => Console.Write(s + " "));
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
