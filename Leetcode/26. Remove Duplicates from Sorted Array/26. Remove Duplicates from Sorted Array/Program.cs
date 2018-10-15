using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _26.Remove_Duplicates_from_Sorted_Array
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            else if (nums.Length == 1)
            {
                return 1;
            }

            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[count++] = nums[i];
                }
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.RemoveDuplicates(new int[] { 1, 2 }));
            Console.WriteLine(solution.RemoveDuplicates(new int[] { 1, 1, 1, 2, 3, 4 }));
            Console.WriteLine(solution.RemoveDuplicates(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
            Console.WriteLine(solution.RemoveDuplicates(new int[] { 1,1}));
            Console.ReadLine();
        }
    }
}
