using System;
using System.Collections.Generic;
using System.Text;

namespace military
{
    class Utility
    {
        public static string LeastFuelSpent(int fuelTankSpent, int fuelWarshipSpent, 
            int fuelAmphibianSpent)
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
                bestTransport = "Amphibian";
            }
            return bestTransport;
        }
    }
}
