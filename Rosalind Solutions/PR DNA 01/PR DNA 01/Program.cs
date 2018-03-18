using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PR_DNA_01
{
  
    class Program
    {
       static string FindRepetitions(string dnaString)
    {
        char[] chars = dnaString.ToCharArray();
        int base1 = 0;
        int base2 = 0;
        int base3 = 0;
        int base4 = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            switch (chars[i])
            {
                case 'A': base1++; break;
                case 'C': base2++; break;
                case 'G': base3++; break;
                case 'T': base4++; break;
            }
        }
        return base1 + " " + base2 + " " + base3 + " " + base4;
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

            List<string> output = new List<string>();

            foreach (string line in lines)
            {
                string repeats = FindRepetitions(line);
                output.Add(repeats);
                Console.WriteLine(repeats);
            }
            File.WriteAllLines(@"C:\Users\Jake Yallop\Desktop\output.txt", output);

            Console.ReadLine();
        }
    }
}
