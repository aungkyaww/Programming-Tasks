using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mortal_Fibonacci_Rabbits
{


    class Program
    {

         static long CalculateRecurrenceMortal(int months, int sizeOfLitter, int lifespan)
        {
            //Relationship is: Fn = F(n - 1) + F(n - 2) - F(n - lifespan)
     
            long adults = 0;
            long children = 1;
            //Setting children to 1 starts at month 1
            List<long> lifespanTracker = new List<long>();

            for (int i = 1; i < months; i++)
            {
                lifespanTracker.Add(children);

                long oldAdults = adults;
                long growingChildren = children;

                children = oldAdults * sizeOfLitter;
                adults = oldAdults + growingChildren;

                if (i >= lifespan)
                {
                    adults = adults - lifespanTracker[0];
                    lifespanTracker.RemoveAt(0);
                }

            }
            return adults + children;
        }

        static void Main(string[] args)
        {
            //string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //string[] files = Directory.GetFiles(strPath + @"\Rosalind", "*.txt"); //Assumes only one txt file in this directory - the data set
            //string[] lines = { "" };
            //foreach (string file in files)
            //{
            //    lines = File.ReadAllLines(file);
            //}
            Console.WriteLine(CalculateRecurrenceMortal(86, 1, 20));
            Console.ReadLine();
        }
    }
}
