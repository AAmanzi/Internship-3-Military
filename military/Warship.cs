using System;
using System.Collections.Generic;
using System.Text;

namespace military
{
    sealed class Warship : Vehicle, ISwimmable
    {
        public Warship(int weightInKg, int averageSpeedInKmPh)
        {
            VehicleID = Guid.NewGuid();
            WeightInKg = weightInKg;
            AverageSpeedInKmPh = averageSpeedInKmPh;
            FuelConsumptionInLitres = (int)FuelConsuption.Warship;
            CapacityInNumberOfPeople = (int)Capacity.Warship;
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
    }


}
