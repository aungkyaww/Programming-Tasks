using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PR_Hamming_Distance_04
{


    class Program
    {
        public static int CalculatingHammingDistance(string str1, string str2)
        {
            char[] chars1 = str1.ToCharArray();
            char[] chars2 = str2.ToCharArray();

            int hammingDistance = 0;

            for (int i = 0; i < chars1.Length; i++)
            {
                if (chars1[i] != chars2[i])
                {
                    hammingDistance++;
                }
            }


            return hammingDistance;
        }

        static void Main(string[] args)
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string[] files = Directory.GetFiles(strPath + @"\Rosalind\", "*.txt");
            string[] lines = { "" };
            foreach (string file in files)
            {
                lines = File.ReadAllLines(file);
            }
            Console.WriteLine(CalculatingHammingDistance(lines[0], lines[1]));
            Console.ReadLine();
        }
    }
}
