public class Display
   {
        public static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine(

@"####################################################
Hello and welcome to the garage!
####################################################
Choose an action from the following list:
####################################################
(1) - Insert a new vehicle to the garage
(2) - Display a list of license plates in the garage
(3) - Change a vehicle's status
(4) - Inflate a vehicle's wheels to maximum
(5) - Refuel a vehicle
(6) - Charge an electric vehicle
(7) - Display a vehicle's full details
(8) - Exit the garage
####################################################
");
        }

        public static void DisplayVehicleOptions()
        {

            Console.Clear();
            Console.WriteLine(
        @"Enter the vehicle type:
(1) - Gas car 
(2) - Electric car 
(3) - Motorcycle on gas
(4) - Electric Motorcycle
(5) - Truck");

        }
        public static void DisplayFilterOptions()
        {
            Console.Clear();
            Console.WriteLine(
@"Choose which license plates do you want to see:
(1) - All vehicles
(2) - InFix vehicles 
(3) - Fixed vehicles
(4) - Paid vehicles
");
        }
        public static void DisplayVehicleStates()
        {
            Console.Clear();
            Console.WriteLine(
@"Enter the new vehicle's state:  
(1) - InFix 
(2) - Fixed 
(3) - Paid
");
        }

        public static void DisplayInflateOptions()
        {
            Console.Clear();
            Console.WriteLine(
@"Here you can inflate the vehicle's wheels to the Max air pressure:  
(1) - Inflate to max
(2) - return to the main menu
");
        }


        public static void DisplayGasTypes()
        {
            Console.Clear();
            Console.WriteLine(
@"Choose one of the following gas types:  
(1) - Soler
(2) - Octan95 
(3) - Octan96
(4) - Octan98
");
        }
    }