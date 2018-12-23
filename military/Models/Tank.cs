using System;
using System.Collections.Generic;
using System.Text;
using military.Enums;
using military.Interfaces;

namespace military.Models
{
    public sealed class Tank : Vehicle, IDriveable
    {
        

        public Tank(int weightInKg, int averageSpeedInKmPh)
            : base(weightInKg, averageSpeedInKmPh)
        {
            FuelConsumptionInLitres = (int)FuelConsumption.Tank;
            CapacityInNumberOfPeople = (int)Capacity.Tank;
        }

        public int Move(int distanceInKm)
        {
            var newDistance = distanceInKm;

            for (var i = 0; i < distanceInKm / 10; i++)
            {
                if (new Random().Next(0, 100) < 30)
                    newDistance += 5;
            }

            return newDistance;
        }
    }
}
