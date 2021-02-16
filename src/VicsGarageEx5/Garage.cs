using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using VicsGarageEx5.Vehicles;

namespace VicsGarageEx5
{
    public class Garage<T> : IGarage<T> where T : IVehicle
    {
        public string Name { get ; set; }
        public int Capacity { get; }
        public int Count { get; set; }
        
        private T[] parkedVehicles;

        

        protected Garage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            parkedVehicles = new T[Capacity];
            Count = 0;
        }

        internal static Garage<T> CreateGarage(string name, int capacity)
        {
            return new Garage<T>(name, capacity);
        }

        /// <summary>
        /// Park a vehicle in this garage and return the spot number
        /// </summary>
        /// <param name="vehicle">Vehicle to be parked</param>
        /// <returns>Successful parking returns the number of the parking lot,
        /// unsuccessful parking return a negative number</returns>
        public int ParkVehicle(T vehicle)
        {
            if (Count >= Capacity || Contains(vehicle))
            {
                return -1;
            }
            int spot = FindFreeSpot();
            parkedVehicles[spot] = vehicle;
            Count++;
            return spot;
        }

        private int FindFreeSpot()
        {
            for (var i = 0; i < parkedVehicles.Length; i++)
            {
                if (parkedVehicles[i] is null)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Remove a parked vehicle. If this garage contains the vehicle then the removed vehicle is returned,
        /// otherwise null is returned.
        /// </summary>
        /// <param name="vehicle">Vehicle to remove from this garage</param>
        /// <returns>Removed vehicle if successful, otherwise null</returns>
        public T RemoveVehicle(T vehicle)
        {
            T result = default(T);
            for (var i = 0; i < parkedVehicles.Length; i++)
            {
                if (Count > 0 && parkedVehicles[i] is not null && parkedVehicles[i].Equals(vehicle))
                {
                    result = parkedVehicles[i];
                    parkedVehicles[i] = default(T);
                    Count--;
                    return result;
                }
            }
            return result;
        }

        public bool Contains(T vehicle)
        {
            foreach (var v in parkedVehicles)
            {
                if (v is not null && v.Equals(vehicle))
                {
                    return true;
                }
            }
            return false;
        }

        public void EmptyGarage()
        {
            for (var i = 0; i < parkedVehicles.Length; i++)
            {
                if (parkedVehicles[i] is not null)
                {
                    parkedVehicles[i] = default(T);
                    Count--;
                }
            }
            if (Count < 0)
            {
                throw new Exception("Count below 0");
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in parkedVehicles)
            {
                if (vehicle is not null)
                {
                    yield return vehicle;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Garage: Name: {Name}, Capacity: {Capacity}, Count: {Count}");
            if (Count > 0)
            {
                for (var i = 0; i < parkedVehicles.Length; i++)
                {
                    if (parkedVehicles[i] is not null)
                    {
                        sb.Append("\n\t");
                        sb.Append($"{i}: {parkedVehicles[i]}");
                    }
                }
            }
            return sb.ToString();
        }

        
    }
}
