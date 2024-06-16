using Ex03.GarageLogic;
using Ex03.GarageLogic.vehicle;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class UIManager
    {
        GarageManager m_GarageManager = new GarageManager();
        private const int k_AllVehiclesIndex = 4;

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

        public void PuttingCarToGarage()
        {
            string licensePlate;
            VehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle vehicle;
            int vehicleType;
            Dictionary<string, Object> parameters;
            VehicleInGarage.Owner owner;

            Console.WriteLine("Please enter the license plate of the vehicle");
            licensePlate = Console.ReadLine();
            if (m_GarageManager.AlreadyInGarage(licensePlate))
            {
                Console.WriteLine("HOLA! The vehicle is already in our garage");
                m_GarageManager.SetVehicleInGarageStatus(licensePlate, VehicleInGarage.eStatus.UnderRepair);
            }
            else
            {
                vehicleType = getEnumSelection(typeof(VehicleFactory.eVehicleType));
                vehicle =  vehicleFactory.CreateUninitializesVehicle(vehicleType);
                parameters = getVehicleParameters(vehicle, licensePlate);
                vehicle.Initialize(parameters);
                owner = SetOwnerDetails();
                m_GarageManager.EnterVehicleToGarage(vehicle, owner);
            }
        }

        private Dictionary<string, Object> getVehicleParameters(Vehicle i_Vehicle, string i_LicensePlate)
        {
            Dictionary<string, Type> keyValuePairs;
            Dictionary<string, Object> parameters = new Dictionary<string, Object>();
            string userChoice;

            parameters["License Plate"] = i_LicensePlate;
            keyValuePairs = i_Vehicle.GetParameters();
            Console.WriteLine("Please enter the following parameters:");
            foreach (KeyValuePair<string, Type> item in keyValuePairs)
            {
                Console.WriteLine(item.Key);
                if (item.Value.IsEnum)
                {
                    parameters[item.Key] = getEnumSelection(item.Value);
                }
                else if(item.Value == typeof(bool))
                {
                    Console.WriteLine("Enter Y if yes, otherwise no");
                    userChoice = Console.ReadLine();
                    parameters[item.Key] = userChoice == "Y";
                }
                else
                {
                    parameters[item.Key] = Console.ReadLine();
                }
            }

            return parameters;
        }

        public void GetVehicleDetailsByLicensePlate()
        {
            string licensePlate;
            Dictionary<string, string> parameters;
            VehicleInGarage vehicleInGarage;

            Console.WriteLine("Please enter your license Plate:");
            licensePlate = Console.ReadLine();

            if(m_GarageManager.AlreadyInGarage(licensePlate))
            {
                vehicleInGarage = m_GarageManager.VehiclesByLicensePlate[licensePlate];
                parameters = vehicleInGarage.Vehicle.GetFilledParameters();

                foreach(KeyValuePair<string, string> item in parameters)
                {
                    Console.WriteLine(item.Key);
                    Console.WriteLine(item.Value);
                }

                Console.WriteLine(@"Owner name
{0}
Owner cellphone number
{1}
Vehicle status
{3}", vehicleInGarage.OwnerDetails.Name, vehicleInGarage.OwnerDetails.Phone, vehicleInGarage.VehicleStatus);
            }
            else
            {
                Console.WriteLine("This vehicle is not in the garage!");
            }
        }

        public void GetVehiclesStatus()
        {
            List<string> vehiclesByStatus;
            bool userChoiceParsedSuccessfully;

            Console.WriteLine(@"Please enter the status you would like to see (by entering the correspondent number):
1 - Under repair
2 - Repaired
3 - Paid up
4 - All vehicles");
            userChoiceParsedSuccessfully = int.TryParse(Console.ReadLine(), out int userChoice);
            if(!userChoiceParsedSuccessfully) 
            {
                throw new FormatException("You must select the number of the option you'd like to see!");
            }
            else if(userChoice < 1 && userChoice > k_AllVehiclesIndex)
            {
                throw new ValueOutOfRangeException(1, k_AllVehiclesIndex, "user choice for vehicle's status");
            }
            
            Console.WriteLine("Vehicles license plates:");
            if (userChoice == k_AllVehiclesIndex)
            {
                foreach (KeyValuePair<string, VehicleInGarage> vehicleInGarage in m_GarageManager.VehiclesByLicensePlate)
                {
                    Console.WriteLine(vehicleInGarage.Key);
                }
            }
            else
            {
                vehiclesByStatus = m_GarageManager.GetLicensePlatesByStatus(userChoice);
                foreach (string vehicles in vehiclesByStatus)
                {
                    Console.WriteLine(vehicles);
                }
            }
        }

        public void ChangeVehicleInGarageStatus()
        {
            string licensePlate;
            int newStatus;

            Console.WriteLine("Please enter your vehicle's license plate:");
            licensePlate = Console.ReadLine();
            if(m_GarageManager.AlreadyInGarage(licensePlate))
            {
                newStatus = getEnumSelection(typeof(VehicleInGarage.eStatus));
                m_GarageManager.SetVehicleInGarageStatus(licensePlate, newStatus);
            }
            else
            {
                Console.WriteLine("This vehicle is not in the garage!");
            }
        }

        //TODO
        public void InflatingTireToMax()
        {
            string licensePlate;
            Console.WriteLine("Please enter your vehicle's license plate:");
            licensePlate = Console.ReadLine();

        }

        public VehicleInGarage.Owner SetOwnerDetails()
        {
            string name, phoneNumber;

            Console.WriteLine("Please enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");
            phoneNumber = Console.ReadLine();
            VehicleInGarage.Owner owner = new VehicleInGarage.Owner(name, phoneNumber);

            return owner;
        }

        public void ChargeOrFuelVehicle(bool i_FuelTypeVehicle)
        {
            Dictionary<string, object> parameters;
            Vehicle vehicle;
            string licensePlate;

            Console.WriteLine("Please enter the Vehicle License Plate");
            licensePlate = Console.ReadLine();
            if(m_GarageManager.AlreadyInGarage(licensePlate))
            {
                if (i_FuelTypeVehicle)
                {
                    parameters = reFuelVehicle();
                }
                else
                {
                    parameters = chargeElectricVehicle();
                }

                vehicle = m_GarageManager.VehiclesByLicensePlate[licensePlate].Vehicle;
                vehicle.Engine.RefuelOrRecharge(parameters);
            }
            else
            {
                Console.WriteLine("This vehicle is not in the garage!");
            }
        }

        private Dictionary<string, object> chargeElectricVehicle()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            Console.WriteLine("Please enter how many hours to charge");
            float.TryParse(Console.ReadLine(), out float amountToChargeOrFuel);
            parameters["Hours To Charge"] = amountToChargeOrFuel;

            return parameters;
        }

        private Dictionary<string, object> reFuelVehicle()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            int fuelType;

            Console.WriteLine("Please enter how many liters to refuel");
            float.TryParse(Console.ReadLine(), out float amountToFuel);
            parameters["Liters To Add"] = amountToFuel;
            Console.WriteLine("Please enter your fuel type");
            fuelType = getEnumSelection(typeof(FuelEngine.eFuelType));
            parameters["Fuel Type"] = fuelType;

            return parameters;
        }

        private int getEnumSelection(Type i_enumType)
        {
            Array enumValues = Enum.GetValues(i_enumType);
            int counter = 1;
            string userInput;
            bool userInputParsedSuccessfully;

            Console.WriteLine("Please select type (by choosing the item's number):");
            foreach (Enum value in enumValues)
            {
                Console.WriteLine(@"{0} - {1}", counter, value);
                counter++;
            }

            userInput = Console.ReadLine();
            userInputParsedSuccessfully = int.TryParse(userInput, out int userInputAsInt);
            if(!userInputParsedSuccessfully)
            {
                throw new FormatException("The value is not an integer!");
            }
            
            if(!validateSelectionRange(userInputAsInt, counter - 1))
            {
                throw new ValueOutOfRangeException(1, counter - 1, "the user's choice");
            }

            return userInputAsInt;
        }

        private bool validateSelectionRange(int i_UserChoice, int i_NumOfElements)
        {
            return i_UserChoice > 0 && i_UserChoice <= i_NumOfElements;
        }
    }
}
