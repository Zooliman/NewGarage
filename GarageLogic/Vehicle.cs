public abstract class Vehicle
{
    public string ModelName { get; set; }
    public string LicensePlateNumber { get; set; }
    public float EnergyLeftPrecentage { get; set; }
    public Wheel[] Wheels { get; set; }
    public string OwnerName { get; set; }
    public string OwnerPhoneNumber { get; set; }
    public eVehicleStatus VehicleStatus { get; set; }
    public Engine VehicleEngine { get; set; }
    public eVehicleType VehicleType { get; set; }

    

    public Vehicle(int i_NumOfWheels, float i_MaxAirPressure)
    {
        VehicleStatus = eVehicleStatus.InFix;
        Wheels = new Wheel[i_NumOfWheels];
        for (int i = 0; i < i_NumOfWheels; i++)
        {
            Wheels[i] = new Wheel(i_MaxAirPressure);
        }
    }

    public void InflateWheelsToMax() // MAYBE MOVE TO WHEELS CLASS
    {
        foreach (Wheel wheel in Wheels)
        {
            wheel.InflateWheelToMax();
        }
    }

    // Equals
    public override bool Equals(object obj)
    {
        bool isEqual = false;
        Vehicle vehicle = obj as Vehicle;
        if (vehicle != null)
        {
            isEqual = LicensePlateNumber == vehicle.LicensePlateNumber;
        }

        return isEqual;
    }

    public enum eVehicleStatus
    {
        InFix,
        Fixed,
        Paid
    }

    public enum eEngineType
    {
        Gas,
        Electric
    }

    public enum eVehicleType
    {
        GasCar,
        ElectricCar,
        GasMotorcycle,
        ElectricMotorcycle,
        Truck
    }
}