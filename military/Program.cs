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

                Console.WriteLine("Enter the distance the TANK " +
                    "needs to overcome in kilometers:");

                var distanceTank = 0;
                while (!int.TryParse(Console.ReadLine(), out distanceTank))
                    Console.WriteLine("That is not a valid input, please try again:");

                Console.WriteLine("Enter the distance the WARSHIP " +
                    "needs to overcome in kilometers:");

                var distanceWarship = 0;
                while (!int.TryParse(Console.ReadLine(), out distanceWarship))
                    Console.WriteLine("That is not a valid input, please try again:");

                
                var distanceAmphibianByLand = 0;
                var distanceAmphibianBySea = 0;

                while (true)
                {
                    Console.WriteLine("Enter the distance the AMPHIBIAN " +
                    "needs to overcome by SEA in kilometers:");

                    while (!int.TryParse(Console.ReadLine(), out distanceAmphibianBySea))
                        Console.WriteLine("That is not a valid input, please try again:");

                    Console.WriteLine("Enter the distance the AMPHIBIAN " +
                        "needs to overcome by LAND in kilometers:");

                    while (!int.TryParse(Console.ReadLine(), out distanceAmphibianByLand))
                        Console.WriteLine("That is not a valid input, please try again:");

                    if (distanceAmphibianBySea + distanceAmphibianByLand > distanceTank ||
                        distanceAmphibianBySea + distanceAmphibianByLand > distanceWarship)
                    {
                        Console.WriteLine("\n\nThe distance the amphibian has to travel MUST be " +
                            "shorter than the ones the tank and warship have to cross!\n\n");
                    }
                    else
                        break;
                }

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

                var bestTransport = LeastFuelSpent(totalFuelConsumptionTank, 
                    totalFuelConsumptionWarship, totalFuelConsumptionAmphibian);

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

                Console.WriteLine("\nWould you like to make another shipment?");
                Console.WriteLine(" ___________________________");
                Console.WriteLine("|                           |");
                Console.WriteLine("|Press Y            for Yes |");
                Console.WriteLine("|Press anything else for No |");
                Console.WriteLine("|___________________________|");
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        static string LeastFuelSpent(int fuelTankSpent, int fuelWarshipSpent, int fuelAmphibianSpent)
        {
            var leastFuelConsumption = fuelTankSpent;
            var bestTransport = "Tank";
            if (leastFuelConsumption > fuelWarshipSpent)
            {
                leastFuelConsumption = fuelWarshipSpent;
                bestTransport = "Warship";
            }
            if (leastFuelConsumption > fuelAmphibianSpent)
            {
                leastFuelConsumption = fuelAmphibianSpent;
                bestTransport = "Amphibian";
            }
            return bestTransport;
        }
    }
}
