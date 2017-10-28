using System;
using System.Linq;

public class SequenceOfCommands_broken
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string command = Console.ReadLine();

        while (!command.Equals("stop"))
        {
            string line = command.Trim();
            string[] stringParams = line.Split(ArgumentsDelimiter);
            string action = stringParams[0];
            int[] args = new int[2];
            if (action == "add" ||
                action == "subtract" ||
                action == "multiply")
            {
                args[0] = int.Parse(stringParams[1]);
                args[1] = int.Parse(stringParams[2]);
            }
            array = PerformAction(array, action, args);

            PrintArray(array);

            command = Console.ReadLine();
        }
    }

    static long[] PerformAction(long[] array, string action, int[] args)
    {
        //long[] array = arr.Clone() as long[];
        int pos = args[0] - 1;
        int value = args[1];

        switch (action)
        {
            case "multiply":
                array[pos] *= value;
                break;
            case "add":
                array[pos] += value;
                break;
            case "subtract":
                array[pos] -= value;
                break;
            case "lshift":
                array = ArrayShiftLeft(array);
                break;
            case "rshift":
                array = ArrayShiftRight(array);
                break;
        }
        return array;
    }

    private static long[] ArrayShiftRight(long[] array)
    {
        long lastElement = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
            array[i] = array[i - 1];
        array[0] = lastElement;
        return array;
    }

    private static long[] ArrayShiftLeft(long[] array)
    {
        long firstElement = array[0];
        for (int i = 0; i < array.Length - 1; i++)
            array[i] = array[i + 1];
        array[array.Length - 1] = firstElement;
        return array;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i] + " ");
        Console.WriteLine();
    }
}
