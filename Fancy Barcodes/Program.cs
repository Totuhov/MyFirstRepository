using System;
using System.Text.RegularExpressions;

namespace Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string patern = @"@#+(?<name>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z])@#+";

                Match match = Regex.Match(input, patern);

                if (match.Success)
                {
                    string product = match.Groups["name"].Value;
                    string patern2 = @"[0-9]";

                    MatchCollection matches = Regex.Matches(product, patern2);

                    string productGroup = string.Empty;

                    foreach (Match m in matches)
                    {
                        productGroup += m;
                    }
                    if (productGroup.Length == 0)
                    {
                        productGroup = "00";
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
