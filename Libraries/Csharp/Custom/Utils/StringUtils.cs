using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////////////////////////////////////////////////////////////////////////////
//Compile with XML Documentation Comments enabled to see comments in IntelliSense menu             
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments
//////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Utils.StringUtils
{
    /// <summary>
    /// Contains extenstion methods for string handling
    /// </summary>
    public static class StringExtensions
    {/// <summary>
     /// Reverses a string.
     /// </summary>
     /// <param name="str">The string to reverse</param>
     /// <returns>A reversed string</returns>
        public static string ReverseString(string str)   
        {
            if (str == null) return null;

              
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        delegate byte[] Convert(string input);

        /// <summary>
        /// Converts a string to an array of bytes. Be aware extended unicode characters could result in unexpected output.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Byte[] ToBytes(this string s)
        {

            Convert del = input => //learning Lamda Expressions
            {
                byte[] arr = new byte[input.Length];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    int c = (int)char.GetNumericValue(input[i]);
                    arr[i] = (byte)c;
                }
                return arr;
            };
            byte[] bytes = del(s);
            return bytes;
        }
          /// <summary>
        /// Tests if a string has duplicate values within itself.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Returns true if the string has duplicate values (e.g "abbc").</returns>
        public static bool Duplicates(string s)
        {
            int index = 0; //minor optimisation
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = index; j < s.Length; j++)
                {
                    if ((i != j) && (s[i] == s[j]))
                    {
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
    }
}
