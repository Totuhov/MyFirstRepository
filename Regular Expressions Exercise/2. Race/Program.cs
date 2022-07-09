using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Race
{
    class Person
    {
        public Person(string name, int gelaufeneDistance)
        {
            this.Name = name;
            this.Distance += gelaufeneDistance;
        }
        public string Name { get; set; }
        public int Distance { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> listOfPersons = new List<Person>();

            string teilnehmer = string.Empty;
            int gelaufeneDinstanz = 0;
            string patternName = @"[A-Za-z]";
            string patternDistance = @"\d{1}";
            

            string[] teilnehmers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var person in teilnehmers)
            {
                Person newPerson = new Person(person, 0);
                listOfPersons.Add(newPerson);
            }

            string command;

            List<char> data = new List<char>();

            while ((command = Console.ReadLine()) != "end of race")
            {
                MatchCollection output = Regex.Matches(command, patternName);

                foreach (Match ch in output)
                {
                    teilnehmer += ch.Value;
                }

                MatchCollection output2 = Regex.Matches(command, patternDistance);

                foreach (Match integer in output2)
                {
                    gelaufeneDinstanz += int.Parse(integer.Value);
                }

                DoesTeilnehmerExist(listOfPersons, teilnehmer, gelaufeneDinstanz);

                teilnehmer = string.Empty;
                gelaufeneDinstanz = 0;

            }

            listOfPersons = listOfPersons.OrderByDescending(x => x.Distance).ToList();

            Console.WriteLine($"1st place: {listOfPersons[0].Name}");
            Console.WriteLine($"2nd place: {listOfPersons[1].Name}");
            Console.WriteLine($"3rd place: {listOfPersons[2].Name}");

            static void DoesTeilnehmerExist(List<Person> listOfPersons, string teilnehmer, int gelaufeneDinstanz)
            {
                foreach (var item in listOfPersons)
                {
                    if (item.Name == teilnehmer)
                    {
                        item.Distance += gelaufeneDinstanz;
                    }
                }
            }
        }
    }
}
