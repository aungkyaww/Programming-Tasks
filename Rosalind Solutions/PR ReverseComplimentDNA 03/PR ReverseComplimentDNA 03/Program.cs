using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PR_ReverseComplimentDNA_03
{


    class Program
    {
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
            chars = chars.Reverse<Char>().ToArray<Char>();
            return new string(chars);
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
            Console.WriteLine(ReverseCompliment(lines[0]));
            Console.ReadLine();
        }
    }
}
