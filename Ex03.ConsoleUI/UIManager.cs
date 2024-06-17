using Ex03.GarageLogic;
using Ex03.GarageLogic.vehicle;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class UIManager
    {
        GarageManager m_GarageManager = new GarageManager();
        private const int k_AllVehiclesStatusIndex = 4;
        private const int k_MinimumUserChoiceValue = 1;
        private const int k_MaximumUserChoiceValue = 7;
        private const string k_VehicleNotInGarageMessage = "This vehicle is not in the garage!";
        private const string k_EnterLicensePlateMessage = "Please enter the license plate of the vehicle:";
        public int PrintMenuAndGetChoice()
        {
            int usersChoice = 0;
            string userInput;
            bool validInput = false;

            Console.WriteLine("Please select from the following options");
            while(!validInput)
            {
                Console.WriteLine(@"1 - Enter a vehicle to the garage
2 - See the License plates of the vehicles currently in the garage
3 - Change a vehicle status
4 - Tire inflation
5 - Vehicle refueling
6 - Vehicle charging
7 - Get vehicle details");
                userInput =  Console.ReadLine();
                if(int.TryParse(userInput, out usersChoice) && usersChoice >= k_MinimumUserChoiceValue && usersChoice <= k_MaximumUserChoiceValue)
                {
                    validInput = true;
                }
            }
            
            return usersChoice;
        }

        public void AddingCarToGarage(VehicleFactory i_VehicleFactory)
        {
            string licensePlate;
            Vehicle vehicle;
            int vehicleType;
            Dictionary<string, Object> vehicleParameters;
            VehicleInGarage.Owner owner;

            Console.WriteLine(k_EnterLicensePlateMessage);
            licensePlate = Console.ReadLine();
            if(m_GarageManager.IsVehicleInGarage(licensePlate))
            {
                Console.WriteLine("HOLA! The vehicle is already in our garage");
                m_GarageManager.SetVehicleInGarageStatus(licensePlate, VehicleInGarage.eStatus.UnderRepair);
            }
            else
            {
                vehicleType = getEnumSelection(typeof(VehicleFactory.eVehicleType));
                vehicle = i_VehicleFactory.CreateUninitializesVehicle(vehicleType);
                vehicleParameters = getVehicleParameters(vehicle, licensePlate);
                vehicle.Initialize(vehicleParameters);
                addTires(vehicle);
                owner = SetOwnerDetails();
                m_GarageManager.EnterVehicleToGarage(vehicle, owner);
            }
        }

        private void addTires(Vehicle io_Vehicle)
        {
            bool airPressureParsedSuccessfully;
            string tireManufacturer;

            Console.WriteLine("Please enter the tires manufaturer");
            tireManufacturer = Console.ReadLine();
            Console.WriteLine("Please enter the tires current air pressure");
            airPressureParsedSuccessfully = float.TryParse(Console.ReadLine(), out float currentAirPressure);
            if(!airPressureParsedSuccessfully)
            {
                throw new FormatException("Air pressure must be a valid number!");
            }

            m_GarageManager.InstallTiresOnVehicle(io_Vehicle, currentAirPressure, tireManufacturer);
        }

        private Dictionary<string, object> getVehicleParameters(Vehicle i_Vehicle, string i_LicensePlate)
        {
            Dictionary<string, Type> keyValuePairs;
            Dictionary<string, object> parametersToInitiateVehicle = new Dictionary<string, object>();
            string userChoice;

            parametersToInitiateVehicle["License Plate"] = i_LicensePlate;
            keyValuePairs = i_Vehicle.GetParameters();
            Console.WriteLine("Please enter the following parameters:");
            foreach(KeyValuePair<string, Type> item in keyValuePairs)
            {
                Console.WriteLine(item.Key);
                if(item.Value.IsEnum)
                {
                    parametersToInitiateVehicle[item.Key] = getEnumSelection(item.Value);
                }
                else if(item.Value == typeof(bool))
                {
                    Console.WriteLine("Enter Y if true, otherwise false:");
                    userChoice = Console.ReadLine();
                    parametersToInitiateVehicle[item.Key] = userChoice == "Y";
                }
                else
                {
                    parametersToInitiateVehicle[item.Key] = Console.ReadLine();
                }
            }

            return parametersToInitiateVehicle;
        }

        public void GetVehicleDetailsByLicensePlate()
        {
            string licensePlate;
            Dictionary<string, string> parameters;
            VehicleInGarage vehicleInGarage;

            Console.WriteLine(k_EnterLicensePlateMessage);
            licensePlate = Console.ReadLine();

            if(m_GarageManager.IsVehicleInGarage(licensePlate))
            {
                vehicleInGarage = m_GarageManager.VehiclesByLicensePlate[licensePlate];
                parameters = vehicleInGarage.Vehicle.GetFilledParameters();
                foreach(KeyValuePair<string, string> item in parameters)
                {
                    Console.WriteLine("{0}: {1}", item.Key, item.Value);
                }

                Console.WriteLine(@"Owner's name: {0}
Owner's cellphone number: {1}
Vehicle status: {2}", vehicleInGarage.OwnerDetails.Name, vehicleInGarage.OwnerDetails.Phone, vehicleInGarage.VehicleStatus);
            }
            else
            {
                Console.WriteLine(k_VehicleNotInGarageMessage);
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
            else if(userChoice < k_MinimumUserChoiceValue && userChoice > k_AllVehiclesStatusIndex)
            {
                throw new ValueOutOfRangeException(k_MinimumUserChoiceValue, k_AllVehiclesStatusIndex, "user choice for vehicle's status");
            }
            
            Console.WriteLine("Vehicles license plates:");
            if(userChoice == k_AllVehiclesStatusIndex)
            {
                foreach(KeyValuePair<string, VehicleInGarage> vehicleInGarage in m_GarageManager.VehiclesByLicensePlate)
                {
                    Console.WriteLine(vehicleInGarage.Key);
                }
            }
            else
            {
                vehiclesByStatus = m_GarageManager.GetLicensePlatesByStatus(userChoice);
                foreach(string vehicles in vehiclesByStatus)
                {
                    Console.WriteLine(vehicles);
                }
            }
        } 

        public void ChangeVehicleInGarageStatus()
        {
            string licensePlate;
            int newStatus;

            Console.WriteLine(k_EnterLicensePlateMessage);
            licensePlate = Console.ReadLine();
            if(m_GarageManager.IsVehicleInGarage(licensePlate))
            {
                newStatus = getEnumSelection(typeof(VehicleInGarage.eStatus));
                m_GarageManager.SetVehicleInGarageStatus(licensePlate, newStatus);
            }
            else
            {
                Console.WriteLine(k_VehicleNotInGarageMessage);
            }
        }

        public void InflatingTireToMax()
        {
            string licensePlate;
            float maxAirPressre, currentAirPressure, airPressureToAdd;
            Vehicle vehicle;

            Console.WriteLine(k_EnterLicensePlateMessage);
            licensePlate = Console.ReadLine();
            if(m_GarageManager.IsVehicleInGarage(licensePlate))
            {
                vehicle = m_GarageManager.VehiclesByLicensePlate[licensePlate].Vehicle;
                currentAirPressure = vehicle.Tires[0].CurrentAirPressure;
                maxAirPressre = vehicle.Tires[0].MaxAirPressure;
                airPressureToAdd = maxAirPressre - currentAirPressure;
                foreach(Tire tire in vehicle.Tires)
                {
                    tire.InflateTire(airPressureToAdd);
                }
            }
            else
            {
                Console.WriteLine(k_VehicleNotInGarageMessage);
            }
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

            Console.WriteLine(k_EnterLicensePlateMessage);
            licensePlate = Console.ReadLine();
            if(m_GarageManager.IsVehicleInGarage(licensePlate))
            {
                if(i_FuelTypeVehicle)
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
                Console.WriteLine(k_VehicleNotInGarageMessage);
            }
        }

        private Dictionary<string, object> chargeElectricVehicle()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            bool amountToChargeOrFuelParsedSuccessfully;
            
            Console.WriteLine("Please enter how many hours to charge");
            amountToChargeOrFuelParsedSuccessfully = float.TryParse(Console.ReadLine(), out float amountToChargeOrFuel);
            if(!amountToChargeOrFuelParsedSuccessfully)
            {
                throw new FormatException("Hours to charge must be a valid number!");
            }

            parameters["Hours To Charge"] = amountToChargeOrFuel;

            return parameters;
        }

        private Dictionary<string, object> reFuelVehicle()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            bool litersToRefuelOrFuelParsedSuccessfully;
            int fuelType;

            Console.WriteLine("Please enter how many liters to refuel");
            litersToRefuelOrFuelParsedSuccessfully = float.TryParse(Console.ReadLine(), out float amountToFuel);
            if(!litersToRefuelOrFuelParsedSuccessfully)
            {
                throw new FormatException("Liters to refuel must be a valid number!");
            }

            parameters["Liters To Add"] = amountToFuel;
            Console.WriteLine("Please enter your fuel type");
            fuelType = getEnumSelection(typeof(FuelEngine.eFuelType));
            parameters["Fuel Type"] = fuelType;

            return parameters;
        }

        private int getEnumSelection(Type i_EnumType)
        {
            Array enumValues = Enum.GetValues(i_EnumType);
            int counter = k_MinimumUserChoiceValue;
            string userInput;
            bool userInputParsedSuccessfully;

            Console.WriteLine("Please select type (by choosing the item's number):");
            foreach(Enum value in enumValues)
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
