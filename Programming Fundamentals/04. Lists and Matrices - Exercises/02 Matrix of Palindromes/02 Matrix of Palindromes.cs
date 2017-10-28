using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_of_Palindromes
{
    class Matrix_of_Palindromes
    {
        static void Main(string[] args)
        {
            string[][] palindromes = GetPalindromes();

            for (int row = 0; row < palindromes.Length; row++)
                Console.WriteLine(string.Join(" ", palindromes[row]));
        }

        private static string[][] GetPalindromes()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[][] palindromes = new string[rows][];
            for (int row = 0; row < rows; row++)
            {
                char rowLetter = (char)('a' + row);
                palindromes[row] = new string[cols];
                for (int col = 0; col < cols; col++)
                    palindromes[row][col] = string.Join("", rowLetter, (char)(rowLetter + col), rowLetter);
            }
            return palindromes;
        }
    }
}