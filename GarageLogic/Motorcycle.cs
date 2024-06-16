
public class Motorcycle : Vehicle
{
    public eLicenseType LicenseType { get; set; }
    public float EngineVolume { get; set; }
    public const int m_NumOfWheels = 2;
    public const int k_MaxAirPressure = 33;

    public Motorcycle(eEngineType i_EngineType) : base(m_NumOfWheels, k_MaxAirPressure)
    {
        if (i_EngineType == eEngineType.Gas)
        {
            GasEngine engine = new GasEngine();
            engine.MaxEnergy = 5.5f;
            engine.GasType = eGasType.Octan98;
            VehicleType = eVehicleType.GasMotorcycle;
            VehicleEngine = engine;
        }
        else
        {
            ElectricEngine engine = new ElectricEngine();
            engine.MaxEnergy = 2.5f;
            VehicleType = eVehicleType.ElectricMotorcycle;
            VehicleEngine = engine;
        }

        
    }

}

public enum eLicenseType
{
    A,
    A1,
    AA,
    B1
}