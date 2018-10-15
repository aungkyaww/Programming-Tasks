using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _15._3Sum
{
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums, (a, b) => a.CompareTo(b));
            int n = nums.Length;

            List<IList<int>> solutions = new List<IList<int>>();
            HashSet<string> hs = new HashSet<string>(); //used to ensure only a set of unique triplets is returned -  { -1, 0, 1, 2, -1, -4 } would give [[-1,-1,2],[-1,0,1],[-1,0,1]] without this check

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1, k = n - 1;
                int a = nums[i];
                while (j < k)
                {
                    int b = nums[j], c = nums[k];
                    if (a + b + c == 0)
                    {
                        if (!hs.Contains(a.ToString() + b.ToString() + c.ToString()))
                        {
                            solutions.Add(new List<int>() { a, b, c });
                            hs.Add(a.ToString() + b.ToString() + c.ToString());
                        }
                        j++;
                        k--;
                    }
                    else if (a + b + c > 0)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            return solutions;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 }).ToList().ForEach(a => a.ToList().ForEach(b => Console.WriteLine(b)));
            solution.ThreeSum(new int[] { });
            solution.ThreeSum(new int[] { 1, 0, -1 });
            solution.ThreeSum(new int[] { 1 });
            solution.ThreeSum(new int[] { 1, -1 });
            Console.ReadLine();
        }
    }
}
