using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._The_Pianist
{
    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfPieces = int.Parse(Console.ReadLine());

            string[] input;

            List<Piece> pieces = new List<Piece>();

            string name = string.Empty;
            string composer = string.Empty;
            string key = string.Empty;

            for (int i = 0; i < numOfPieces; i++)
            {
                input = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                name = input[0];
                composer = input[1];
                key = input[2];

                Piece piece = new Piece(name, composer, key);
                pieces.Add(piece);
            }
            string command;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] task = command
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string todo = task[0];

                if (todo == "Add")
                {
                    AddPiece(name, composer, key, pieces, task);
                }
                else if (todo == "Remove")
                {
                    RemovePiece(name, pieces, task);
                }
                else if (todo == "ChangeKey")
                {
                    ChangeKey(name, key, pieces, task);
                }
            }
            foreach (var item in pieces)
            {
                Console.WriteLine($"{item.Name} -> Composer: {item.Composer}, Key: {item.Key}");
            }
        }
        static void AddPiece(string name, string composer, string key, List<Piece> pieces, string[] task)
        {
            name = task[1];
            composer = task[2];
            key = task[3];

            if (!pieces.Any(x => x.Name == name))
            {
                pieces.Add(new Piece(name, composer, key));
                Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
            }
            else
            {
                Console.WriteLine($"{name} is already in the collection!");
            }
        }
        static void RemovePiece(string name, List<Piece> pieces, string[] task)
        {
            name = task[1];

            if (!pieces.Any(x => x.Name == name))
            {
                Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");                
            }
            else
            {
                foreach (var item in pieces)
                {
                    if (item.Name == name)
                    {
                        pieces.Remove(item);
                        Console.WriteLine($"Successfully removed {name}!");
                        break;
                    }
                }
            }
        }
        static void ChangeKey(string name, string key, List<Piece> pieces, string[] task)
        {
            name = task[1];
            key = task[2];

            if (!pieces.Any(x => x.Name == name))
            {
                Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
            }
            else
            {
                foreach (var item in pieces)
                {
                    if (item.Name == name)
                    {
                        item.Key = key;
                        Console.WriteLine($"Changed the key of {item.Name} to {item.Key}!");
                    }
                }
            }
        }
    }
}
