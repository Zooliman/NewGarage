public class Program
    {
        private static GarageManager s_GarageManager = new GarageManager();

        public static void Main()
        {

            s_GarageManager.AddVehicleToGarage("1234");
            s_GarageManager.m_VehiclesInGarage[0].VehicleStatus = Enums.eVehicleStatus.Paid;

            s_GarageManager.AddVehicleToGarage("5555");
            s_GarageManager.m_VehiclesInGarage[1].VehicleStatus = Enums.eVehicleStatus.Fixed;

            s_GarageManager.AddVehicleToGarage("41444");
            s_GarageManager.m_VehiclesInGarage[2].VehicleStatus = Enums.eVehicleStatus.Paid;


            Display.DisplayMainMenu();
            try
            {
                int userChoiceFromMenu = InputValidator.getUserSelectionFromMenu(1, 8);

                switch (userChoiceFromMenu)
                {
                    case 1:
                        InsertNewVehicle();
                        break;
                    case 2:
                        Display.DisplayFilterOptions();
                        FilterCurrentLicensePlates();
                        break;
                    case 3:
                        ChangeVehicleState();
                        break;

                    case 4:
                        InflateVehicleWheels();
                        break;

                    case 5:
                        FuelGasVehicle();
                        break;

                    case 6:
                        ChargeBattery();
                        break;

                    case 7:
                        PrintVehicleDetails();
                        break;

                    default:
                        break;
                }
                Console.ReadLine();

            }
            catch (FormatException ex)
            {
                System.Console.WriteLine("Please enter a number!" + ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }

    private static void PrintVehicleDetails()
    {
        string licensePlate = GetExistingVehicleLicensePlate();
        Vehicle vehicle = s_GarageManager.FindVehicleByLicensePlate(licensePlate);
        Console.WriteLine(vehicle.ToString());
    }

    private static void InsertNewVehicle()
        {
            string licensePlate = InputValidator.GetDetailsAboutVehicle("License Plate");
            Vehicle newVehicle;
            
            if (s_GarageManager.IsVehicleInGarage(licensePlate))
            {
                newVehicle = s_GarageManager.FindVehicleByLicensePlate(licensePlate);
                Console.WriteLine("Vehicle is already in the garage!");
                Console.WriteLine("Vehicle status changed to 'InFix'");
                newVehicle.VehicleStatus = Enums.eVehicleStatus.InFix;
            }
            else
            {
                Console.WriteLine("Vehicle is new!");
                Display.DisplayVehicleOptions();

                int vehicleType = InputValidator.getUserSelectionFromMenu(1, 5); // User selects the vehicle type
                switch ((Enums.eVehicleType)vehicleType)
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
            
                string vehicleModelName = InputValidator.GetDetailsAboutVehicle("Model Name");
                newVehicle.ModelName = vehicleModelName;

                string ownerName = InputValidator.GetDetailsAboutVehicle("Owner Name");
                newVehicle.OwnerName = ownerName;

                string ownerPhoneNumber = InputValidator.GetDetailsAboutVehicle("Owner Phone Number");
                newVehicle.OwnerPhoneNumber = ownerPhoneNumber;

                string vehicleCurrentEnergy = InputValidator.GetDetailsAboutVehicle("Current Energy");
                newVehicle.EnergyLeftPrecentage = float.Parse(vehicleCurrentEnergy);

                string vehicleWheelsManufacturer = InputValidator.GetDetailsAboutVehicle("Wheels Manufacturer");
                string vehicleCurrentAirPressure = InputValidator.GetDetailsAboutVehicle("Air Pressure");
                initializeVehicleWheels(newVehicle, vehicleWheelsManufacturer, vehicleCurrentAirPressure);

                if (vehicleType == 1 || vehicleType == 2) // GasCar or ElectricCar
                {
                    string vehicleColor = InputValidator.GetDetailsAboutVehicle("Color");
                    ((Car)newVehicle).CarColors = (Enums.eCarColors)Enum.Parse(typeof(Enums.eCarColors), vehicleColor);

                    string vehicleNumOfDoors = InputValidator.GetDetailsAboutVehicle("Number of doors");
                    ((Car)newVehicle).NumOfDoors = (Enums.eNumOfDoors)Enum.Parse(typeof(Enums.eNumOfDoors), vehicleNumOfDoors);
                }
                else if (vehicleType == 3 || vehicleType == 4) // GasMotorcycle or ElectricMotorcycle
                {
                    string vehicleLicenseType = InputValidator.GetDetailsAboutVehicle("License Type");
                    ((Motorcycle)newVehicle).LicenseType = (Enums.eLicenseType)Enum.Parse(typeof(Enums.eLicenseType), vehicleLicenseType);

                    string vehicleEngineVolume = InputValidator.GetDetailsAboutVehicle("Engine Volume");
                    ((Motorcycle)newVehicle).EngineVolume = float.Parse(vehicleEngineVolume);
                }
                else if (vehicleType == 5) // Truck
                {
                    string vehicleCarryingCapacity = InputValidator.GetDetailsAboutVehicle("Carrying Capacity");
                    ((Truck)newVehicle).CargoVolume = float.Parse(vehicleCarryingCapacity);

                    string isCarryingDangerousMaterials = InputValidator.IsCarryingDangerousMaterials();
                    ((Truck)newVehicle).IsCarryingDangerousMaterials = bool.Parse(isCarryingDangerousMaterials);
                }
            }
        }

    private static void initializeVehicleWheels(Vehicle i_NewVehicle, string i_VehicleWheelsManufacturer, string vehicleCurrentAirPressure)
    {
        float currentAirPressure = float.Parse(vehicleCurrentAirPressure);
        foreach (Wheel wheel in i_NewVehicle.Wheels)
        {
            wheel.ManufacturerName = i_VehicleWheelsManufacturer;
            wheel.CurrentAirPressure = currentAirPressure;
        }
    }

    private static void FilterCurrentLicensePlates()
        {
            Enums.eVehicleStatus status = Enums.eVehicleStatus.InFix;
            List<string> licensePlateNumbers = new List<string>();

            int filterOption = InputValidator.getUserSelectionFromMenu(1, 4);

            if (filterOption == 1) //display all the vehicles in the garage
            {
                //licenseIDS = s_GarageManager.VehicelsInGarage.Keys.ToList();
                foreach (Vehicle vehicle in s_GarageManager.m_VehiclesInGarage)
                {
                    licensePlateNumbers.Add(vehicle.LicensePlateNumber);
                }
            }
            else
            {
                if (filterOption == 2) //infix
                {
                    status = Enums.eVehicleStatus.InFix;
                }

                else if (filterOption == 3) //fixed
                {
                    status = Enums.eVehicleStatus.Fixed;
                }
                else //paid
                {
                    status = Enums.eVehicleStatus.Paid;
                }

                List<Vehicle> v = s_GarageManager.m_VehiclesInGarage.Where(vehicle => vehicle.VehicleStatus == status).ToList();
                foreach (Vehicle vehicle in v)
                {
                    licensePlateNumbers.Add(vehicle.LicensePlateNumber);
                }

            }

            if (licensePlateNumbers.Count == 0)
            {
                Console.WriteLine("There are no {0} vehicles in the garage right now.", status);
            }
            else
            {
                int carNumber = 1;
                foreach (string licensePlateNumber in licensePlateNumbers)
                {
                    Console.WriteLine("{0}. {1}", carNumber++, licensePlateNumber);
                }
            }
        }


        private static void ChangeVehicleState()
        {
            Enums.eVehicleStatus status = Enums.eVehicleStatus.InFix;

            string licensePlate = GetExistingVehicleLicensePlate();
            Display.DisplayVehicleStates();
            int vehicleState = InputValidator.getUserSelectionFromMenu(1, 3);

            switch (vehicleState)
            {
                case 1:
                    status = Enums.eVehicleStatus.InFix;
                    break;

                case 2:
                    status = Enums.eVehicleStatus.Fixed;
                    break;

                case 3:
                    status = Enums.eVehicleStatus.Paid;
                    break;
            }

            s_GarageManager.FindVehicleByLicensePlate(licensePlate).VehicleStatus = status;
        }

       
        private static void InflateVehicleWheels()
        {
            string licensePlate = GetExistingVehicleLicensePlate();
            Display.DisplayInflateOptions();
            int userChoice = InputValidator.getUserSelectionFromMenu(1, 2);

            Vehicle vehicle = s_GarageManager.FindVehicleByLicensePlate(licensePlate); // was inside of the for loop changed for readability

            vehicle.InflateWheelsToMax();
        }
      

        private static void FuelGasVehicle()
   { 
       bool isFueled = false;

       while (!isFueled)
       {
           try
           {
               string licensePlate = GetExistingVehicleLicensePlate();//step 1 
               isFueled = isValidGasType(licensePlate);

           }
           catch (ArgumentException ex)
           {
               Console.WriteLine(ex.Message);
           }
       }

   }

    private static bool isValidGasType(string i_LicensePlate)
    {
        bool isValidGas = false;
        try
        {
            Display.DisplayGasTypes();
            int chosenGasType = InputValidator.getUserSelectionFromMenu(1, 4);
            Enums.eGasType gasType;

            switch (chosenGasType)
            {
                case 1:
                    gasType = Enums.eGasType.Soler;
                    break;
                case 2:
                    gasType = Enums.eGasType.Octan95;
                    break;
                case 3:
                    gasType = Enums.eGasType.Octan96;
                    break;
                case 4:
                    gasType = Enums.eGasType.Octan98;
                    break;
                default:
                    gasType = Enums.eGasType.Soler;
                    break;

            }

            float gasAmountToAdd = InputValidator.GetEnergyAmountToAdd();

            Vehicle vehicleToFuel = s_GarageManager.FindVehicleByLicensePlate(i_LicensePlate);
            vehicleToFuel.Charge(gasAmountToAdd, gasType);
            
            isValidGas = true;
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException(ex.Message);
        }
        catch (ValueOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

       return isValidGas;
   }

   
private static void ChargeBattery()
{
    bool isCharged = false;

    while (!isCharged)
    {
        try
        {
            string licensePlate = GetExistingVehicleLicensePlate();
            isCharged = isValidAmountOfBattery(licensePlate);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

        private static bool isValidAmountOfBattery(string i_LicensePlate)
{
    bool isValidAmountOfBatteryToAdd = false;
    while (!isValidAmountOfBatteryToAdd)
    {
        try
        {
            float BatteryAmountToAdd = InputValidator.GetEnergyAmountToAdd();

            Vehicle vehicleToCharge = s_GarageManager.FindVehicleByLicensePlate(i_LicensePlate);
            vehicleToCharge.Charge(BatteryAmountToAdd);

            isValidAmountOfBatteryToAdd = true;
        }

        catch (ValueOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
       catch (ArgumentException ex)
       {
           throw new ArgumentException(ex.Message);
       }

   }
    return isValidAmountOfBatteryToAdd;
}
        
        private static bool CheckVehicleType(string i_LicensePlate, Enums.eEngineType i_EngineType) // maybe needs to move to logic
        {
            bool isValidVehicleType = false;
            Vehicle vehicle = s_GarageManager.FindVehicleByLicensePlate(i_LicensePlate);
            if (vehicle.VehicleType.Equals(i_EngineType))
            {
                isValidVehicleType = true;
            }
            else
            {
                throw new ArgumentException("The license plate number you gave is not a {0}", i_EngineType.ToString());
            }
            return isValidVehicleType;
        }
 

        public static string GetExistingVehicleLicensePlate()
        {
            bool isExists = false;
            string licensePlateNumber = "";
            while (!isExists)
            {
                try
                {
                    licensePlateNumber = InputValidator.GetDetailsAboutVehicle("License Plate");
                    Vehicle vehicle = s_GarageManager.FindVehicleByLicensePlate(licensePlateNumber); // changed from isVehicleInGarage
                    isExists = true;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return licensePlateNumber;
        }
    }
