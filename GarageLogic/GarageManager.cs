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

    public Vehicle CreateVehicleInstance(string i_LicensePlate, int i_VehicleType)
    {
        Vehicle newVehicle;
        switch ((Enums.eVehicleType)i_VehicleType)
        {
            case Enums.eVehicleType.GasCar:
                newVehicle = new Car(Enums.eEngineType.Gas);
                break;
            case Enums.eVehicleType.ElectricCar:
                newVehicle = new Car(Enums.eEngineType.Electric);
                break;
            case Enums.eVehicleType.GasMotorcycle:
                newVehicle = new Motorcycle(Enums.eEngineType.Gas);
                break;
            case Enums.eVehicleType.ElectricMotorcycle:
                newVehicle = new Motorcycle(Enums.eEngineType.Electric);
                break;
            case Enums.eVehicleType.Truck:
                newVehicle = new Truck();
                break;
            default:
                throw new ValueOutOfRangeException(1, 5);
        }

        newVehicle.LicensePlateNumber = i_LicensePlate;
        
        return newVehicle;
    }
}