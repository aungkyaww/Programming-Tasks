using System;

namespace _4._Median_of_Two_Sorted_Arrays
{
    class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //Calculate mid point
            //If mid point is even, take result of ([mid] + [mid + 1])/2
            //Write a merge
            //Keep count of element number.
            //Once mid point reached, return result

            int midpoint = (int)Math.Ceiling((double)(nums1.Length + nums2.Length) / 2);
            bool isEven = (nums1.Length + nums2.Length) % 2 == 0;
            //begin merge

            int i = 0, j = 0;

            int num1 = int.MaxValue, num2 = int.MaxValue, total = 0;

            if (midpoint == 1 && nums1.Length + nums2.Length < 2)
            {
                if (nums1.Length == 0)
                {
                    return nums2[0];
                }
                else
                {
                    return nums1[0];
                }
            }

            while (i < nums1.Length || j < nums2.Length)
            {

                if (total + 1 == midpoint)
                {
                    if (i < nums1.Length && j < nums2.Length)
                    {
                        if (isEven)
                        {
                            if (nums1[i] < nums2[j])
                            {
                                if (i + 1 < nums1.Length && nums1[i + 1] < nums2[j])
                                {
                                    return ((double)nums1[i] + nums1[i + 1]) / 2;
                                }
                                else
                                {
                                    return ((double)nums1[i] + nums2[j]) / 2;
                                }
                            }
                            else
                            {
                                if (j + 1 < nums2.Length && nums2[j + 1] < nums1[i])
                                {
                                    return ((double)nums2[j] + nums2[j + 1]) / 2;
                                }
                                else
                                {
                                    return ((double)nums2[j] + nums1[i]) / 2;
                                }
                            }
                        }
                        else
                        {
                            if (nums1[i] < nums2[j])
                            {
                                return nums1[i];
                            }
                            else
                            {
                                return nums2[j];
                            }
                        }
                    }
                    else
                    {
                        if (i < nums1.Length)
                        {
                            if (isEven)
                            {
                                return ((double)nums1[i] + nums1[i + 1]) / 2;
                            }
                            else
                            {
                                return nums1[i];
                            }
                        }
                        else
                        {
                            if (isEven)
                            {
                                return ((double)nums2[j] + nums2[j + 1]) / 2;
                            }
                            else
                            {
                                return nums2[j];
                            }
                        }

                    }
                }

                //"Merge" - increment indexes, don't actually copy to a new array

                //Avoid any indexing errors, but keep the older (smaller) value in case of unbalanced array lengths.
                if (i < nums1.Length)
                {
                    num1 = nums1[i];
                }

                if (j < nums2.Length)
                {
                    num2 = nums2[j];
                }

                if (num1 < num2 && i < nums1.Length)
                {
                    i++;
                }
                else if (num2 < num1 && j < nums2.Length)
                {
                    j++;
                }
                //Increment which ever index won't be out of bounds
                else if (i < nums1.Length)
                {
                    i++;
                }
                else
                {
                    j++;
                }
                total++;
            }



            return midpoint;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.FindMedianSortedArrays(new int[] { 1}, new int[] {2, 3, 4, 5 }));
            Console.ReadLine();
        }
    }
}
