using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ad_Astra
{
    class Food
    {
        public Food(string name, string expirationDate, int calories)
        {
            this.Name = name;
            this.ExpirationDate = expirationDate;
            this.Calories = calories;
        }
        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public int Calories { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)               // 66%100 in Judge
        {
            string input = Console.ReadLine();

            string pattern = @"(?<name>[A-Za-z0-9 ]{1,})[|#](?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})[|#](?<calories>[0-9]{1,4}|10000)";

            MatchCollection matches = Regex.Matches(input, pattern);

            List<Food> foodList = new List<Food>();

            int totalCalories = 0;
            
            foreach (Match match in matches)
            {

                string name = match.Groups["name"].Value;
                string expirationDate = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);

                totalCalories += calories;

                Food food = new Food(name, expirationDate, calories);

                foodList.Add(food);
            }
            int leftFoodForDays = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {leftFoodForDays} days!");

            foreach (var item in foodList)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.ExpirationDate}, Nutrition: {item.Calories}");
            }
        }
    }
}
