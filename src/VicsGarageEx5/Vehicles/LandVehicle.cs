
namespace VicsGarageEx5.Vehicles
{
    public class LandVehicle : Vehicle
    {
        uint NumberOfWheels { get; set; }

        protected LandVehicle() : base()
        {
        }

        public virtual void Initialize(string registration, string color, FuelType fuel, uint numberOfWheels)
        {
            base.Initialize(registration, color, fuel);
            NumberOfWheels = numberOfWheels;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {NumberOfWheels} wheels";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}