using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotate_a_Matrix
{
    class Rotate_a_Matrix
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            string[][] matrix = new string[rows][];
            for (int row = 0; row < rows; row++)
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[][] rotatedMatrix = new string[cols][];
            for (int col = 0; col < cols; col++)
            {
                List<string> colElements = new List<string>();
                for (int row = rows - 1; row >= 0; row--)
                    colElements.Add(matrix[row][col]);
                rotatedMatrix[col] = colElements.ToArray();
            }
            for (int row = 0; row < rotatedMatrix.Length; row++)
                Console.WriteLine(string.Join(" ", rotatedMatrix[row]));
        }
    }
}
