using System;
using System.Collections.Generic;
using System.Text;

namespace military
{
    public abstract class Vehicle
    {
        public Guid VehicleID { get; set; }
        public int WeightInKg { get; set; }
        public int AverageSpeedInKmPh { get; set; }
        public int FuelConsumptionInLitres { get; set; }
        public int CapacityInNumberOfPeople { get; set; }
        public int DistanceToCover { get; set; }
        public int PeopleToTransport { get; set; }

        public override string ToString()
        {
            return $"ID: {VehicleID}\n" +
                $"Weight: {WeightInKg}kg\n" +
                $"Average speed {AverageSpeedInKmPh}km/h\n" +
                $"Fuel comsuption: {FuelConsumptionInLitres}L/100km\n" +
                $"Capacity: {CapacityInNumberOfPeople} people\n" +
                $"Total fuel consumption: {FuelConsuptionTotal(DistanceToCover)}Litres\n";
        }

        public int FuelConsuptionTotal(int distanceInKm)
        {
            var totalTrips = PeopleToTransport / CapacityInNumberOfPeople;
            if (PeopleToTransport % CapacityInNumberOfPeople != 0)
                totalTrips++;
            totalTrips = totalTrips + (totalTrips - 1);

            var totalDistanceInKm = distanceInKm * totalTrips;

            return (totalDistanceInKm / 100) * FuelConsumptionInLitres;
        }
    }
}
