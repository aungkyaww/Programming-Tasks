using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Enumerating_Gene_Orders
{


    class Program
    {
        static bool NextLexicograhicalPermutation(ref int[] seq)
        {

            int i = seq.Length - 1;
            while (i > 0 && seq[i - 1] > seq[i])
                i--; //i head of suffix
                     // Console.WriteLine("Head of Suffix is: " + seq[i]);
                     // Console.WriteLine("Therefore pivot is: " + seq[i - 1]);

            if (i == 0) return false; //final permutation

            int pivot = seq[i - 1]; //pivot the left of the suffix header.

            int j = i;

            int swapValue = seq[j];
            int indexOfValue = j;
            while (j < seq.Length)
            {

                if (seq[j] >= pivot && seq[j] < swapValue)
                {
                    swapValue = seq[j];
                    indexOfValue = j;
                }


                j++;
            }

            //swap pivot and swapValue
            // Console.WriteLine("j: " + j + "\t i:" + i + "\tPivot:" + pivot + "\tswapValue: " + swapValue);
            seq[indexOfValue] = pivot;

            seq[i - 1] = swapValue;


            //reverse suffix i is suffix pointer
            j = seq.Length - 1;


            while (i < j)
            {

                int tempVal = seq[i];
                seq[i] = seq[j];
                seq[j] = tempVal;
                j--;
                i++;

            }

            return true;
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
            int integer = int.Parse(lines[0]);
            int[] arr = new int[integer];
            for (int i = 0; i < integer; i++)
            {
                arr[i] = i + 1;
            }
            int index = 0;

            List<string> strings = new List<string>
            {
                string.Join<int>(" ", arr)
            };
            index++;

            while (NextLexicograhicalPermutation(ref arr))
            {
                index++;
            strings.Add(string.Join<int>(" ", arr));

            }
             strings.Insert(0, index.ToString());

            File.WriteAllLines(strPath + @"\output.txt", strings);
        }
    }
}
