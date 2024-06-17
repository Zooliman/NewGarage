public class GarageManager
{
    public List<Vehicle> m_VehiclesInGarage = new List<Vehicle>();

    public void AddVehicleToGarage(Vehicle vehicle)
    {
        m_VehiclesInGarage.Add(vehicle);
    }

    public bool IsVehicleInGarage(string i_LicensePlateNumber)
    {
        bool isVehicleInGarage = false;
        foreach (Vehicle vehicleInGarage in m_VehiclesInGarage)
        {
            if (vehicleInGarage.LicensePlateNumber.Equals(i_LicensePlateNumber))
            {
                isVehicleInGarage = true;
                break;
            }
        }

        return isVehicleInGarage;
    }

    public Vehicle FindVehicleByLicensePlate(string i_LicensePlateNumber)
    {
        Vehicle vehicle = null;
        foreach (Vehicle vehicleInGarage in m_VehiclesInGarage)
        {
            if (vehicleInGarage.LicensePlateNumber.Equals(i_LicensePlateNumber))
            {
                vehicle = vehicleInGarage;
                break;
            }
        }
        if (vehicle == null)
        {
            throw new ArgumentException("This vehicle is not in the garage!");
        }

        return vehicle;
    }
}