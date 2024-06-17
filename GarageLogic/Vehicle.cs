using System.Text;

public abstract class Vehicle
{
    public float EnergyLeftPercentage { get; set; }
    public string ModelName { get; set; }
    public string LicensePlateNumber { get; set; }
    public Wheel[] Wheels { get; set; }
    public string OwnerName { get; set; }
    public string OwnerPhoneNumber { get; set; }
    public Enums.eVehicleStatus VehicleStatus { get; set; }
    public Engine VehicleEngine { get; set; }
    public Enums.eVehicleType VehicleType { get; set; }

    public Vehicle(int i_NumOfWheels, float i_MaxAirPressure)
    {
        Wheels = new Wheel[i_NumOfWheels];
        for (int i = 0; i < i_NumOfWheels; i++)
        {
            Wheels[i] = new Wheel(i_MaxAirPressure);
        }
    }
    public void SetCurrentEnergy(float i_CurrentEnergy)
    {
        VehicleEngine.CurrentEnergy = i_CurrentEnergy;
        updateEnergyLeftPercentage();
    }

    private void updateEnergyLeftPercentage()
    {
        EnergyLeftPercentage = (VehicleEngine.CurrentEnergy / VehicleEngine.MaxEnergy) * 100;
    }
    

    public void InflateWheelsToMax()
    {
        foreach (Wheel wheel in Wheels)
        {
            wheel.InflateWheelToMax();
        }
    }

    public void Charge(float i_AmountToCharge, Enums.eGasType i_GasType)
    {
        if (VehicleEngine is GasEngine gasEngine)
        {
            gasEngine.Fuel(i_AmountToCharge, i_GasType);
            updateEnergyLeftPercentage();
        }
        else
        {
            throw new ArgumentException("Invalid engine type");
        }
    }

    public void Charge(float i_AmountToCharge)
    {
        if (VehicleEngine is ElectricEngine electricEngine)
        {
            electricEngine.ChargeBattery(i_AmountToCharge);
            updateEnergyLeftPercentage();
        }
        else
        {
            throw new ArgumentException("Invalid engine type");
        }
    }

    public override string ToString()
    {
        StringBuilder vehicleDetails = new StringBuilder();
        vehicleDetails.AppendLine($"License Plate Number: {LicensePlateNumber}");
        vehicleDetails.AppendLine($"Model Name: {ModelName}");
        vehicleDetails.AppendLine($"Owner Name: {OwnerName}");
        vehicleDetails.AppendLine($"Owner Phone Number: {OwnerPhoneNumber}");
        vehicleDetails.AppendLine($"Condition in the Garage: {VehicleStatus}");
        vehicleDetails.AppendLine($"Energy Left Percentage: {EnergyLeftPercentage}%");
        vehicleDetails.AppendLine($"Vehicle Type: {VehicleType}");
        vehicleDetails.AppendLine("Wheels Details:");
        foreach (Wheel wheel in Wheels)
        {
            vehicleDetails.AppendLine($"\tManufacturer: {wheel.ManufacturerName}, Air Pressure: {wheel.CurrentAirPressure}/{wheel.MaxAirPressure}");
        }

        return vehicleDetails.ToString();
    }
}
