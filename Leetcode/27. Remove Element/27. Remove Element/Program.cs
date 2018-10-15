using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace _27.Remove_Element
{
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            int removed = nums.Length;
            int index = nums.Length - 1;
            int i = 0;

            if (nums.Length == 1)
            {
               return nums[0] == val ? 0 : 1;

            }

            while (i <= index)
            {
                if (nums[i] == val)
                {
                    
                    while (index > 0 && index < nums.Length && nums[index] == val)
                    {
                        index--;
                        removed--;
                    }
                    if (index >= 0 && index < nums.Length && i <= index)
                    {
                       nums[i] = nums[index];
                        index--;
                        removed--;
                    }
                   
                }
                i++;
            }
            return removed;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.RemoveElement(new int[] {3,2,2 }, 3));
            Console.WriteLine(solution.RemoveElement(new int[] { 3, 2,2,3 }, 3));
            Console.WriteLine(solution.RemoveElement(new int[] { 2,2,3,3 }, 3));
            Console.WriteLine(solution.RemoveElement(new int[] { 3, 3 }, 3));
            Console.WriteLine(solution.RemoveElement(new int[] { 3}, 3));
            Console.WriteLine(solution.RemoveElement(new int[] { 2, 3  }, 3));
            Console.WriteLine(solution.RemoveElement(new int[] { 1,2,3,4,5,6,7,8 }, 9));
            Console.ReadLine();
        }
    }
}
