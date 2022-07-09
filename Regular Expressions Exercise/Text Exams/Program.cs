using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Exams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder message = new StringBuilder(input);

            string command;

            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] commandArray = command
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArray[0] == "Move")
                {
                    int numberOfLetters = int.Parse(commandArray[1]);

                    for (int i = 0; i < numberOfLetters; i++)
                    {
                        message.Append(message[i]);                        
                    }
                    message.Remove(0, numberOfLetters);
                }
                else if (commandArray[0] == "Insert")
                {
                    int index = int.Parse(commandArray[1]);
                    string value = commandArray[2];

                    message.Insert(index, value);
                }
                else if (commandArray[0] == "ChangeAll")
                {
                    string substring = commandArray[1];
                    string replacement = commandArray[2];

                    message.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
