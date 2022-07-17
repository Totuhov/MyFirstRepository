using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class City
    {
        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();
            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] cityArray = input.Split("||", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = cityArray[0];
                int population = int.Parse(cityArray[1]);
                int gold = int.Parse(cityArray[2]);

                if (cities.Any(x => x.Name == name))
                {
                    foreach (City city in cities.Where(x => x.Name == name))
                    {
                        city.Population += population;
                        city.Gold += gold;
                    }
                }
                else
                {
                    City city = new City(name, population, gold);
                    cities.Add(city);
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string task = commandArray[0];

                if (task == "Plunder")
                {
                    string attackedCity = commandArray[1];
                    int people = int.Parse(commandArray[2]);
                    int gold = int.Parse(commandArray[3]);

                    foreach (City city in cities.Where(x => x.Name == attackedCity))
                    {
                        city.Population -= people;
                        city.Gold -= gold;

                        Console.WriteLine($"{city.Name} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (city.Population <= 0 || city.Gold <= 0)
                        {
                            Console.WriteLine($"{city.Name} has been wiped off the map!");
                            cities.Remove(city);
                            break;
                        }
                    }
                }
                if (task == "Prosper")
                {
                    string town = commandArray[1];
                    int gold = int.Parse(commandArray[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        foreach (City city in cities.Where(x => x.Name == town))
                        {
                            city.Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {city.Gold} gold.");
                        }
                    }
                }
            }

            if (cities.Count == 0)
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }

        }
    }
}
