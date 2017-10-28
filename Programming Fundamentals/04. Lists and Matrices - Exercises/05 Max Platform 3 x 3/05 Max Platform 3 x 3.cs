using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Platform_3x3
{
    class Max_Platform_3x3
    {
        static void Main(string[] args)
        {
            int[][] matrix = GetMatrix();

            int[] maxCoordinates = new int[2];
            long maxSum = long.MinValue;
            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    long sum = GetPlatformSum(matrix, row, col);
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxCoordinates = new int[2] { row, col };
                    }
                }
            }
            Console.WriteLine(maxSum);
            PrintPlatform(matrix, maxCoordinates);
        }

        static void PrintPlatform(int[][] matrix, int[] coordinates)
        {
            for (int row = coordinates[0]; row < coordinates[0] + 3; row++)
            {
                for (int col = coordinates[1]; col < coordinates[1] + 3; col++)
                    Console.Write("{0} ", matrix[row][col]);
                Console.WriteLine();
            }
        }

        static long GetPlatformSum(int[][] matrix, int platformRow, int platformCol)
        {
            long sum = 0;
            for (int row = platformRow; row < platformRow + 3; row++)
                for (int col = platformCol; col < platformCol + 3; col++)
                    sum += matrix[row][col];
            return sum;
        }

        private static int[][] GetMatrix()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            return matrix;
        }
    }
}