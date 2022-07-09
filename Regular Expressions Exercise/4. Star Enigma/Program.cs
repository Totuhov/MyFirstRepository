using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    class Planet
    {
        public Planet(string name, ulong population, char attackType, int soldierCount)
        {
            this.Name = name;
            this.Population = population;
            this.AttackType = attackType;
            this.SoldierCount = soldierCount;
        }
        public string Name { get; set; }
        public ulong Population { get; set; }
        public char AttackType { get; set; }
        public int SoldierCount { get; set; }
        internal class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                string[] arrayOfMessages = new string[n];
                string pattern = @"[starSTAR]";

                for (int i = 0; i < n; i++)
                {
                    //string decodedMessage = string.Empty;
                    string message = Console.ReadLine();
                    MatchCollection matches = Regex.Matches(message, pattern);
                    int count = matches.Count;

                    char[] chars = message.ToCharArray();

                    for (int k = 0; k < chars.Length; k++)
                    {
                        chars[k] = (char)(chars[k] - count);
                        //decodedMessage += chars[k];
                    }
                    arrayOfMessages[i] = String.Join("", chars);

                    //string arrayOfMessage = String.Join("", chars);
                }

                string pattern2 = @"@([A-Z][a-z]+)[^@|-|!|:]*:([0-9]+)[^@|-|!|:]*!([A|D])![^@|-|!|:]*->([0-9]+)";
                List<Planet> planetsA = new List<Planet>();
                List<Planet> planetsD = new List<Planet>();


                for (int i = 0; i < arrayOfMessages.Length; i++)
                {
                    Match match = Regex.Match(arrayOfMessages[i], pattern2);

                    if (match.Success)
                    {
                        string name = match.Groups[1].Value;
                        ulong population = ulong.Parse(match.Groups[2].Value);
                        char attackType = char.Parse(match.Groups[3].Value);
                        int soldierCount = int.Parse(match.Groups[4].Value);

                        Planet planet = new Planet(name, population, attackType, soldierCount);


                        if (planet.AttackType == 'A')
                        {
                            planetsA.Add(planet);
                        }
                        else
                        {
                            planetsD.Add(planet);
                        }
                    }
                }

                planetsA = planetsA.OrderBy(x => x.Name).ToList();
                planetsD = planetsD.OrderBy(x => x.Name).ToList();

                Console.WriteLine($"Attacked planets: {planetsA.Count}");
                foreach (Planet planet in planetsA)
                {
                    Console.WriteLine($"-> {planet.Name}");
                }
                Console.WriteLine($"Destroyed planets: {planetsD.Count}");
                foreach (Planet planet in planetsD)
                {
                    Console.WriteLine($"-> {planet.Name}");
                }
            }
        }
    }
}
