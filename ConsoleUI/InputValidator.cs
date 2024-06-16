class InputValidator
    {
        // private const int MENU_CHOICES = 8;

        public static int getUserSelectionFromMenu(int i_MinValue, int i_MaxValue)
        {
            bool isValidType = false;
            int userSelection = 0;

            while (!isValidType)
            {
                try
                {
                    string userInput = Console.ReadLine();
                    userSelection = int.Parse(userInput);
                    isValidType = checkForValidInput(userSelection, i_MinValue, i_MaxValue);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine("Please enter a number!" + ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            return userSelection;
        }

        private static bool checkForValidInput(int i_UserSelection, int i_MinValue, int i_MaxValue)
        {
            bool isValidType = false;
            if (i_UserSelection >= i_MinValue && i_UserSelection <= i_MaxValue)
            {
                isValidType = true;
            }
            else
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue);
            }

            return isValidType;
        }

        public static string GetDetailsAboutVehicle(string i_DetailsType)
        {
            // Console.Clear();
            System.Console.WriteLine("Please enter the vehicle's " + i_DetailsType + ": ");
            return Console.ReadLine();
        }

        public static string IsCarryingDangerousMaterials()
        {
            Console.Clear();
            System.Console.WriteLine("Is the vehicle carrying dangerous materials? (Y/N): ");
            return Console.ReadLine();
        }

       /* internal static Dictionary<string, object> ValidateAndGetVehicleDetails(Dictionary<string, object> vehicleDetails)
        {
            Dictionary<string, object> validatedVehicleDetails = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> detail in vehicleDetails)
            {
                switch (detail.Key)
                {
                    case "VehicleType":
                        GarageManager.eVehicleType vehicleType = GetVehicleType(detail.Value);
                        validatedVehicleDetails.Add("VehicleType", vehicleType);
                        break;

                    case "OwnerName":
                        string ownerName = (string)detail.Value;
                        if (ownerName.Length > 0)
                        {
                            validatedVehicleDetails.Add("OwnerName", ownerName);
                        }
                        else
                        {
                            throw new FormatException("Owner name cannot be empty!");
                        }
                        break;

                    case "OwnerPhoneNumber":
                        int.Parse((string)detail.Value);
                        validatedVehicleDetails.Add("OwnerPhoneNumber", detail.Value);
                        break;

                    case "CurrentEnergy":
                        float.Parse((string)detail.Value);
                        validatedVehicleDetails.Add("CurrentEnergy", detail.Value); // NEED TO BE VALIDATED (!!!)
                        break;

                    default:
                        break;
                }
            }

            return validatedVehicleDetails;
        }*/

       /* private static GarageManager.eVehicleType GetVehicleType(object i_TypeAsString)
        {
            int vehicleTypeAsInt = (int)i_TypeAsString;
            GarageManager.eVehicleType vehicleType;

            if (vehicleTypeAsInt == 1)
            {
                vehicleType = GarageManager.eVehicleType.GasCar;
            }
            else if (vehicleTypeAsInt == 2)
            {
                vehicleType = GarageManager.eVehicleType.ElectricCar;
            }
            else if (vehicleTypeAsInt == 3)
            {
                vehicleType = GarageManager.eVehicleType.GasMotorcycle;
            }
            else if (vehicleTypeAsInt == 4)
            {
                vehicleType = GarageManager.eVehicleType.ElectricMotorcycle;
            }
            else if (vehicleTypeAsInt == 5)
            {
                vehicleType = GarageManager.eVehicleType.Truck;
            }
            else
            {
                throw new ValueOutOfRangeException(1, 5);
            }

            return vehicleType;
        }*/

        public static float GetEnergyAmountToAdd()
        {
            bool isValidEnergy = false;
            float energyToAdd = 0;
            while (!isValidEnergy)
            {
                try
                {
                    Console.WriteLine("Enter the amount of energy you want to add: ");
                    energyToAdd = float.Parse(Console.ReadLine());
                    isValidEnergy = true;
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return energyToAdd;
        }
    }