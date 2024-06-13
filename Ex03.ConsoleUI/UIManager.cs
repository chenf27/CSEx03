using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.GarageManager;

namespace Ex03.ConsoleUI
{
    internal class UIManager
    {
        GarageManager m_GarageManager = new GarageManager();

        public int PrintMenuAndGetChoice()
        {
            int usersChoice = 0;
            string userInput;
            bool validInput = false;

            Console.WriteLine("Hello, please select from the following options");
            while (!validInput)
            {
                Console.WriteLine(@"1 - Enter a vehicle to the garage
2 - See the License plates of the vehicles currently in the garage
3 - Change a vehicle status
4 - Tire inflation
5 - Vehicle refueling
6 - Vehicle charging
7 - Get vehicle details");
                userInput =  Console.ReadLine();
                if(int.TryParse(userInput, out usersChoice) && usersChoice >= 1 && usersChoice <= 7)
                {
                    validInput = true;
                }

            }
            
            return usersChoice;
        }

        public void AddVehicle()
        {
            string licensePlate;
            GarageManager.eVehicleType vehicleType;
            Vehicle vehicle;

            Console.WriteLine("Please enter the license plate of the vehicle");
            licensePlate = Console.ReadLine();
            if(m_GarageManager.AlreadyInGarage(licensePlate))
            {
                Console.WriteLine("HOLA! The vehicle is already in our garage");
                m_GarageManager.SetVehicleInGarageStatus(licensePlate, VehicleInGarage.eStatus.UnderRepair);
            }
            else
            {
                Console.WriteLine(@"Please enter the type of your vehicle:
1 - Electric car
2 - Fuel car
3 - Electric motorcycle
4 - Fuel motorcycle
5 - Truck");
                int.TryParse(Console.ReadLine(), out int userVehicleTypeChoice);    
                vehicleType = getVehicleType(userVehicleTypeChoice);
                vehicle = m_GarageManager.CreateVehicle(vehicleType);
                

                

            }
                

        }

        public void GetVehiclesStatus()
        {
            List<string> vehiclesStatus;
            int choice;
            VehicleInGarage.eStatus status;

            Console.WriteLine(@"Please enter the status you would like to see:
1 - Under repair
2 - Repaired
3 - Paid up
4 - All vehicles");
            int.TryParse(Console.ReadLine(), out choice);
            //TODO KELET
            status = convertStatus(choice);
            vehiclesStatus = m_GarageManager.GetLicensePlatesByStatus(status);

            foreach(string vehicles in vehiclesStatus) 
            { 
                Console.WriteLine(vehicles); 
            }
        }

        public void ChangeVehicleInGarageStatus()
        {
            string licensePlate;
            int choice;
            VehicleInGarage.eStatus newStatus;

            Console.WriteLine("Please enter your vehicle's license plate:");
            licensePlate = Console.ReadLine();
            Console.WriteLine(@"Please enter the new status:
1 - Under repair
2 - Repaired
3 - Paid up");
            int.TryParse(Console.ReadLine(), out choice);
            newStatus = convertStatus(choice);
            
            m_GarageManager.SetVehicleInGarageStatus(licensePlate, newStatus);

        }

        public void InflatingTireToMax()
        {
            string licensePlate;
            Console.WriteLine("Please enter your vehicle's license plate:");
            licensePlate = Console.ReadLine();

        }

        private VehicleInGarage.eStatus convertStatus(int i_Status)
        {
            VehicleInGarage.eStatus status = VehicleInGarage.eStatus.UnderRepair;
            switch(i_Status)
            {
                case 1:
                    status = VehicleInGarage.eStatus.UnderRepair; 
                    break;
                case 2:
                    status = VehicleInGarage.eStatus.Repaired;
                    break;
                case 3:
                    status = VehicleInGarage.eStatus.PaidUp;
                    break;
            }
            return status;
        }

        private Car.eCarColor convertCarColor(int i_CarColor)
        {
            Car.eCarColor carColor = Car.eCarColor.Red;
            switch (i_CarColor)
            {
                case 1:
                    carColor = Car.eCarColor.Yellow;
                    break;
                case 2:
                    carColor = Car.eCarColor.White;
                    break;
                case 3:
                    carColor = Car.eCarColor.Red;
                    break;
                case 4:
                    carColor = Car.eCarColor.Black;
                    break;
            }

            return carColor;
        }

        private GarageManager.eVehicleType getVehicleType(int i_UserVehicleType)
        {
            //TMP
            GarageManager.eVehicleType vehicleType = GarageManager.eVehicleType.ElectricCar;
            switch (i_UserVehicleType)
            {
                case 1:
                    vehicleType = GarageManager.eVehicleType.ElectricCar;
                    break;
                case 2:
                    vehicleType = GarageManager.eVehicleType.FuelCar;
                    break;
                case 3:
                    vehicleType = GarageManager.eVehicleType.ElectricMotorcycle;
                    break;
                case 4:
                    vehicleType = GarageManager.eVehicleType.FuelMotorcycle;
                    break;
                case 5:
                    vehicleType = GarageManager.eVehicleType.Truck;
                    break;
                default:
                    //TODO  EXDPTION
                    break;
            }
            return vehicleType;
        }

        private void getVehicleDetailsAndInitiate(GarageManager.eVehicleType i_VehicleType, Vehicle io_Vehicle, string i_LicensePlate)
        {
            string modelName;
            int numOfDoors;
            float percentOfEnergyLeftInTank;
            float airTirePressure;
            Car.eCarColor carColor;

            Console.WriteLine("Please enter the model name:");
            modelName = Console.ReadLine();
            Console.WriteLine("Please enter the percent of power left in your engine:");
            float.TryParse(Console.ReadLine(), out percentOfEnergyLeftInTank);
            Console.WriteLine("Please enter your current tire air pressure");
            float.TryParse(Console.ReadLine(), out airTirePressure);

            if(io_Vehicle is Car)
            {
                Console.WriteLine(@"What is your car's color?
1 - Yellow
2 - White
3 - Red
4 - Black");
                carColor = convertCarColor(int.Parse(Console.ReadLine()));
                Console.WriteLine("How many doors do you have in your car?");
                int.TryParse(Console.ReadLine(), out numOfDoors);
            }
            if(io_Vehicle is Truck)
            {
                Console.WriteLine(@"Does your truck contains hazardous materials?
1 - Yes
2 - No");
                bool.TryParse(Console.ReadLine(), out bool containsHazardousMaterials);
                
            }
            if (io_Vehicle is ElectricTypeCar || io_Vehicle is ElectricTypeMotorcycle)
            {
                Console.WriteLine();
            }
            else
            {
            }


        }
    }
}
