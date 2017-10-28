using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Generator
{
    class Matrix_Generator
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string matrixType = data[0];
            int rows = int.Parse(data[1]);
            int cols = int.Parse(data[2]);
            int[,] matrix = new int[rows, cols];

            if (matrixType == "A")      GetMatrixA(matrix);
            else if (matrixType == "B") GetMatrixB(matrix);
            else if (matrixType == "C") GetMatrixC(matrix);
            else if (matrixType == "D") GetMatrixD(matrix, rows * cols);

            PrintMatrix(matrix);
        }

        static void GetMatrixD(int[,] matrix, int maxCount)
        {
            int number = 0;
            int minRow = 0;
            int maxRow = matrix.GetLength(0) - 1;
            int minCol = 0;
            int maxCol = matrix.GetLength(1) - 1;
            while (number < maxCount)
            {
                // down			
                for (int row = minRow; row <= maxRow; row++)
                {
                    matrix[row, minCol] = ++number;
                    if (number == maxCount) break;
                }
                if (number == maxCount) break;
                minCol++;
                // right
                for (int col = minCol; col <= maxCol; col++)
                {
                    matrix[maxRow, col] = ++number;
                    if (number == maxCount) break;
                }
                if (number == maxCount) break;
                maxRow--;
                // up
                for (int row = maxRow; row >= minRow; row--)
                {
                    matrix[row, maxCol] = ++number;
                    if (number == maxCount) break;
                }
                if (number == maxCount) break;
                maxCol--;
                // left
                for (int col = maxCol; col >= minCol; col--)
                {
                    matrix[minRow, col] = ++number;
                    if (number == maxCount) break;
                }
                minRow++;
            }
        }

        static void GetMatrixC(int[,] matrix)
        {
            int number = 1;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                for (int step = 0; step < matrix.GetLength(0) - row; step++)
                    matrix[row + step, step] = number++;
            for (int col = 1; col < matrix.GetLength(1); col++)
                for (int step = 0; step < matrix.GetLength(1) - col; step++)
                    matrix[step, col + step] = number++;
        }

        static void GetMatrixB(int[,] matrix)
        {
            int number = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
                if (col % 2 == 0)
                    for (int row = 0; row < matrix.GetLength(0); row++)
                        matrix[row, col] = number++;
                else
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                        matrix[row, col] = number++;
        }

        static void GetMatrixA(int[,] matrix)
        {
            int number = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
                for (int row = 0; row < matrix.GetLength(0); row++)
                    matrix[row, col] = number++;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                    Console.Write("{0} ", matrix[row, col]);
                Console.WriteLine();
            }
        }
    }
}