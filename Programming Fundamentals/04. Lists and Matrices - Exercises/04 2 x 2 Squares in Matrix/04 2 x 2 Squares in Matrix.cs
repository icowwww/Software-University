using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_x_2_Squares_in_Matrix
{
    class _2_x_2_Squares_in_Matrix
    {
        static void Main(string[] args)
        {
            char[][] matrix = GetMatrix();
            int countSquares = GetCountOf2x2Squares(matrix);
            Console.WriteLine(countSquares);
        }
        
        private static int GetCountOf2x2Squares(char[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int count = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char cell = matrix[row][col];
                    bool is2by2Square = cell == matrix[row][col + 1] &&
                                        cell == matrix[row + 1][col] &&
                                        cell == matrix[row + 1][col + 1];
                    if (is2by2Square) count++;
                }
            }
            return count;
        }

        private static char[][] GetMatrix()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            return matrix;
        }
    }
}