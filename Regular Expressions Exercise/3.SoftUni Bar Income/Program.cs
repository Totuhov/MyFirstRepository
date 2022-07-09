using System;
using System.Text.RegularExpressions;

namespace _3.SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<name>%([A-Z][a-z]+)%)[^\|$%.]*(?<product><(\w+)>)[^\|$%.]*\|(?<quantity>([0-9]+))\|[^\|$%.0-9]*(?<price>((?:\d+(?:\.\d*)?|\.\d+)))\$";

            string command;

            double totalIncome = 0;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(command, pattern);

                if (match.Success)
                {
                    string customerName = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);

                    totalIncome += price * quantity;

                    Console.WriteLine($"{customerName}: {product} - {quantity * price:f2}");
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
