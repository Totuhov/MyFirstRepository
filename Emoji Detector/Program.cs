using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(:{2}|\*{2})(?<name>[A-Z]{1}[a-z]{2,})\1";
            string patternInt = @"[1-9]";

            string input = Console.ReadLine();

            Dictionary<string, int> emojies = new Dictionary<string, int>();

            MatchCollection matches = Regex.Matches(input, pattern);
            MatchCollection integers = Regex.Matches(input, patternInt);

            BigInteger bigInteger = new BigInteger(1);
            

            foreach (var x in integers)
            {
                string a = x.ToString();
                bigInteger *= int.Parse(a);
            }
            Console.WriteLine($"Cool threshold: {bigInteger}");

            BigInteger score = new BigInteger(0);

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matches)
            {
                string matchString = match.Groups["name"].Value;

                foreach (char ch in matchString)
                {
                    score += (int)ch;
                }
                if (score >= bigInteger)
                {
                    emojies.Add(match.ToString(), (int)score);
                }                
                score = 0;
            }
            foreach (var emoji in emojies)
            {
                Console.WriteLine(emoji.Key);
            }
        }
    }
}
