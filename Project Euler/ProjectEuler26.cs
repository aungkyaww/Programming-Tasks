using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler26ReciprocalCycles
{
    class Program
    {
        static void Main(string[] args)
        {
            int longestLength = 0;
            for (int i = 8; i < 1000; i++)
            {
                int[] foundRemainders = new int[i];
                int value = 1;
                int position = 0;

                while (foundRemainders[value] == 0 && value != 0)
                {
                    foundRemainders[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if (position - foundRemainders[value] > longestLength)
                {
                    longestLength = position - foundRemainders[value];
                    Console.WriteLine("Found new value for: 1/" + i + " at a length of " + longestLength);
                    
                }

            }
            Console.ReadLine(); 
        }
    }
}
