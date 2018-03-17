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
        static long CalculateRecurrence(int months, int sizeOfLitter, long adult = 0, long litter = 1, int currentMonth = 1)
        {
            if (currentMonth == months)
            {
                return adult + litter;
            }
            else
            {
                long newLitter;
                long newAdults;
                int newMonth = currentMonth + 1;
                newAdults = adult + litter;
                newLitter = adult * sizeOfLitter;
                return CalculateRecurrence(months, sizeOfLitter, newAdults, newLitter, newMonth);

            }
        }

        //Interative/Dynamic solution (Should prevent any out of memory exceptions arising from a recursive solution
        static long CalculateRecurrenceDynamic(int months, int sizeOfLitter)
        {
            //long totalRabbits = 0;
            long adults = 0;
            long children = 1;

            for (int i = 0; i < months - 1; i++)
            {
                long oldAdults = adults;
                adults = oldAdults + children;
                children = oldAdults * sizeOfLitter;
            }
            return adults + children;
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


            int litter = 0;
            int months = 0;

            months = int.Parse(lines[0].Substring(0, lines[0].IndexOf(' ')));
            litter = int.Parse(lines[0].Substring(lines[0].IndexOf(' ')));

            Console.WriteLine(CalculateRecurrence(months, litter, 0));
            Console.WriteLine(CalculateRecurrence(30, 3));
            Console.WriteLine(CalculateRecurrenceDynamic(30, 3));
            Console.ReadLine(); 
        }
    }
}
