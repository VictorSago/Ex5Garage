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

        private Garage<Vehicle> _current;
        public Garage<Vehicle> Current { get => _current; set => _current = value; }

        protected GarageHandler()
        {
            // this.allGarages = new List<Garage>();
            _current = null;
        }

        public static GarageHandler Instance()
        {
            return _instance;
        }

        public Garage<Vehicle> CreateGarage(string name, int capacity)
        {
            _current = Garage<Vehicle>.CreateGarage(name, capacity);
            return Current;
        }

        public bool ParkVehicle(Garage<Vehicle> garage, Vehicle vehicle)
        {
            int result = garage.ParkVehicle(vehicle);
            return  result >= 0;
        }

        public bool Contains(Garage<Vehicle> garage, Vehicle vehicle)
        {
            return garage.Contains(vehicle);
        }

        public bool RemoveVehicle(Garage<Vehicle> garage, Vehicle vehicle)
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
