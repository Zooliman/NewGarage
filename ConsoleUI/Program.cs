public class Program
{
    public static void Main()
    {
        GarageManager garageManager = new GarageManager();
        garageManager.AddVehicleToGarage("1234");
        Vehicle vehicle = garageManager.FindVehicleByLicensePlate("1234");
        Console.WriteLine(vehicle.LicensePlateNumber);
    }
}