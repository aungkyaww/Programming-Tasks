using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////////////////////////////////////////////////////////////////////////////
//Compile with XML Documentation Comments enabled to see comments in IntelliSense menu             
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments
//////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Utils.ArrayUtils
{/// <summary>
/// A collection of utilities for Arrays.
/// </summary>
    public static class ArrayUtils
    {
        /// <summary>
        /// Fills a specified array with a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="value">The value to fill the array with</param>
        public static void Fill<T>(this T[] arr, T value)
        {

            for (int i = 0; i < arr.Length; i++)
            {

                arr[i] = value;
            }
        }
        /// <summary>
        /// Prints an array to console.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>

        public static void printArray<T>(this T[] arr) //Concatenation faster than calling Console.write multiple times.
        {
            if (arr.Length == 0)
            {
                //do nothing
            }
            else
            {
                int max = arr.Length - 1;
                int i = 0;
                string final = "[";
                foreach (T item in arr)
                {
                    if (i == max) //final iteration
                    {
                        final += item.ToString() + "]";
                    }
                    else
                    {
                        final += item.ToString() + ", ";
                    }
                    i++;
                }
                Console.WriteLine(final);
            }

        }

    }
}
