public class ConsoleDisplay
   {
        public static void MainMenu()
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

        public static void VehicleTypeOptions()
        {
            Console.WriteLine(
@"Enter the vehicle type:
(1) - Gas car 
(2) - Electric car 
(3) - Gas Motorcycle
(4) - Electric Motorcycle
(5) - Truck");
        }

        public static void FilterStatusOptions()
        {
            Console.WriteLine(
@"Choose which license plates do you want to see:
(1) - InFix vehicles 
(2) - Fixed vehicles
(3) - Paid vehicles
(4) - All vehicles
");
        }

        public static void VehicleStates()
        {
            Console.WriteLine(
@"Enter the new vehicle's state:  
(1) - InFix 
(2) - Fixed 
(3) - Paid
");
        }

        public static void GasTypes()
        {
            Console.WriteLine(
@"Choose one of the following gas types:  
(1) - Soler
(2) - Octan95 
(3) - Octan96
(4) - Octan98
");
        }
    }