using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_of_Letters
{
    class Matrix_of_Letters
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            char letter = 'A';
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                for (int col = 0; col < cols; col++)
                    matrix[row][col] = letter++;
            }
            for (int row = 0; row < rows; row++)
                Console.WriteLine(string.Join(" ", matrix[row]));
        }
    }
}
