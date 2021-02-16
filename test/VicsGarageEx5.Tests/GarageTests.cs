using System;
using System.Collections.Generic;
using VicsGarageEx5.Vehicles;
using Xunit;

namespace VicsGarageEx5.Tests
{
    public class GarageTests : IDisposable
    {
        protected GarageHandler gh;
        protected IGarage<IVehicle> garage;
        
        /** 
          * Interference between tests necessitates creation of different
          * vehicle instances for each test
        **/
        public GarageTests()
        {
            var gName = "GarageNo42";
            var capacity = 42;
            gh = GarageHandler.Instance();
            garage = gh.CreateGarage(gName, capacity);
            
        }

        [Fact]
        public void GarageAdd1Vehicle_Test()
        {
            var someRandomCar = Vehicle.CreateVehicle<Car>("PIP987", "Grey");
            var parked = gh.ParkVehicle(garage, someRandomCar);
            Assert.True(parked);
            Assert.Equal(1, garage.Count);
            Assert.True(gh.Contains(garage, someRandomCar));
        }

        [Fact]
        public void GarageAddMultipleVehicles_Test()
        {
            garage.EmptyGarage();

            // Create a few cars
            var car1 = Vehicle.CreateVehicle<Car>("ABC123", "Green");
            var car2 = Vehicle.CreateVehicle<Car>("DEF123", "White");
            var car3 = Vehicle.CreateVehicle<Car>("ABC456", "Red", FuelType.FuelCell);
            var car4 = Vehicle.CreateVehicle<Car>("DEF456", "Yellow");
            var car5 = Vehicle.CreateVehicle<Car>("XYZ999", "Black", FuelType.Ethanol);

            gh.ParkVehicle(garage, car1);
            gh.ParkVehicle(garage, car2);
            gh.ParkVehicle(garage, car3);
            gh.ParkVehicle(garage, car4);
            gh.ParkVehicle(garage, car5);

            Assert.True(gh.Contains(garage, car1));
            Assert.True(gh.Contains(garage, car2));
            Assert.Equal(5, garage.Count);
        }

        [Fact]
        public void GarageAddDuplicateVehicles_Test()
        {
            garage.EmptyGarage();
            Assert.Equal(0, garage.Count);

            // Create a few cars
            var car1 = Vehicle.CreateVehicle<Car>("ABC333", "Green");
            var car2 = Vehicle.CreateVehicle<Car>("DEF222", "White");
            var car3 = Vehicle.CreateVehicle<Car>("ABC111", "Red", FuelType.FuelCell);
            var car4 = Vehicle.CreateVehicle<Car>("DEF444", "Yellow");
            var car5 = Vehicle.CreateVehicle<Car>("XYZ555", "Black", FuelType.Ethanol);

            gh.ParkVehicle(garage, car1);
            gh.ParkVehicle(garage, car2);
            gh.ParkVehicle(garage, car1);
            gh.ParkVehicle(garage, car5);

            Assert.True(gh.Contains(garage, car1));
            Assert.True(gh.Contains(garage, car2));
            Assert.False(gh.Contains(garage, car3));
            Assert.Equal(3, garage.Count);
        }

 
        [Fact]
        public void GarageRemoveVehicle_Test()
        {
            // Create a few cars and park them in the grage
            var car1 = Vehicle.CreateVehicle<Car>("AAA123", "Green");
            var car2 = Vehicle.CreateVehicle<Car>("BBB123", "Green");
            var car3 = Vehicle.CreateVehicle<Car>("CCC456", "Green");
            var car4 = Vehicle.CreateVehicle<Car>("DDD456", "Green");
            var car5 = Vehicle.CreateVehicle<Car>("XXX999", "Green");
            gh.ParkVehicle(garage, car1);
            gh.ParkVehicle(garage, car2);
            gh.ParkVehicle(garage, car3);
            gh.ParkVehicle(garage, car4);
            gh.ParkVehicle(garage, car5);

            // Remove one of the parked cars
            var removed = gh.RemoveVehicle(garage, car2);

            // See if successful
            Assert.True(removed);
            Assert.True(gh.Contains(garage, car1));
            Assert.False(gh.Contains(garage, car2));
            Assert.Equal(4, garage.Count);
        }
 
        public void Dispose()
        {
        }
    }
}