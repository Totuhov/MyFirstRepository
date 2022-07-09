using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = new List<string>();
            decimal totalPrice = 0;

            string pattern = @"[>]{2}(?<name>[A-Za-z]+)[<]{2}(?<price>\d+(\.\d+)?)\!(?<quantity>\d+)";

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match furnitureInfo = Regex.Match(input, pattern);

                if (furnitureInfo.Success)
                {
                    string name = furnitureInfo.Groups["name"].Value;
                    decimal price = decimal.Parse(furnitureInfo.Groups["price"].Value);
                    int quantity = int.Parse(furnitureInfo.Groups["quantity"].Value);

                    items.Add(name);
                    totalPrice += price * quantity;
                }
            }
            PrintOut(items, totalPrice);
            
        }
        static void PrintOut(List<string> items, decimal totalPrice)
        {
            Console.WriteLine($"Bought furniture:");

            foreach (string name in items)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
