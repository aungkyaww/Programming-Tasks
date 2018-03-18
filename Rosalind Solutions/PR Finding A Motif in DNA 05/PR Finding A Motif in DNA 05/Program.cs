using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PR_Finding_A_Motif_in_DNA_05
{


    class Program
    {
        private static bool MatchSubstring(char[] mainString, char[] substring)
        {
            int reverseIndex = mainString.Length - 1;
            bool match = true;

            for (int i = 0; i < mainString.Length; i++)
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

        public static string FindMotif(string mainString, string substring)
        {
            char[] main = mainString.ToCharArray();
            char[] sub = substring.ToCharArray();

            string finalString = "";

            for (int i = 0; i < main.Length - sub.Length; i++)
            {
                //If first letters match
                if (main[i] == sub[0])
                {
                    //Deal with edge case
                    if (sub.Length == 1)
                    {
                        finalString += (i + 1).ToString();
                    }
                    else
                    {
                        //Deal with other edge case
                        if (sub.Length == 2)
                        {
                            finalString += (i + 1);
                        }
                        else
                        {
                            //If last letters match
                            if (main[i + sub.Length - 1] == sub[sub.Length - 1])
                            {
                                finalString += MatchSubstring(new ArraySegment<Char>(main, i, sub.Length).ToArray<Char>(), sub) ? (i + 1).ToString() + " " : "";
                            }
                        }

                    }
                }
            }
            return finalString;

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

            Console.WriteLine(FindMotif(lines[0], lines[1]));
            Console.ReadLine();
        }
    }
}
