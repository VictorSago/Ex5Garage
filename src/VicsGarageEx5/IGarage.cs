using System.Collections.Generic;
using VicsGarageEx5.Vehicles;

namespace VicsGarageEx5
{
    public interface IGarage<T> : IEnumerable<T> where T : IVehicle
    {
        string Name { get; set; }
        int Capacity { get; }
        int Count { get; set; }
    }
}