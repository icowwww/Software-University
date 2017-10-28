using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagonal_Difference
{
    class Diagonal_Difference
    {
        static void Main(string[] args)
        {
            int[][] matrix = GetMatrix();
            int[] diagonalsSum = GetDiagonalsSums(matrix);
            Console.WriteLine(Math.Abs(diagonalsSum[0] - diagonalsSum[1]));
        }

        private static int[] GetDiagonalsSums(int[][] matrix)
        {
            int size = matrix.Length;
            int[] diagonalsSum = new int[2];
            for (int i = 0; i < size; i++)
            {
                diagonalsSum[0] += matrix[i][i];
                diagonalsSum[1] += matrix[i][size - 1 - i];
            }
            return diagonalsSum;
        }

        private static int[][] GetMatrix()
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];
            for (int row = 0; row < size; row++)
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            return matrix;
        }
    }
}