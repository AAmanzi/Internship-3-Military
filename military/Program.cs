using System;

namespace military
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void InitiateVehicles()
        {
            var myTank = new Tank(68000, 70);
            var myWarship = new Warship(35000, 80);
            var myAmphibian = new Amphibia(23000, 40);
        }
    }
}
