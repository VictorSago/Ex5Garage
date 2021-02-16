using System.Runtime.InteropServices;
using System.Reflection;
using System;
using Xunit;
//using VicsGarageEx5.Vehicles;

namespace VicsGarageEx5.Tests
{
    public class GarageHandlerTests : IDisposable
    {
        protected GarageHandler gh;

        public GarageHandlerTests()
        {
            gh = GarageHandler.Instance();
        }

        [Fact]
        public void GarageHandlerSingleInstance_Test()
        {
            var gh1 = GarageHandler.Instance();
            var gh2 = GarageHandler.Instance();

            Assert.Same(gh1, gh2);
        }

        [Fact]
        public void GarageHandlerCreateGarage_Test()
        {
            string name = "GarageNo1";
            uint capacity = 10;

            var garage = gh.CreateGarage(name, capacity);

            Assert.Same(garage, gh.Current);
        }

        [Fact]
        public void GarageHandlerCreateMultipleGarages_Test()
        {
            string name1 = "GarageNo1";
            string name2 = "GarageNo2";
            string name3 = "GarageNo3";
            uint capacity = 10;

            var garage1 = gh.CreateGarage(name1, capacity);
            var garage2 = gh.CreateGarage(name2, capacity);
            var garage3 = gh.CreateGarage(name3, capacity);

            Assert.Same(garage3, gh.Current);
        }

        public void Dispose()
        {
        }
    }
}
