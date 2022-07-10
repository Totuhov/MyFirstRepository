using System;

namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string newInput = string.Empty;
            string command;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commandArray = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandArray[0] == "TakeOdd")
                {
                    TakeOdd(ref input, ref newInput);
                }
                else if (commandArray[0] == "Cut")
                {
                    Cut(ref input, commandArray);
                }
                else if (commandArray[0] == "Substitute")
                {
                    Substitute(ref input, commandArray);
                }
            }
            Console.WriteLine($"Your password is: {input}");
        }


        static void TakeOdd(ref string input, ref string newInput)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0)
                {
                    newInput += input[i];
                }
            }
            input = newInput;
            newInput = string.Empty;

            Console.WriteLine(input);
        }
        static void Cut(ref string input, string[] commandArray)
        {
            int index = int.Parse(commandArray[1]);
            int length = int.Parse(commandArray[2]);

            input = input.Remove(index, length);

            Console.WriteLine(input);
        }
        static void Substitute(ref string input, string[] commandArray)
        {
            string substring = commandArray[1];
            string substitute = commandArray[2];

            if (input.Contains(substring))
            {
                input = input.Replace(substring, substitute);
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }
        }
    }
}
