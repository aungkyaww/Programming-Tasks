using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace _16._3Sum_Closest
{
    public class Solution
    {

        //Adapted from ThreeSum problem, not the most efficient
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums, (a, b) => a.CompareTo(b));
            int currentClosest = int.MaxValue;
            int currentSum = 0;
            

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1, k = nums.Length - 1;
                int a = nums[i];
                while (j < k)
                {
                    int b = nums[j], c = nums[k];
                    if (Math.Abs((a + b + c) - target) < currentClosest)
                    {
                        if (a + b + c == target)
                            return a + b + c;
                        else
                        {
                            currentClosest = Math.Abs((a + b + c) - target);
                            currentSum = a + b + c;
                        }
                    }
                    else if (a + b + c > target)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            return currentSum;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine( solution.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1));
            Console.ReadLine();
        }
    }
}
