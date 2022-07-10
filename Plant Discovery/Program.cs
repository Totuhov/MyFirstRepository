using System;
using System.Collections.Generic;
using System.Linq;

namespace Plant_Discovery
{
    class Plant
    {

        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            AverageScore = 0;
        }
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<double> Score = new List<double>();
        public double AverageScore { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = command[0];
                int rarity = int.Parse(command[1]);

                if (plants.Any(x => x.Name == name))
                {
                    foreach (Plant plant in plants.Where(x => x.Name == name))
                    {
                        plant.Rarity = rarity;
                    }
                }
                else
                {
                    plants.Add(new Plant(name, rarity));
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] command = input
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string[] additionalVariables = command[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string task = command[0];
                string name = additionalVariables[0];

                if (task == "Rate")
                {
                    if (plants.Any(x => x.Name == name))
                    {
                        foreach (Plant plant in plants.Where(p => p.Name == name))
                        {
                            double rating = double.Parse(additionalVariables[1]);
                            plant.Score.Add(rating);
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (task == "Update")
                {
                    int newRarity = int.Parse(additionalVariables[1]);

                    if (plants.Any(x => x.Name == name))
                    {
                        foreach (Plant plant in plants.Where(p => p.Name == name))
                        {
                            plant.Rarity = newRarity;
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (task == "Reset")
                {
                    if (plants.Any(x => x.Name == name))
                    {
                        foreach (Plant plant in plants.Where(p => p.Name == name))
                        {
                            plant.Score.RemoveRange(0, plant.Score.Count);
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (Plant plant in plants)
            {
                foreach (var score in plant.Score)
                {
                    plant.AverageScore += score;
                }

            }
            //plants = plants.OrderBy(p => p.AverageScore / p.Score.Count).Reverse().ToList();
            foreach (var plant in plants)
            {
                if (plant.Score.Count == 0)
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: 0.00");
                }
                else
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.AverageScore / plant.Score.Count:f2}");
                }
            }
        }
    }
}
