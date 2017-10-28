using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hourglass_Sum
{
    class Hourglass_Sum
    {
        static void Main(string[] args)
        {
            int size = 6;
            int[][] matrix = GetMatrix(size);

            long maxSum = GetMaxSum(matrix);
            Console.WriteLine(maxSum);
        }

        private static long GetMaxSum(int[][] matrix)
        {
            int size = matrix.Length;
            long maxSum = long.MinValue;
            for (int row = 0; row < size - 2; row++)
            {
                for (int col = 0; col < size - 2; col++)
                {
                    long sum = GetHourGlassSum(matrix, row, col);
                    if (sum > maxSum) maxSum = sum;
                }
            }
            return maxSum;
        }

        static long GetHourGlassSum(int[][] matrix, int r, int c)
        {
            long sum = 0;
            for (int row = r; row < r + 3; row++)
            {
                if (row == r + 1)
                    sum += matrix[row][c + 1];
                else
                {
                    for (int col = c; col < c + 3; col++)
                        sum += matrix[row][col];
                }
            }
            return sum;
        }

        private static int[][] GetMatrix(int size)
        {
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
