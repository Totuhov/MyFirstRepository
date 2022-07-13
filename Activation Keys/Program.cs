using System;
using System.Linq;

namespace Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commandArray = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string task = commandArray[0];

                if (task == "Contains")
                {
                    Contains(activationKey, commandArray);
                }
                else if (task == "Flip")
                {
                    Flip(commandArray, ref activationKey);
                }
                else if (task == "Slice")
                {
                    Slice(commandArray, ref activationKey);
                }
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }


        static void Contains(string activationKey, string[] commandArray)
        {
            string substring = commandArray[1];

            if (activationKey.Contains(substring))
            {
                Console.WriteLine($"{activationKey} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }
        static void Flip(string[] commandArray, ref string activationKey)
        {
            string subTask = commandArray[1];
            int startIndex = int.Parse(commandArray[2]);
            int endIndex = int.Parse(commandArray[3]);
            string subString;
            string subStringNew;

            if (subTask == "Upper")
            {
                subString = activationKey.Substring(startIndex, endIndex - startIndex);
                subStringNew = subString.ToUpper();
                activationKey = activationKey.Replace(subString, subStringNew);
                Console.WriteLine(activationKey);
            }
            else
            {
                subString = activationKey.Substring(startIndex, endIndex - startIndex);
                subStringNew = subString.ToLower();
                activationKey = activationKey.Replace(subString, subStringNew);
                Console.WriteLine(activationKey);
            }
        }
        static void Slice(string[] commandArray, ref string activationKey)
        {
            int startIndex = int.Parse(commandArray[1]);
            int endIndex = int.Parse(commandArray[2]);

            activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

            Console.WriteLine(activationKey);
        }
    }
}
