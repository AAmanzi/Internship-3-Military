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

        public override string ToString()
        {
            return $"ID: {VehicleID}\n" +
                $"Weight: {WeightInKg}kg\n" +
                $"Average speed {AverageSpeedInKmPh}kmph\n" +
                $"Fuel comsuption: {FuelConsumptionInLitres}L/100km\n" +
                $"Capacity: {CapacityInNumberOfPeople} people\n";
        }

        public int FuelConsuptionTotal(int distanceInKm, int peopleToTransport)
        {
            var totalTrips = peopleToTransport / CapacityInNumberOfPeople;
            if (peopleToTransport % CapacityInNumberOfPeople != 0)
                totalTrips++;
            totalTrips = totalTrips + (totalTrips - 1);

            var totalDistanceInKm = distanceInKm * totalTrips;

            return (totalDistanceInKm / 100) * FuelConsumptionInLitres;
        }
    }

    public enum FuelConsuption
    {
        Tank = 30,
        Amphibia = 70,
        Warship = 200
    }

    public enum Capacity
    {
        Tank = 6,
        Amphibia = 20,
        Warship = 50
    }
}
