using System.Collections;
using System.Collections.Generic;
using VicsGarageEx5.Vehicles;

namespace VicsGarageEx5
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public string Name {get; }
        public int Capacity { get; }
        public int Count { get; set; }
        private T[] vehicles;

        protected Garage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            vehicles = new T[Capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
