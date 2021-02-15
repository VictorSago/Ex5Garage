using System.Text;
using System.Collections.Generic;
using System;

namespace VicsGarageEx5.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        // All vehicle registrations to ensure uniqueness
        static ISet<string> RegistrationIDs = new HashSet<string>();

        public string RegistrationID { get; set; }
        public string Color { get; set; }
        public FuelType FuelType { get; set; }

        protected Vehicle()
        {
        }
        protected virtual void Initialize(string registration, string color, FuelType fuel)
        {
            RegistrationID = registration;
            Color = color;
            FuelType = fuel;
        }


        public static Vehicle CreateVehicle<T>(string registration, string color, FuelType fuel = FuelType.Gasoline) where T : Vehicle, new()
        {
            Vehicle vehicle = null;
            if (Vehicle.RegistrationIDs.Add(registration))
            {
                vehicle = new T();
                vehicle.Initialize(registration, color, fuel);
            }
            return vehicle;
        }
 
        public override bool Equals(object obj)
        {
            return obj is Vehicle vehicle &&
                   RegistrationID == vehicle.RegistrationID;
        }

        public override string ToString()
        {
            return $"{this.GetType()}: {this.RegistrationID}, {this.Color}, {this.FuelType}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RegistrationID);
        }
    }
}