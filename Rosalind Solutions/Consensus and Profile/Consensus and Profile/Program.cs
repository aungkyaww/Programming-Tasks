using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Rosalind.Utils;

namespace Consensus_and_Profile
{

    class ProfileMatrix
    {
        public int[,] Matrix { get; set; }
        public string ConsensusString { get; set; }
        public char[] ProfileHeadings { get; set; }
        private int _numberOfUniqueCharacters;


        private void DeriveProfileHeaders(string[] stringCollection)
        {
            List<char> uniqueCharacters = new List<char>();
            for (int i = 0; i < stringCollection.Length; i++)
            {
                for (int j = 0; j < stringCollection[0].Length; j++)
                {
                    if (!uniqueCharacters.Contains(stringCollection[i][j]))
                    {
                        _numberOfUniqueCharacters++;
                        uniqueCharacters.Add(stringCollection[i][j]);
                    }
                }
            }
            uniqueCharacters.Sort((a, b) => (a.CompareTo(b)));
            ProfileHeadings = uniqueCharacters.ToArray();
        }

        private void CalculateConsensusString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                int highestOccurence = 0;
                int index = -1;
                for (int j = 0; j < ProfileHeadings.Length; j++)
                {
                    if (Matrix[j, i] > highestOccurence)
                    {
                        highestOccurence = Matrix[j, i];
                        index = j;
                    }
                }
                sb.Append(ProfileHeadings[index]);
            }
            ConsensusString = sb.ToString();
        }

        public ProfileMatrix(string[] stringCollection)
        {

            DeriveProfileHeaders(stringCollection);
            //Dictionary<char, int> blankDictionary = headings.ToDictionary(key => key, value => 0);
            int[,] _matrix = new int[stringCollection.Length, stringCollection[0].Length];

            for (int i = 0; i < stringCollection.Length; i++)
            {
                for (int j = 0; j < stringCollection[0].Length; j++)
                {
                    _matrix[Array.IndexOf(ProfileHeadings,stringCollection[i][j]), j]++;
                }
            }
            Matrix = _matrix;
            CalculateConsensusString();
        }

        public static void OutputProfileMatrix(ProfileMatrix matrix, bool align = true)
        {
            if (matrix.ProfileHeadings == null)
            {
                Console.WriteLine("Cannot output Matrix: No headings available.");
            }
            else
            {
                char[] headers = matrix.ProfileHeadings;
                int[,] profileMatrix = matrix.Matrix;
                int maxPadding = 3;
                if (align)
                {
                    maxPadding = 2;
                    for (int i = 0; i < profileMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < profileMatrix.GetLength(1); j++)
                        {
                            if (profileMatrix[i, j].ToString().Length > maxPadding)
                            {
                                maxPadding = profileMatrix[i, j].ToString().Length;
                            }
                        }
                    }
                }

                for (int i = 0; i < matrix.ProfileHeadings.Length; i++)
                {
                    Console.Write("{0}: ", matrix.ProfileHeadings[i]);
                    for (int j = 0; j < profileMatrix.GetLength(1); j++)
                    {
                        Console.Write(profileMatrix[i, j].ToString().PadRight(maxPadding));
                    }
                    Console.WriteLine();
                }

            }
        }

    }


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
            string[] strings = new string[fastaList.Count];
            for (int i = 0; i < fastaList.Count; i++)
            {
                strings[i] = fastaList[i].DNA;
            }

            ProfileMatrix matrix = new ProfileMatrix(strings);

            Console.WriteLine(matrix.ConsensusString);
            ProfileMatrix.OutputProfileMatrix(matrix);

            Console.ReadLine();
        }
    }
}
