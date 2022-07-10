using System;
using System.Collections.Generic;
using System.Linq;

namespace Need_for_Speed_III
{
    class Car
    {
        public Car(string model, int mileage, int fuel)
        {
            this.Model = model;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> carCollection = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = data[0];
                int mileage = int.Parse(data[1]);
                int fuel = int.Parse(data[2]);

                Car car = new Car(model, mileage, fuel);

                carCollection.Add(car);
            }
            string command;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] input = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "Drive")
                {
                    string carToDrive = input[1];
                    int distanceToDrive = int.Parse(input[2]);
                    int usedFuel = int.Parse(input[3]);


                    foreach (Car car in carCollection.Where(x => x.Model == carToDrive))
                    {
                        if (car.Fuel - usedFuel > 0)
                        {
                            car.Mileage += distanceToDrive;
                            car.Fuel -= usedFuel;
                            Console.WriteLine($"{car.Model} driven for {distanceToDrive} kilometers. {usedFuel} liters of fuel consumed.");
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        if (car.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car.Model}!");
                            int index = carCollection.IndexOf(car);
                            carCollection.RemoveAt(index);break;
                        }
                    }
                }
                else if (input[0] == "Refuel")
                {
                    string carToDrive = input[1];
                    int loadedFuel = int.Parse(input[2]);

                    foreach (Car car in carCollection.Where(x => x.Model == carToDrive))
                    {
                        ;
                        if (car.Fuel + loadedFuel > 75)
                        {
                            loadedFuel = 75 - car.Fuel;
                            car.Fuel = 75;
                        }
                        else
                        {
                            car.Fuel += loadedFuel;
                        }
                        Console.WriteLine($"{car.Model} refueled with {loadedFuel} liters");
                    }
                }
                else if (input[0] == "Revert")
                {
                    string carToDrive = input[1];
                    int kilometers = int.Parse(input[2]);

                    foreach (Car car in carCollection.Where(x => x.Model == carToDrive))
                    {
                        if (car.Mileage - kilometers > 10000)
                        {
                            Console.WriteLine($"{car.Model} mileage decreased by {kilometers} kilometers");
                            car.Mileage -= kilometers;
                        }
                        else
                        {
                            car.Mileage = 10000;
                        }
                    }
                }
            }
            foreach (Car car in carCollection)
            {
                Console.WriteLine($"{car.Model} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
}
