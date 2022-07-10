using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@|#])([a-zA-Z]{3,})\1{2}([a-zA-Z]{3,})\1";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count < 1)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            List<string> collection = new List<string>();            

            foreach (Match match in matches)
            {
                string word1 = match.Groups[2].Value;
                string word2 = match.Groups[3].Value;

                string word2reversed = ReversedString(word2);

                if (word1 == word2reversed)
                {
                    collection.Add($"{word1} <=> {word2}");
                }
            }

            if (collection.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", collection));
            }
            else
            {
                Console.WriteLine($"No mirror words!");
            }

        }
        static string ReversedString(string word2)
        {
            char[] array = word2.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

    }
}
