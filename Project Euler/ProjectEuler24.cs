using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler24
{
    class Program
    {
        static int[] nextLexicoPerm(int[] seq)
        {

            int i = seq.Length - 1;
            while (i > 0 && seq[i - 1] > seq[i])
                i--; //i head of suffix
           // Console.WriteLine("Head of Suffix is: " + seq[i]);
           // Console.WriteLine("Therefore pivot is: " + seq[i - 1]);

            if (i == 0) return seq; //final permutation

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
            
            return seq;
        }
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("[{0}]", string.Join(", ", arr));
            for (int i = 1; i <= 999998; i++)
            {
                arr = nextLexicoPerm(arr);
             //   Console.WriteLine("[{0}]", string.Join(", ", arr));
            }
            arr = nextLexicoPerm(arr);
            Console.Write("1000000: ");
            Console.WriteLine("[{0}]", string.Join(", ", arr));
            arr = nextLexicoPerm(arr);
            Console.Write("1000001: ");
            Console.WriteLine("[{0}]", string.Join(", ", arr));
            arr = nextLexicoPerm(arr);
            Console.Write("1000002: ");
            Console.WriteLine("[{0}]", string.Join(", ", arr));
            //Console.WriteLine("[{0}]", string.Join(", ", arr));

            Console.ReadLine();
        }
    }
}
