﻿using System;

namespace Randomize_Words
{
    public class Randomize_Words
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(' ');
            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                int index = rnd.Next(0, words.Length);
                string temp = words[i];
                words[i] = words[index];
                words[index] = temp;
            }
            Console.WriteLine(string.Join("\n", words));
        }
    }
}