using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public Hero(string name, int health, int mana)
        {
            this.Name = name;
            this.Health = health;
            this.Mana = mana;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            int n = int.Parse(Console.ReadLine());

            InputHeroes(n, ref heroes);

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string action = commandArray[0];

                if (action == "CastSpell")
                {
                    CastSpel(commandArray, ref heroes);
                }
                else if (action == "TakeDamage")
                {
                    TakeDamage(commandArray, ref heroes);
                }
                else if (action == "Recharge")
                {
                    Recharge(commandArray, ref heroes);
                }
                else if (action == "Heal")
                {
                    Heal(commandArray, ref heroes);
                }
            }
            foreach (Hero hero in heroes)
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"  HP: {hero.Health}");
                Console.WriteLine($"  MP: {hero.Mana}");
            }
        }
        static void InputHeroes(int n, ref List<Hero> heroes)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string name = input[0];
                int health = int.Parse(input[1]);
                int mana = int.Parse(input[2]);

                if (health > 100)
                {
                    health = 100;
                }
                if (mana > 200)
                {
                    mana = 200;
                }
                Hero hero = new Hero(name, health, mana);
                heroes.Add(hero);
            }
        }
        static void CastSpel(string[] commandArray, ref List<Hero> heroes)
        {
            string heroName = commandArray[1];
            int manaNeeded = int.Parse(commandArray[2]);
            string spellName = commandArray[3];

            foreach (Hero hero in heroes.Where(x => x.Name == heroName))
            {
                if (hero.Mana >= manaNeeded)
                {
                    hero.Mana -= manaNeeded;
                    Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.Mana} MP!");
                }
                else
                {
                    Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
                }
            }
        }
        static void TakeDamage(string[] commandArray, ref List<Hero> heroes)
        {
            string heroName = commandArray[1];
            int damage = int.Parse(commandArray[2]);
            string attacker = commandArray[3];

            foreach (Hero hero in heroes.Where(x => x.Name == heroName))
            {
                hero.Health -= damage;

                if (hero.Health > 0)
                {
                    Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.Health} HP left!");
                }
                else
                {
                    Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                    heroes.Remove(hero); break;
                }
            }
        }
        static void Recharge(string[] commandArray, ref List<Hero> heroes)
        {
            string heroName = commandArray[1];
            int amountMana = int.Parse(commandArray[2]);
            int rechargedMana = 0;

            foreach (Hero hero in heroes.Where(x => x.Name == heroName))
            {
                if (hero.Mana + amountMana > 200)
                {
                    rechargedMana = 200 - hero.Mana;
                    hero.Mana = 200;
                    Console.WriteLine($"{hero.Name} recharged for {rechargedMana} MP!");
                }
                else
                {
                    hero.Mana += amountMana;
                    Console.WriteLine($"{hero.Name} recharged for {amountMana} MP!");
                }
            }
        }
        static void Heal(string[] commandArray, ref List<Hero> heroes)
        {
            string heroName = commandArray[1];
            int amountHealth = int.Parse(commandArray[2]);
            int rechargedHealth = 0;

            foreach (Hero hero in heroes.Where(x => x.Name == heroName))
            {
                if (hero.Health + amountHealth > 100)
                {
                    rechargedHealth = 100 - hero.Health;
                    hero.Health = 100;
                    Console.WriteLine($"{hero.Name} healed for {rechargedHealth} HP!");
                }
                else
                {
                    hero.Health += amountHealth;
                    Console.WriteLine($"{hero.Name} healed for {amountHealth} HP!");
                }
            }
        }
    }
}
