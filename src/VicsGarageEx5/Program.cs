using System;
using VicsGarageEx5.Vehicles;

namespace VicsGarageEx5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GarageHandler gh = GarageHandler.Instance;
            VehicleRegistry vregistry = VehicleRegistry.Instance;
            IGarage<IVehicle> garage = gh.CreateGarage("Garage01", 42);
            Console.WriteLine($"{garage.ToString()}");
            var car1 = vregistry.CreateVehicle<Car>("ABC123", "Green");
            var car2 = vregistry.CreateVehicle<Car>("DEF123", "White");
            var car3 = vregistry.CreateVehicle<Car>("ABC456", "Red", FuelType.FuelCell);
            var car4 = vregistry.CreateVehicle<Car>("DEF456", "Yellow");
            var car5 = vregistry.CreateVehicle<Car>("XYZ999", "Black", FuelType.Ethanol);

            gh.ParkVehicle(garage, car1);
            gh.ParkVehicle(garage, car2);
            gh.ParkVehicle(garage, car1);
            gh.ParkVehicle(garage, car5);

            Console.WriteLine("---After duplicate instance added---");
            
            Console.WriteLine($"{garage.ToString()}");

            garage.EmptyGarage();
            Console.WriteLine("---After emptying the garage---");
            Console.WriteLine($"{garage.ToString()}");
            
            gh.ParkVehicle(garage, car1);
            gh.ParkVehicle(garage, car2);
            gh.ParkVehicle(garage, car3);
            gh.ParkVehicle(garage, car4);
            gh.ParkVehicle(garage, car5);

            Console.WriteLine("---After adding 5 cars---");
            Console.WriteLine($"{garage.ToString()}");

            // Remove one of the parked cars
            var removed = gh.RemoveVehicle(garage, car2);
            Console.WriteLine($"Removed: {removed}");

            Console.WriteLine("---After removing car2---");
            Console.WriteLine($"{garage.ToString()}");
            
        }
    }
}
