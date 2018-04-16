using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Rosalind.Utils;

namespace Overlap_Graphs
{

    class Program
    {

        public static List<string> CalculateAdjacencyList((string id, string node)[] nodes, int overlap)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            List<string> adjacencyList = new List<string>();

            //build a list of end nodes for each unique end node pattern (e.g AAA, BBB, ACG etc)
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!dictionary.ContainsKey(nodes[i].node.Substring(0, overlap)))
                {
                    dictionary.Add(nodes[i].node.Substring(0, overlap), new List<string>());
                    dictionary[nodes[i].node.Substring(0, overlap)].Add(nodes[i].id);
                }
                else
                {
                    dictionary[nodes[i].node.Substring(0, overlap)].Add(nodes[i].id);
                }
            }

            //For each list of end nodes in the dictionary, if the end node != start node, add start and end node to adjacency list (edge).
            for (int i = 0; i < nodes.Length; i++)
            {
                if (dictionary.ContainsKey(nodes[i].node.Substring(nodes[i].node.Length - overlap)))
                {
                    foreach (string s in dictionary[nodes[i].node.Substring(nodes[i].node.Length - overlap)])
                    {
                        if (nodes[i].id != s)
                        {
                            adjacencyList.Add(nodes[i].id.Substring(1) + " " + s.Substring(1));
                        }

                    }
                }
            }
            return adjacencyList;
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
            List<Fasta> fastaList = Fasta.DecodeFasta(lines);
            (string id, string node)[] nodes = new (string id, string edge)[fastaList.Count] ;
            for (int i = 0;i < nodes.Length; i++)
            {
                nodes[i].node = fastaList[i].DNA;
                nodes[i].id = fastaList[i].ID;
            }
            List<string> adjancencyList = CalculateAdjacencyList(nodes, 3);
            adjancencyList.ForEach(s => Console.WriteLine(s));
            Console.ReadLine();
        }
    }
}
