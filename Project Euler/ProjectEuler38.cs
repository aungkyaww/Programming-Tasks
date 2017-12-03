using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProjectEuler38
{
    class Program
    {
        public static bool Duplicates(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if ((i != j) && (s[i] == s[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static string Pandigital(int n) //My worst "solution"... Definitely want to come back to this one
            //This solution is not very efficient or smooth at all.
        {
            char[] buffer = new char[9]; //store 1 - 9
            int limit = (9 / n.ToString().Length);
            if (limit == 0)
            {
                return "";
            }
            int num = 0;
            int index = 0;
            string final = "";
            for (int j = 1; j <= limit; j++)
            {
                if (index == 9)
                {
                    break;
                }
                num = j * n;
                string str = num.ToString();
                if (Duplicates(str))
                {
                    return "";
                }

                for (int k = 0; k < index; k++)
                {
                    for (int h = 0; h < str.Length; h++)
                    {
                        if (str[h] == 48)
                        {
                            return "";
                        }
                        if (k > 8)
                        {
                            return "";
                        }
                        if (buffer[k] == str[h])
                        {

                            return "";
                        }
                    }
                }
                int digit = 0;
                for (int k = index; k < (index + str.Length); k++)
                {


                    if (k > 8)
                    {
                        break;
                    }
                    if (buffer[k] == str[digit])
                    {
                        return "";
                    }
                    if (str[digit] == 48)
                    {
                        return "";
                    }
                    buffer[k] = str[digit];
                    digit++;
                }
                
                
                index += str.Length;
                final += str;
            }
            if (final.Length != 9)
            {
                return "";
            }
            return final;
        }

        static void Main(string[] args)
        {
            int limit = 500000000;
            int largest = 0;
            for (int i = 1; i < limit; i++)
            {
                string str = Pandigital(i);
                if (str.Length != 0)
                {
                    if (int.Parse(str) > largest)
                    {
                        largest = int.Parse(str);
                        Console.WriteLine("Found new Pandigital: " + largest);
                    }
                }
            }
            Console.ReadLine();
        }
    }

}


