using System;
using System.Collections.Generic;

namespace Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(' ');
                string name = data[1];
                switch (data[0])
                {
                    case "A":
                        {
                            string phonenumber = data[2];
                            if (!phonebook.ContainsKey(name))
                                phonebook[name] = "";
                            phonebook[name] = phonenumber;
                            break;
                        }
                    case "S":
                        {
                            if (phonebook.ContainsKey(name))
                                Console.WriteLine(string.Join(" -> ", name, phonebook[name]));
                            else Console.WriteLine($"Contact {name} does not exist.");
                            break;
                        }
                }
            }
        }
    }
}