namespace VicsGarageEx5.Vehicles
{
    public class WaterVehicle : Vehicle
    {
        double Displacement { get; set; }
        public WaterVehicle()
        {
        }

        public virtual void Initialize(string registration, string color, FuelType fuel, double displacement)
        {
            base.Initialize(registration, color, fuel);
            Displacement = displacement;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {Displacement:3} tonnes";
        }

    }
}