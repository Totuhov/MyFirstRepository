using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToString();

            string command;

            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] arrayOfCommands = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string task = arrayOfCommands[0];

                if (task == "InsertSpace")
                {
                    int index = int.Parse(arrayOfCommands[1]);
                    string whiteSpace = " ";

                    input = input.Insert(index, whiteSpace);
                    Console.WriteLine(input);
                }
                else if (task == "Reverse")
                {
                    string substring = arrayOfCommands[1];

                    if (input.Contains(substring))
                    {
                        input = input.Remove(input.IndexOf(substring), substring.Length);
                        
                        ReverseString(ref substring);
                        input += substring;
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }                    
                }
                else if (task == "ChangeAll")
                {
                    string substring = arrayOfCommands[1];
                    string replacement = arrayOfCommands[2];

                    input = input.Replace(substring, replacement);
                    Console.WriteLine(input);
                }
            }
            Console.WriteLine($"You have a new text message: {input}");
        }

        static void ReverseString(ref string substring)
        {
            char[] chars = substring.ToCharArray();
            Array.Reverse(chars);
            substring = String.Empty;

            foreach (var item in chars)
            {
                substring += item;
            }
        }
    }
}
