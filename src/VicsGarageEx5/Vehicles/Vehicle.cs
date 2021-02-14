using System.Collections.Generic;

namespace VicsGarageEx5.Vehicles
{
    public abstract class Vehicle
    {
        // All vehicle registrations to ensure uniqueness
        static HashSet<string> RegistrationIDs;

        string RegistrationID { get; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        FuelType FuelType { get; set; }
    }
}