using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(\w+( |)\w+)<<(\d+(\.)\d+|\d+)(!)(\d+)";

            string pattern2 = @"^[>]{2}(?<name>[A-Za-z]+)[<]{2}(?<price>\d+(\.\d+)?)\!(?<quantity>\d+)?";

            List<string> list = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                list.Add(input);                
            }            

            MatchCollection output = Regex.Matches(String.Join(" ", list), pattern);

            double totalPrice = 0;
            double price = 0;
            int quantity = 0;

            Console.WriteLine("Bought furniture:");
            foreach (Match m in output)
            {
                quantity = int.Parse(m.Groups[6].Value);
                price = double.Parse(m.Groups[3].Value);
                
                totalPrice += price * quantity;
                Console.WriteLine($"{m.Groups[1].Value}");
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
