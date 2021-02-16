using System.Collections.Generic;
using VicsGarageEx5.Vehicles;

namespace VicsGarageEx5
{
    public interface IGarage<T> : IEnumerable<T> where T : IVehicle
    {
        string Name { get; set; }
        uint Capacity { get; }
        int Count { get; set; }

        int ParkVehicle(T vehicle);

        T RemoveVehicle(T vehicle);

        public bool Contains(T vehicle);

        public void EmptyGarage();

    }
}