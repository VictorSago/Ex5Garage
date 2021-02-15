namespace VicsGarageEx5.Vehicles
{
    public interface IVehicle
    {
        string RegistrationID { get; set; }
        string Color { get; set; }
        FuelType FuelType { get; set; }
    }
}