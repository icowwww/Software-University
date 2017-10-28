using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_Frame_in_Matrix
{
    class Largest_Frame_in_Matrix
    {
        static void Main(string[] args)
        {
            int[][] matrix = GetMatrix();
            List<string> largestFrames = GetMaxFrames(matrix);
            Console.WriteLine(string.Join(", ", largestFrames.OrderBy(x => x)));
        }

        static List<string> GetMaxFrames(int[][] matrix)
        {
            List<string> largestFrames = new List<string>();
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int maxSize = rows * cols;
            bool containsMaxSizeFrame = false;

            while (!containsMaxSizeFrame && maxSize > 0)
            {
                for (int minRow = 0; minRow < rows; minRow++)
                {
                    for (int minCol = 0; minCol < cols; minCol++)
                    {
                        for (int maxRow = rows - 1; maxRow >= minRow; maxRow--)
                        {
                            for (int maxCol = cols - 1; maxCol >= minCol; maxCol--)
                            {
                                bool isEqualSizedFrame = IsEqualSizedFrame(matrix, minRow, minCol, maxRow, maxCol);
                                int frameSize = GetFrameSize(minRow, minCol, maxRow, maxCol);
                                bool isMaxSizeFrame = isEqualSizedFrame && frameSize == maxSize;

                                if (isMaxSizeFrame)
                                {
                                    largestFrames.Add(GetFrameDimensions(minRow, minCol, maxRow, maxCol));
                                    containsMaxSizeFrame = true;
                                }
                            }
                        }
                    }
                }
                if (!containsMaxSizeFrame) maxSize--;
            }
            return largestFrames;
        }

        static string GetFrameDimensions(int minRow, int minCol, int maxRow, int maxCol)
        {
            int width = maxCol - minCol + 1;
            int height = maxRow - minRow + 1;
            return string.Join("x", height, width);
        }

        static bool IsEqualSizedFrame(int[][] matrix, int minRow, int minCol, int maxRow, int maxCol)
        {
            int cell = matrix[minRow][minCol];
            for (int row = minRow; row <= maxRow; row++)
                if (matrix[row][minCol] != cell || matrix[row][maxCol] != cell)
                    return false;
            for (int col = minCol; col <= maxCol; col++)
                if (matrix[minRow][col] != cell || matrix[maxRow][col] != cell)
                    return false;
            return true;
        }

        static int GetFrameSize(int minRow, int minCol, int maxRow, int maxCol)
        {
            int width = maxCol - minCol + 1;
            int height = maxRow - minRow + 1;
            return width * height;
        }

        static int[][] GetMatrix()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            return matrix;
        }

        static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
                Console.WriteLine(string.Join(" ", matrix[row]));
        }
    }
}