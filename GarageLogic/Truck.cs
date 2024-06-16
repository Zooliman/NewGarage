public class Truck : Vehicle
    {
        public bool IsCarryingDangerousMaterials { get; set; }
        public float CargoVolume { get; set; }

        public const int m_NumOfWheels = 12;
        public const int k_MaxAirPressure = 28;


        public Truck() : base(m_NumOfWheels, k_MaxAirPressure)
        {
            GasEngine engine = new GasEngine();
            engine.MaxEnergy = 120;
            VehicleType = Enums.eVehicleType.Truck;
            engine.GasType = Enums.eGasType.Soler;
        }


    }
