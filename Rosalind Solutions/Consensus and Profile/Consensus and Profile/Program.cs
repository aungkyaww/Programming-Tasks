using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Consensus_and_Profile
{


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



            Console.ReadLine();
        }
    }
}
