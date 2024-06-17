using System.Text;

public class Motorcycle : Vehicle
    {
        public Enums.eLicenseType LicenseType { get; set; }
        public float EngineVolume { get; set; }
        public const int k_NumOfWheels = 2;
        public const int k_MaxAirPressure = 33;

        public Motorcycle(Enums.eEngineType i_EngineType) : base(k_NumOfWheels, k_MaxAirPressure)
        {
            Wheels = new Wheel[k_NumOfWheels];
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels[i] = new Wheel(k_MaxAirPressure);
            }

            if (i_EngineType == Enums.eEngineType.Gas)
            {
                GasEngine engine = new GasEngine();
                engine.MaxEnergy = 5.5f;
                engine.GasType = Enums.eGasType.Octan98;
                VehicleType = Enums.eVehicleType.GasMotorcycle;
                VehicleEngine = engine;
            }
            else
            {
                ElectricEngine engine = new ElectricEngine();
                engine.MaxEnergy = 2.5f;
                VehicleType = Enums.eVehicleType.ElectricMotorcycle;
                VehicleEngine = engine;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(string.Format("License type: {0}\nEngine volume: {1}", LicenseType, EngineVolume));
            stringBuilder.AppendLine(VehicleEngine.ToString());
            return stringBuilder.ToString();
        }

    }