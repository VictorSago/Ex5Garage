using System;
using System.Collections.Generic;

namespace VicsGarageEx5.Vehicles
{
    public class VehicleRegistry
    {
        protected static VehicleRegistry _instance = new VehicleRegistry();

        static ISet<string> RegistrationIDs = new HashSet<string>();

        public static VehicleRegistry Instance { get => _instance; }
        
        // public static VehicleRegistry Instance()
        // {
        //     return _instance;
        // }

        internal bool Add(string registration)
        {
            return RegistrationIDs.Add(registration);
        }
    }
}