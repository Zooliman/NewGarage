class InputValidator
{
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
                System.Console.WriteLine("Please enter a number! " + ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        return userSelection;
    }

    private static bool checkForValidInput(int i_UserSelection, int i_MinValue, int i_MaxValue)
    {
        if (i_UserSelection >= i_MinValue && i_UserSelection <= i_MaxValue)
        {
            return true;
        }
        else
        {
            throw new ValueOutOfRangeException(i_MinValue, i_MaxValue);
        }
    }

    public static string GetDetailsAboutVehicle(string i_DetailsType)
    {
        // Console.Clear();
        System.Console.WriteLine("Please enter the vehicle's " + i_DetailsType + ": ");
        string userInput = Console.ReadLine();
        if (userInput.Length == 0)
        {
            throw new FormatException(string.Format("{0} must be non-empty!", i_DetailsType));
        }
        else
        {
            return userInput;
        }
    }

    public static bool IsCarryingDangerousMaterials()
    { 
        System.Console.WriteLine("Is the vehicle carrying dangerous materials? (0-False / 1-True) ");
        int userInput = int.Parse(Console.ReadLine());
        return userInput == 1;
    }

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