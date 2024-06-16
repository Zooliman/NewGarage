public class GarageManager
{
    public List<Vehicle> m_VehiclesInGarage = new List<Vehicle>();

    public void AddVehicleToGarage(string i_LicensePlateNumber)
    {
        Vehicle vehicle = new Car(Vehicle.eEngineType.Gas);
        vehicle.LicensePlateNumber = i_LicensePlateNumber;
        m_VehiclesInGarage.Add(vehicle);
    }

    public Vehicle FindVehicleByLicensePlate(string i_LicensePlateNumber)
    {
        Vehicle vehicle = null;
        foreach (Vehicle vehicleInGarage in m_VehiclesInGarage)
        {
            if (vehicleInGarage.LicensePlateNumber == i_LicensePlateNumber)
            {
                vehicle = vehicleInGarage;
                break;
            }
        }

        return vehicle;
    }
}