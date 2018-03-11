using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler33
{
    class Program
    {
        static int finalNumerator = 1;
        static int finalDenom = 1;
        static int gcd(int a, int b)
        {
            int temp = 0;
            if (b > a)
            {
                temp = b;
                b = a;
                a = temp;
            }
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;

            }
            return a;
        }

        static void Main(string[] args)
        {
           
            for (int i = 1;  i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 1; k < 10; k++)
                    {
                        for (int h = 0; h < 10; h++)
                        {
                            if(i == h)
                            {
                                int num = int.Parse(i.ToString() + j.ToString());
                                int denom = int.Parse(k.ToString() + h.ToString());
                                if (((float)num / denom == (float)j / k) && (j != 0 || k != 0) && ((float)num/denom < 1))
                                {
                                    Console.WriteLine("Found non-trivial: " + num + "/" + denom);
                                    finalNumerator *= num;
                                    finalDenom *= denom;
                                }


                            }
                            if(j == k)
                            {
                                int num = int.Parse(i.ToString() + j.ToString());
                                int denom = int.Parse(k.ToString() + h.ToString());
                                if (((float)num / denom == (float)i / h) && (i != 0 || h != 0) && ((float)num / denom < 1))
                                {
                                    Console.WriteLine("Found non-trivial: " + num + "/" + denom);
                                    finalNumerator *= num;
                                    finalDenom *= denom;
                                }
                            }
                        }
                    }
                }
            }

            string fraction = "";
            int greatestCommon = gcd(finalNumerator, finalDenom);

            fraction = (finalNumerator / greatestCommon).ToString() + "/" + (finalDenom / greatestCommon).ToString();
            Console.WriteLine("finished finding solutiuons, calculating simplified fraction...");
            
            Console.WriteLine("Final Simplified fraction is " + fraction);

            Console.ReadLine();
        }
    }
}
