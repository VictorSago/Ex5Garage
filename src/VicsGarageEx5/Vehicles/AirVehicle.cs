namespace VicsGarageEx5.Vehicles
{
    public class AirVehicle : Vehicle
    {
        public double Weight { get; set; }
        public AirVehicle()
        {
        }

        public virtual void Initialize(string registration, string color, FuelType fuel, double weight)
        {
            base.Initialize(registration, color, fuel);
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {Weight:3} tonnes";
        }
    }
}