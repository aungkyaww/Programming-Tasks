using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler32
{
    class Program
    {
        static HashSet<int> pandigitalSet = new HashSet<int>(); //Lazy

        static int[] NextLexicoPerm(int[] seq) //From ProjectEuler24
        {
            int i = seq.Length - 1;

            while (i > 0 && seq[i - 1] > seq[i])
                i--; //i head of suffix
                   
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

        static void CheckForPandigitalNumbers(int[] arr)
        {
            int multiplicand;
            int multiplier;
            int product;
            string digits = "";

            for (int i = 0; i < arr.Length; i++)
            {
                digits += arr[i].ToString();
            }
            for (int i = 1; i < digits.Length - 1; i++)
            {
                for (int j = i + 1; j < digits.Length - 1; j++)
                {
                    multiplicand = int.Parse(digits.Substring(0, i));
                    multiplier = int.Parse(digits.Substring(i, j - i));
                    product = int.Parse(digits.Substring(j));
                    if (multiplicand * multiplier == product)
                    {
                        if (pandigitalSet.Add(product)) //if the product doesn't already exist in the hashset (to stop any duplicates)
                        {
                            Console.Write("[{0}]", string.Join(", ", arr)); //To show progress in the console
                            Console.WriteLine("Added: " + product + "\tidentity is: " + multiplicand + " x " + multiplier + " = " + product);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int perms = 1;
            int permutationLoggingPoint = 10000; //Log every 10,000 permutations
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] endSeq = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int total = 0;
           
            CheckForPandigitalNumbers(arr); //First permutation is the array as it is, so need to call this once before going into the while loop

            while (!arr.SequenceEqual(endSeq))
            {
                arr = NextLexicoPerm(arr);
                perms++;
                if (perms == permutationLoggingPoint)
                {
                    Console.Write("Considered " + permutationLoggingPoint + " sets of digits. Current Number is: ");
                    Console.WriteLine("[{0}]", string.Join(", ", arr));
                    permutationLoggingPoint += 10000;
                }
                CheckForPandigitalNumbers(arr);
            }
            Console.WriteLine("Starting Summation------------------------");
            foreach (var value in pandigitalSet)
            {
                total += value;
            }

            Console.WriteLine("Sum of products is: " + total);
            Console.ReadLine();
        }
    }
}
