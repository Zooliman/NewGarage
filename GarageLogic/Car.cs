
public class Car : Vehicle
{
    public eCarColors CarColor { get; set; }
    public eNumOfDoors NumOfDoors { get; set; }

    public const int k_NumOfWheels = 5;
    public const int k_MaxAirPressure = 31;

    public Car(eEngineType i_EngineType) : base(k_NumOfWheels, k_MaxAirPressure)
    {
    if (i_EngineType == eEngineType.Gas)
        {
            GasEngine engine = new GasEngine();
            engine.MaxEnergy = 45;
            engine.GasType = eGasType.Octan95;
            VehicleType = eVehicleType.GasCar;
            VehicleEngine = engine;
        }
        else
        {
            ElectricEngine engine = new ElectricEngine();
            engine.MaxEnergy = 3.5f;
            VehicleType = eVehicleType.ElectricCar;
            VehicleEngine = engine;
        }

    }   
}

public enum eCarColors
{
    Yellow,
    White,
    Red,
    Black
}
public enum eNumOfDoors
{
    Two,
    Three,
    Four,
    Five
}