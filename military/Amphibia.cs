using System;
using System.Collections.Generic;
using System.Text;

namespace military
{
    public sealed class Amphibia : Vehicle, ISwimmable, IDriveable
    {
        public Amphibia(int weightInKg, int averageSpeedInKmPh)
        {
            VehicleID = Guid.NewGuid();
            WeightInKg = weightInKg;
            AverageSpeedInKmPh = averageSpeedInKmPh;
            FuelConsumptionInLitres = (int)FuelConsuption.Amphibia;
            CapacityInNumberOfPeople = (int)Capacity.Amphibia;
        }

        public int Swim(int distanceInKm)
        {
            var newDistance = distanceInKm;
            var timeToTravelInMinutes = (distanceInKm / AverageSpeedInKmPh) / 60;

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
