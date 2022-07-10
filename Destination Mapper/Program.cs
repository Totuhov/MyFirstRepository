using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string pattern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";

            MatchCollection matches = Regex.Matches(input, pattern);

            List<string> list = new List<string>();

            int points = 0;

            foreach (Match match in matches)
            {
                string destination = match.Groups[2].Value;
                points += destination.Length;
                list.Add(destination);
            }
            if (list.Count > 0)
            {
                Console.WriteLine($"Destinations: {string.Join(", ", list)}");
                Console.WriteLine($"Travel Points: {points}");
            }
            else
            {
                Console.WriteLine($"Destinations:");
                Console.WriteLine($"Travel Points: {points}");

            }
        }
    }
}
