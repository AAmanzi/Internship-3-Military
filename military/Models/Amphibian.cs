using System;
using System.Collections.Generic;
using System.Text;
using military.Enums;
using military.Interfaces;

namespace military.Models
{
    public sealed class Amphibian : Vehicle, ISwimmable, IDriveable
    {
        public Amphibian(int weightInKg, int averageSpeedInKmPh)
            : base (weightInKg, averageSpeedInKmPh)
        {
            FuelConsumptionInLitres = (int)FuelConsumption.Amphibian;
            CapacityInNumberOfPeople = (int)Capacity.Amphibian;
        }

        public int Swim(int distanceInKm)
        {
            var newDistance = distanceInKm;
            var timeToTravelInMinutes = (distanceInKm / AverageSpeedInKmPh) * 60;

            for (int i = 0; i < timeToTravelInMinutes / 10; i++)
            {
                if (new Random().Next(0, 100) < 50)
                    newDistance += 3;
            }

            return newDistance;
        }

        public int Move(int distanceInKm)
        {
            var newDistance = distanceInKm;

            for (int i = 0; i < distanceInKm / 10; i++)
            {
                if (new Random().Next(0, 100) < 30)
                    newDistance += 5;
            }

            return newDistance;
        }
    }
}
