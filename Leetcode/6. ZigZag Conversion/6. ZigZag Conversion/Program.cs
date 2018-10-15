using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.ZigZag_Conversion
{
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            StringBuilder finalString = new StringBuilder();
            if (numRows <= 1)
            {
                return s;
            }
            // ABCDEFG
            // 
            // ACEG
            // BDF
            if (numRows == 2)
            {
               
                for (int i = 0; i < s.Length; i+=2)
                {
                    finalString.Append(s[i]);
                }
                for (int i = 1; i < s.Length; i+=2)
                {
                    finalString.Append(s[i]);
                }
                return finalString.ToString();
            }

            int spaceBetweenRows = numRows - 2;
            int j = 0;
            int currentRow = 0;
            int currentColumn = 0;
            bool onDiagonal = false;
            List<char[]> matrix = new List<char[]>
            {
                new char[numRows]
            };

            while (j < s.Length)
            {
                if (!onDiagonal)
                {
                    if (currentRow < numRows)
                    {
                        matrix[currentColumn][currentRow] = s[j];
                        currentRow++;
                        j++;
                    }
                    else
                    {
                        onDiagonal = true;
                        currentColumn++;
                        currentRow-=2;
                        matrix.Add(new char[numRows]); //And add a new column
                    }
                }
                if (onDiagonal) {
                    if (currentRow > 0)
                    {
                        matrix[currentColumn][currentRow] = s[j];
                        j++;
                        currentRow--;
                    }
                    else
                    {
                        onDiagonal = false;
                        currentColumn++;
                        matrix.Add(new char[numRows]); //And add a new column
                    }
                }
            }

            for (int i = 0; i < matrix[0].Length; i++)
            {
                for (int k = 0; k < matrix.Count; k++)
                {
                    finalString.Append((matrix[k][i] == '\0' ? "" : matrix[k][i].ToString()));
                }
            }

            return finalString.ToString();
        }

        public void PrintMatrix(List<char[]> list)
        {
            for (int i = 0; i < list[0].Length; i++)
            {
                Console.WriteLine();
                for (int k = 0; k < list.Count; k++)
                {
                    //Console.Write(list[k][i] + " | " + k + " " + i);
                    Console.Write((list[k][i] == '\0' ? ' ' : list[k][i]) + " ");
                }
            }
            Console.WriteLine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.Convert("PAYPALISHIRING", 3));
            Console.ReadLine();
        }
    }

}