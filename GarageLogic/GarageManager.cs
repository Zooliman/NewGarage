public class GarageManager
    {
        /*static void Main()
        {
            GarageManager garageManager = new GarageManager();
            garageManager.AddVehicleToGarage("1234");
            
        }*/
        public List<Vehicle> m_VehiclesInGarage = new List<Vehicle>();

        public void AddVehicleToGarage(string i_LicensePlateNumber)
        {
            Vehicle vehicle = new Car(Enums.eEngineType.Gas);
            vehicle.LicensePlateNumber = i_LicensePlateNumber;
            m_VehiclesInGarage.Add(vehicle);
/*
            Motorcycle suzuki = new Motorcycle(Vehicle.eEngineType.Gas);
            suzuki.ModelName = "R750";
            m_VehiclesInGarage.Add(suzuki);

            Truck scania = new Truck();
            scania.VehicleStatus = Vehicle.eVehicleStatus.Paid;
            scania.IsCarryingDangerousMaterials = true;
            m_VehiclesInGarage.Add(scania);*/

        }

        public bool IsVehicleInGarage(string i_LicensePlateNumber)
        {
            bool isVehicleInGarage = false;
            foreach (Vehicle vehicleInGarage in m_VehiclesInGarage)
            {
                if (vehicleInGarage.LicensePlateNumber == i_LicensePlateNumber)
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
                if (vehicleInGarage.LicensePlateNumber == i_LicensePlateNumber)
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