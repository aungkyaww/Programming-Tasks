using System;

namespace _8.String_to_Integer__atoi_
{
    public class Solution
    {
        public int MyAtoi(string str)
        {
            int sign = 1;
            int i = 0;
            str = str.Trim();
            if (str.Length == 0)
            {
                return 0;
            }
            if (str[0] == '-')
            {
                //Negative value
                sign = -1;
                i++;
            }
            else
            {
                if (!(str[0] >= 48 && str[0] <= 57) && str[0] != 43) //0-9 or +
                {
                    return 0;
                }
                else if ((str[0] >= 48 && str[0] <= 57)) //0-9
                {
                    sign = 1;
                }
                else //+
                {
                    sign = 1;
                    i++;
                }
            }
            long result = 0;
            unchecked
            {
                {
                    for (; i < str.Length; i++)
                    {
                        if (!(str[i] >= 48 && str[i] <= 57))
                        {
                            return (int)result * sign;
                        }
                        else 
                        {
                            if ((result * 10) + (str[i] - 48) > int.MaxValue)
                            {
                                if (sign == 1)
                                    return int.MaxValue;
                                else
                                    return int.MinValue;
                            }
                            else
                            {
                                result = (result * 10) + (str[i] - 48);
                            }

                        }
                    }

                    return (int)result * sign;
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.MyAtoi("   +2145 with some words   "));
            Console.WriteLine(solution.MyAtoi("2147483646")); //2147483646
            Console.WriteLine(solution.MyAtoi("2147483648")); //Int.MaxValue
            Console.WriteLine(solution.MyAtoi("-91283472332")); //-2147483648
            Console.WriteLine(solution.MyAtoi((int.MaxValue.ToString() + "1")));
            Console.WriteLine(solution.MyAtoi("-120837102309120938"));
            Console.ReadLine();
        }
    }
}
