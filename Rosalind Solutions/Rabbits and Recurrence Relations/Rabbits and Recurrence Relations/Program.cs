using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rabbits_and_Recurrence_Relations
{


    class Program
    {
        //Recursive solution
        static int CalculateRecurrence(int months, int sizeOfLitter,  int adult, int litter, int currentMonth)
        {
            if (currentMonth == months)
            {
                return adult + litter;
            }
            else
            {
                int newLitter;
                int newAdults;
                int newMonth = currentMonth + 1;
                newAdults = adult + litter;
                newLitter = adult * sizeOfLitter;
                return CalculateRecurrence(months, sizeOfLitter, newAdults, newLitter, newMonth);
            
            }
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


            Console.WriteLine(CalculateRecurrence(5,3,0,1,1));
            Console.ReadLine();
        }
    }
}
