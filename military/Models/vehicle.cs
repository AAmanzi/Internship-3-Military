using System;
using System.Collections.Generic;
using System.Text;

namespace military.Models
{
    public abstract class Vehicle
    {
        public Guid VehicleID { get; set; }
        public int WeightInKg { get; set; }
        public int AverageSpeedInKmPh { get; set; }
        public int FuelConsumptionInLitres { get; set; }
        public int CapacityInNumberOfPeople { get; set; }

        public Vehicle(int weightInKg, int averageSpeedInKmPh)
        {
            VehicleID = Guid.NewGuid();
            WeightInKg = weightInKg;
            AverageSpeedInKmPh = averageSpeedInKmPh;
        }

        public string Print(int distanceInKm, int peopleToTransport)
        {
            return $"ID: {VehicleID}\n" +
                $"Weight: {WeightInKg}kg\n" +
                $"Average speed {AverageSpeedInKmPh}km/h\n" +
                $"Fuel comsumption: {FuelConsumptionInLitres}L/100km\n" +
                $"Capacity: {CapacityInNumberOfPeople} people\n" +
                $"Total fuel consumption: {FuelConsumptionTotal(distanceInKm, peopleToTransport)}";
        }

        public int FuelConsumptionTotal(int distanceInKm, int peopleToTransport)
        {
            var totalTrips = peopleToTransport / CapacityInNumberOfPeople;
            if (peopleToTransport % CapacityInNumberOfPeople != 0)
                totalTrips++;
            totalTrips = totalTrips + (totalTrips - 1);

            var totalDistanceInKm = distanceInKm * totalTrips;

            return (totalDistanceInKm / 100) * FuelConsumptionInLitres;
        }
    }
}
