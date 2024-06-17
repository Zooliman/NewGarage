using System.Text;

public class Car : Vehicle
    {
        public const int k_MinNumberOfDoors = 2;
        public const int k_MaxNumOfDoors = 5;
        public Enums.eNumOfDoors NumOfDoors { get; set; }
        public Enums.eCarColors CarColor { get; set; }

        public const int k_NumOfWheels = 5;
        public const int k_MaxAirPressure = 31;

        public Car(Enums.eEngineType i_EngineType) : base(k_NumOfWheels, k_MaxAirPressure)
        {
            if (i_EngineType == Enums.eEngineType.Gas)
            {
                GasEngine engine = new GasEngine();
                engine.MaxEnergy = 45;
                engine.GasType = Enums.eGasType.Octan95;
                VehicleType = Enums.eVehicleType.GasCar;
                VehicleEngine = engine;
            }
            else if (i_EngineType == Enums.eEngineType.Electric)
            {
                ElectricEngine engine = new ElectricEngine();
                engine.MaxEnergy = 3.5f;
                VehicleType = Enums.eVehicleType.ElectricCar;
                VehicleEngine = engine;
            }

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(string.Format("Number of doors: {0}\nCar color: {1}", NumOfDoors, CarColor));
            stringBuilder.AppendLine(VehicleEngine.ToString());
            return stringBuilder.ToString();
        }
    
    }