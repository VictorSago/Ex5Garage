using System;
using System.Collections.Generic;

namespace VicsGarageEx5.Vehicles
{
    public class VehicleRegistry
    {
        protected static VehicleRegistry _instance = new VehicleRegistry();

        // All vehicle registrations to ensure uniqueness
        static ISet<string> RegistrationIDs = new HashSet<string>();

        public static VehicleRegistry Instance { get => _instance; }
        

        public Vehicle CreateVehicle<T>(string registration, string color, FuelType fuel = FuelType.Gasoline) where T : Vehicle, new()
        {
            Vehicle vehicle = null;
            if (VehicleRegistry.Instance.Add(registration))
            {
                vehicle = new T();
                vehicle.Initialize(registration, color, fuel);
            }
            return vehicle;
        }

        internal bool Add(string regID)
        {
            var id = regID.ToUpper();
            if (Validate(id))
            {
                return RegistrationIDs.Add(regID);
            }
            return false;
        }

        /// <summary>
        /// Checks if the registration number follows existing an format
        /// As there are different registration formats this method is not implemented at the moment
        /// </summary>
        /// <param name="id">Registration number to be validated</param>
        /// <returns>True if the id is a valid registration number, false otherwise</returns>
        private bool Validate(string id)
        {
            return true;
        }

        internal bool Remove(string regID)
        {
            return RegistrationIDs.Remove(regID);
        }
    }
}