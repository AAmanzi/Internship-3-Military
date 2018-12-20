using System;
using military.Classes;
using military.Enums;
using military.Interfaces;

namespace military
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTank = new Tank(68000, 70);
            var myWarship = new Warship(35000, 80);
            var myAmphibian = new Amphibia(23000, 40);

            Console.WriteLine("Greetings!\nI see you're in need of " +
                    "troop transport!\n");
            do
            {
                Console.WriteLine("Please enter the number of soldiers you need " +
                    "to transport:");

                var peopleToTransport = 0;
                while (!int.TryParse(Console.ReadLine(), out peopleToTransport))
                    Console.WriteLine("That is not a valid input, please try again:");

                Console.WriteLine("Enter the distance the tank " +
                    "needs to overcome in kilometers:");

                var distanceTank = 0;
                while (!int.TryParse(Console.ReadLine(), out distanceTank))
                    Console.WriteLine("That is not a valid input, please try again:");

                Console.WriteLine("Enter the distance the warship " +
                    "needs to overcome in kilometers:");

                var distanceWarship = 0;
                while (!int.TryParse(Console.ReadLine(), out distanceWarship))
                    Console.WriteLine("That is not a valid input, please try again:");

                Console.WriteLine("Enter the distance the amphibian " +
                    "needs to overcome by sea in kilometers:");

                var distanceAmphibianBySea = 0;
                while (!int.TryParse(Console.ReadLine(), out distanceAmphibianBySea))
                    Console.WriteLine("That is not a valid input, please try again:");

                Console.WriteLine("Enter the distance the amphibian " +
                    "needs to overcome by land in kilometers:");

                var distanceAmphibianByLand = 0;
                while (!int.TryParse(Console.ReadLine(), out distanceAmphibianByLand))
                    Console.WriteLine("That is not a valid input, please try again:");

                var totalDistanceTank = myTank.Move(distanceTank);
                var totalDistanceWarship = myWarship.Swim(distanceWarship);
                var totalDistanceAmphibian = myAmphibian.Move(distanceAmphibianByLand) +
                    myAmphibian.Swim(distanceAmphibianBySea);

                var totalFuelConsumptionTank = myTank.FuelConsumptionTotal
                    (totalDistanceTank, peopleToTransport);
                var totalFuelConsumptionWarship = myWarship.FuelConsumptionTotal
                    (totalDistanceWarship, peopleToTransport);
                var totalFuelConsumptionAmphibian = myWarship.FuelConsumptionTotal
                    (totalDistanceAmphibian, peopleToTransport);

                var leastFuelConsumption = totalFuelConsumptionTank;
                var bestTransport = "Tank";
                if (leastFuelConsumption > totalFuelConsumptionWarship)
                {
                    leastFuelConsumption = totalFuelConsumptionWarship;
                    bestTransport = "Warship";
                }
                if (leastFuelConsumption > totalFuelConsumptionAmphibian)
                {
                    leastFuelConsumption = totalFuelConsumptionAmphibian;
                    bestTransport = "Amphibian";
                }

                Console.WriteLine($"\nThe best option for transport is: {bestTransport}");

                switch (bestTransport)
                {
                    case ("Tank"):
                        Console.WriteLine(myTank.Print(totalDistanceTank, peopleToTransport));
                        break;
                    case ("Warship"):
                        Console.WriteLine(myWarship.Print(totalDistanceWarship, peopleToTransport));
                        break;
                    case ("Amphibian"):
                        Console.WriteLine(myAmphibian.Print(totalDistanceAmphibian, peopleToTransport));
                        break;
                }

                Console.WriteLine("\nAmphibian Fuel: " + totalFuelConsumptionAmphibian);
                Console.WriteLine("Tank Fuel: " + totalFuelConsumptionTank);
                Console.WriteLine("Warship Fuel: " + totalFuelConsumptionWarship + "\n");

                Console.WriteLine("Would you like to make another shipment?");
                Console.WriteLine("Press Y for Yes");
                Console.WriteLine("Press anything else for No");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
    }
}
