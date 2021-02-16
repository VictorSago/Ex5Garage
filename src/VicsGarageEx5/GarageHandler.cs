using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VicsGarageEx5.Vehicles;

namespace VicsGarageEx5
{
    public class GarageHandler
    {
        protected static GarageHandler _instance = new GarageHandler();

        private IGarage<IVehicle> _current;
        public IGarage<IVehicle> Current { get => _current; set => _current = value; }

        protected GarageHandler()
        {
            // this.allGarages = new List<Garage>();
            _current = null;
        }

        public static GarageHandler Instance()
        {
            return _instance;
        }

        public IGarage<IVehicle> CreateGarage(string name, uint capacity)
        {
            _current = Garage<IVehicle>.CreateGarage(name, capacity);
            return Current;
        }

        public bool ParkVehicle(IGarage<IVehicle> garage, IVehicle vehicle)
        {
            int result = garage.ParkVehicle(vehicle);
            return  result >= 0;
        }

        public bool Contains(IGarage<IVehicle> garage, IVehicle vehicle)
        {
            return garage.Contains(vehicle);
        }

        public bool RemoveVehicle(IGarage<IVehicle> garage, IVehicle vehicle)
        {
            return (garage.RemoveVehicle(vehicle) is not null);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"GarageHandler: Garages: {_current.Name}");
            
            return sb.ToString();
        }

    }
}
