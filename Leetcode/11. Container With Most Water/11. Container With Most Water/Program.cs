using System;

namespace _11.Container_With_Most_Water
{
    public class Solution
    {
        //n > 2
        public int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int max = 0;
            while (i != j)
            {
                var curr = (j - i) * Math.Min(height[i], height[j]);
                if (curr > max)
                {
                    max = curr;
                }

                if (height[i] > height[j])
                {
                    j--;
                }
                else
                {
                    i++;
                }

            }
            return max;

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.MaxArea(new int[]{ 1, 8, 6, 2, 5, 4, 8, 3, 7}));
            Console.ReadLine();
        }
    }
}
