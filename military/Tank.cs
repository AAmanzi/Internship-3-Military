using System;
using System.Collections.Generic;
using System.Text;

namespace military
{
    public sealed class Tank : Vehicle, IDriveable
    {
        

        public Tank(int weightInKg, int averageSpeedInKmPh)
        {
            VehicleID = Guid.NewGuid();
            WeightInKg = weightInKg;
            AverageSpeedInKmPh = averageSpeedInKmPh;
            FuelConsumptionInLitres = (int)FuelConsuption.Tank;
            CapacityInNumberOfPeople = (int)Capacity.Tank;
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
