﻿using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        char search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == search)
            {
                hasMatch = true;
                int endIndex = i + jump;
                if (endIndex > text.Length - 1)
                    endIndex = text.Length - 1;
                string matchedString = text.Substring(i, endIndex - i + 1);
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!hasMatch)
            Console.WriteLine("no");
    }
}
