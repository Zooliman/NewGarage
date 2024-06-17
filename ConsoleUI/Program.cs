public class Program
{
    private static GarageManager s_GarageManager = new GarageManager();

    public static void Main()
    {

        Car car = new Car(Enums.eEngineType.Gas);
        car.LicensePlateNumber = "1234";
        s_GarageManager.AddVehicleToGarage(car);

        Motorcycle motorcycle = new Motorcycle(Enums.eEngineType.Electric);
        motorcycle.LicensePlateNumber = "3333";
        s_GarageManager.AddVehicleToGarage(motorcycle);

        bool isUserQuitted = false;

        while (!isUserQuitted)
        {
            Display.DisplayMainMenu();
            try
            {
                int userChoiceFromMenu = InputValidator.getUserSelectionFromMenu(1, 8);

                switch (userChoiceFromMenu)
                {
                    case 1:
                        InsertNewVehicle();
                        Console.WriteLine("Vehicle was successfully inserted to the garage.");
                        break;
                    case 2:
                        Display.DisplayFilterOptions();
                        FilterCurrentLicensePlates();
                        break;
                    case 3:
                        ChangeVehicleState();
                        Console.WriteLine("Vehicle status was successfully changed.");
                        break;
                    case 4:
                        InflateVehicleWheels();
                        Console.WriteLine("Vehicle's wheels were successfully inflated to the maximum.");
                        break;
                    case 5:
                        FuelGasVehicle();
                        Console.WriteLine("Vehicle was successfully refueled.");
                        break;
                    case 6:
                        ChargeBattery();
                        Console.WriteLine("Vehicle was successfully charged.");
                        break;
                    case 7:
                        PrintVehicleDetails();
                        break;
                    case 8:
                        isUserQuitted = true;
                        Console.WriteLine("Bye bye!");
                        break;
                    default:
                        System.Threading.Thread.Sleep(2000);
                        break;
                }

                if(!isUserQuitted)
                {
                    returnToMainMenu();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a number! " + ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static void returnToMainMenu()
    {
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadLine();
    }

    private static void PrintVehicleDetails()
    {
        string licensePlate = GetExistingVehicleLicensePlate();
        Vehicle vehicle = s_GarageManager.FindVehicleByLicensePlate(licensePlate);
        Console.WriteLine(vehicle);
    }

    private static void InsertNewVehicle()
    {
        string licensePlate = InputValidator.GetDetailsAboutVehicle("License Plate");
        Vehicle newVehicle;

        bool isValidVehicleDetails = false;

        while (!isValidVehicleDetails)
        {
            try
            {
                if (s_GarageManager.IsVehicleInGarage(licensePlate))
                {
                    newVehicle = s_GarageManager.FindVehicleByLicensePlate(licensePlate);
                    Console.WriteLine("Vehicle is already in the garage!");
                    Console.WriteLine("Vehicle status changed to 'InFix'");
                    newVehicle.VehicleStatus = Enums.eVehicleStatus.InFix;
                }
                else
                {
                    newVehicle = CreateNewVehicle(licensePlate);
                    s_GarageManager.AddVehicleToGarage(newVehicle);
                }
                isValidVehicleDetails = true;
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static Vehicle CreateNewVehicle(string licensePlate)
                {
                    Console.WriteLine("Vehicle is new!");
                    Display.DisplayVehicleOptions();

                    int vehicleType = InputValidator.getUserSelectionFromMenu(1, 5); // User selects the vehicle type
        Vehicle newVehicle;

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
                    newVehicle.setCurrentEnergy(float.Parse(vehicleCurrentEnergy));

                    string vehicleWheelsManufacturer = InputValidator.GetDetailsAboutVehicle("Wheels Manufacturer");
                    string vehicleCurrentAirPressure = InputValidator.GetDetailsAboutVehicle("Air Pressure");
                    initializeVehicleWheels(newVehicle, vehicleWheelsManufacturer, vehicleCurrentAirPressure);

        if (newVehicle is Car car)
                    {
                        string vehicleColor = InputValidator.GetDetailsAboutVehicle("Color");
            car.CarColor = (Enums.eCarColors)Enum.Parse(typeof(Enums.eCarColors), vehicleColor);

                        string vehicleNumOfDoors = InputValidator.GetDetailsAboutVehicle("Number of doors");
            car.NumOfDoors = (Enums.eNumOfDoors)Enum.Parse(typeof(Enums.eNumOfDoors), vehicleNumOfDoors);
                    }
        else if (newVehicle is Motorcycle motorcycle)
                    {
                        string vehicleLicenseType = InputValidator.GetDetailsAboutVehicle("License Type");
            motorcycle.LicenseType = (Enums.eLicenseType)Enum.Parse(typeof(Enums.eLicenseType), vehicleLicenseType);

                        string vehicleEngineVolume = InputValidator.GetDetailsAboutVehicle("Engine Volume");
            motorcycle.EngineVolume = float.Parse(vehicleEngineVolume);
                    }
        else if (newVehicle is Truck truck)
                    {
                        string vehicleCarryingCapacity = InputValidator.GetDetailsAboutVehicle("Carrying Capacity");
            truck.CargoVolume = float.Parse(vehicleCarryingCapacity);

                        bool isCarryingDangerousMaterials = InputValidator.IsCarryingDangerousMaterials();
            truck.IsCarryingDangerousMaterials = isCarryingDangerousMaterials;
                    }

                    newVehicle.LicensePlateNumber = licensePlate;
        return newVehicle;
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

        if (filterOption == 1) // display all the vehicles in the garage
            {
                foreach (Vehicle vehicle in s_GarageManager.m_VehiclesInGarage)
                {
                    licensePlateNumbers.Add(vehicle.LicensePlateNumber);
                }
            }
            else
            {
            status = (Enums.eVehicleStatus)(filterOption - 1);

                List<Vehicle> filteredLicensePlates = s_GarageManager.m_VehiclesInGarage.Where(vehicle => vehicle.VehicleStatus == status).ToList();
                foreach (Vehicle vehicle in filteredLicensePlates)
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
            string licensePlate = GetExistingVehicleLicensePlate();
            Display.DisplayVehicleStates();
            int vehicleState = InputValidator.getUserSelectionFromMenu(1, 3);

        Enums.eVehicleStatus status = (Enums.eVehicleStatus)(vehicleState - 1);
            s_GarageManager.FindVehicleByLicensePlate(licensePlate).VehicleStatus = status;
        }

        private static void InflateVehicleWheels()
        {
            string licensePlate = GetExistingVehicleLicensePlate();
        s_GarageManager.FindVehicleByLicensePlate(licensePlate).InflateWheelsToMax();
        }

        private static void FuelGasVehicle()
        {
            bool isFueled = false;

            while (!isFueled)
            {
                try
                {
                string licensePlate = GetExistingVehicleLicensePlate();
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
            Enums.eGasType gasType = (Enums.eGasType)(chosenGasType - 1);

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

    private static string GetExistingVehicleLicensePlate()
        {
            bool isExists = false;
            string licensePlateNumber = "";
            while (!isExists)
            {
                try
                {
                    licensePlateNumber = InputValidator.GetDetailsAboutVehicle("License Plate");
                Vehicle vehicle = s_GarageManager.FindVehicleByLicensePlate(licensePlateNumber);
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
