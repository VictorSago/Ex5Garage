using System;
using System.Collections.Generic;
using VicsGarageEx5.Vehicles;
using Xunit;

namespace VicsGarageEx5.Tests
{
    public class GarageTests : IDisposable
    {
        protected GarageHandler ghandler;
        protected VehicleRegistry vregistry;
        protected IGarage<IVehicle> garage;
        
        /** 
          * Interference between tests necessitates creation of different
          * vehicle instances for each test
        **/
        public GarageTests()
        {
            var gName = "GarageNo6";
            var capacity = 42u;
            ghandler = GarageHandler.Instance();
            garage = ghandler.CreateGarage(gName, capacity);
            
        }

        [Fact]
        public void GarageAdd1Vehicle_Test()
        {
            var someRandomCar = vregistry.CreateVehicle<Car>("PIP987", "Grey");
            var parked = ghandler.ParkVehicle(garage, someRandomCar);
            Assert.True(parked);
            Assert.Equal(1, garage.Count);
            Assert.True(ghandler.Contains(garage, someRandomCar));
        }

        [Fact]
        public void GarageAddMultipleVehicles_Test()
        {
            garage.EmptyGarage();

            // Create a few cars
            var car1 = vregistry.CreateVehicle<Car>("ABC123", "Green");
            var car2 = vregistry.CreateVehicle<Car>("DEF123", "White");
            var car3 = vregistry.CreateVehicle<Car>("ABC456", "Red", FuelType.FuelCell);
            var car4 = vregistry.CreateVehicle<Car>("DEF456", "Yellow");
            var car5 = vregistry.CreateVehicle<Car>("XYZ999", "Black", FuelType.Ethanol);

            ghandler.ParkVehicle(garage, car1);
            ghandler.ParkVehicle(garage, car2);
            ghandler.ParkVehicle(garage, car3);
            ghandler.ParkVehicle(garage, car4);
            ghandler.ParkVehicle(garage, car5);

            Assert.True(ghandler.Contains(garage, car1));
            Assert.True(ghandler.Contains(garage, car2));
            Assert.Equal(5, garage.Count);
        }

        [Fact]
        public void GarageAddDuplicateVehicles_Test()
        {
            garage.EmptyGarage();
            Assert.Equal(0, garage.Count);

            // Create a few cars
            var car1 = vregistry.CreateVehicle<Car>("ABC333", "Green");
            var car2 = vregistry.CreateVehicle<Car>("DEF222", "White");
            var car3 = vregistry.CreateVehicle<Car>("ABC111", "Red", FuelType.FuelCell);
            var car4 = vregistry.CreateVehicle<Car>("DEF444", "Yellow");
            var car5 = vregistry.CreateVehicle<Car>("XYZ555", "Black", FuelType.Ethanol);

            ghandler.ParkVehicle(garage, car1);
            ghandler.ParkVehicle(garage, car2);
            ghandler.ParkVehicle(garage, car1);
            ghandler.ParkVehicle(garage, car5);

            Assert.True(ghandler.Contains(garage, car1));
            Assert.True(ghandler.Contains(garage, car2));
            Assert.False(ghandler.Contains(garage, car3));
            Assert.Equal(3, garage.Count);
        }

 
        [Fact]
        public void GarageRemoveVehicle_Test()
        {
            // Create a few cars and park them in the grage
            var car1 = vregistry.CreateVehicle<Car>("AAA123", "Green");
            var car2 = vregistry.CreateVehicle<Car>("BBB123", "Green");
            var car3 = vregistry.CreateVehicle<Car>("CCC456", "Green");
            var car4 = vregistry.CreateVehicle<Car>("DDD456", "Green");
            var car5 = vregistry.CreateVehicle<Car>("XXX999", "Green");
            ghandler.ParkVehicle(garage, car1);
            ghandler.ParkVehicle(garage, car2);
            ghandler.ParkVehicle(garage, car3);
            ghandler.ParkVehicle(garage, car4);
            ghandler.ParkVehicle(garage, car5);

            // Remove one of the parked cars
            var removed = ghandler.RemoveVehicle(garage, car2);

            // See if successful
            Assert.True(removed);
            Assert.True(ghandler.Contains(garage, car1));
            Assert.False(ghandler.Contains(garage, car2));
            Assert.Equal(4, garage.Count);
        }
 
        public void Dispose()
        {
        }
    }
}