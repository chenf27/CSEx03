using Ex03.GarageLogic;
using Ex03.GarageLogic.vehicle;
using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.GarageManager; //TODO remove this when we fix the code and use exceptions

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

        public void PuttingCarToGarage()
        {
            string licensePlate;
            VehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle vehicle;
            int userSelectedVehicle;
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
                userSelectedVehicle = getVehicleType(vehicleFactory);
               // userSelectedVehicle = m_GarageManager.GetEnumSelection(vehicleFactory.GetType());
                vehicle =  vehicleFactory.InitializeVehicle(userSelectedVehicle);
                //TODO InitializeVehicle change name
                parameters = getVehicleParameters(vehicle);
                vehicle.Initialize(parameters);
                owner = SetOwnerDetails();
                m_GarageManager.EnterVehicleToGarage(vehicle, owner);
            }
        }

        private int getVehicleType(VehicleFactory i_VehicleFactory)
        {
            VehicleFactory.eVehicleType[] supportedVehicles;
            int counter = 1, userSelectedVehicle;

            Console.WriteLine("Please select yout vehicle type:");
            supportedVehicles = i_VehicleFactory.GetSupportedVehicleTypes();
            foreach (var supportedVehicleType in supportedVehicles)
            {
                Console.WriteLine(counter + " - {0}", supportedVehicleType);
                counter++;
            }
            int.TryParse(Console.ReadLine(), out userSelectedVehicle);
            //TODO GOOD VEHICLE TYPE?

            return userSelectedVehicle;
        }

        private Dictionary<string, Object> getVehicleParameters(Vehicle i_Vehicle)
        {
            Dictionary<string, Type> keyValuePairs;
            Dictionary<string, Object> parameters = new Dictionary<string, Object>();
            bool choice;

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
                    //TODO NEED THINKING
                    Console.WriteLine("1 - Yes");
                    Console.WriteLine("2 - No");
                    parameters[item.Key] = true;
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
        }

        //PREVIOUS FUNCTION
        public void AddVehicle()
        {
            string licensePlate;
            //VehicleFactory.eVehicleType vehicleType;
            VehicleFactory vehicleFactory = new VehicleFactory();
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
                // TODO: rewrite code according to the new structure - need to use Factory and its method GetParameters(), then print the parameters and get input.
                //       No need to check anythig about the input here, all the checks are inside the engine (it's fucking stupid but that's what he wants.
                //       We will wrap this entire block of code in a loop and a try block
                int supportedVehicleTypesIndex = 1;
                VehicleFactory.eVehicleType[] supportedVehicleTypes = vehicleFactory.GetSupportedVehicleTypes();
                Console.WriteLine("Please enter the type of your vehicle:");
                foreach(VehicleFactory.eVehicleType supportedVehicleType in supportedVehicleTypes)
                {
                    Console.WriteLine("{0}. {1}", supportedVehicleTypesIndex, supportedVehicleTypes[supportedVehicleTypesIndex]);
                }

                bool userChoiceIsInt = int.TryParse(Console.ReadLine(), out int userVehicleTypeChoice);
                if (!userChoiceIsInt)
                {
                    // throw exception
                    // ugly, this is temporary. you can change that as you like
                }
                
                vehicle = vehicleFactory.InitializeVehicle(userVehicleTypeChoice);
                Dictionary<string, Type> vehicleParameters = vehicle.GetParameters();
                // create new Dictionary<string, object> (for example call it initializedVehicleParameters.
                // foreach key in parameters ask user for input, then put it in the new dictionary like this:
                // initializedVehicleParameters[key] = userInput
                // all the verifications happen in the engine (or at lease they should)
                // then call the vehicle.Initialize() method with the new dictionary you created


                // ---------------------------------------PREVIOUS CODE---------------------------------------:

                /*Console.WriteLine(@"Please enter the type of your vehicle:
1 - Electric car
2 - Fuel car
3 - Electric motorcycle
4 - Fuel motorcycle
5 - Truck");
                int.TryParse(Console.ReadLine(), out int userVehicleTypeChoice);
                vehicleType = getVehicleType(userVehicleTypeChoice);
                vehicle = m_GarageManager.CreateVehicle(vehicleType);*/
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
            Console.WriteLine("Vehicles license plates:");
            if (choice == 4)
            {
                foreach (KeyValuePair<string, VehicleInGarage> vehicleInGarage in m_GarageManager.VehiclesByLicensePlate)
                {
                    Console.WriteLine(vehicleInGarage.Key);
                }
            }
            else
            {
                //TODO GENERY getEnumSelection
                status = convertStatus(choice);
                vehiclesStatus = m_GarageManager.GetLicensePlatesByStatus(status);
                foreach (string vehicles in vehiclesStatus)
                {
                    Console.WriteLine(vehicles);
                }
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


        //TODO
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

        private Motorcycle.eLicenseType convertMotorCycleLicenseType(int i_LicenseType)
        {
            Motorcycle.eLicenseType licenseType = Motorcycle.eLicenseType.A;
            switch (i_LicenseType)
            {
                case 1:
                    licenseType = Motorcycle.eLicenseType.A;
                    break;
                case 2:
                    licenseType = Motorcycle.eLicenseType.A1;
                    break;
                case 3:
                    licenseType = Motorcycle.eLicenseType.AA;
                    break;
                case 4:
                    licenseType = Motorcycle.eLicenseType.B1;
                    break;
            }

            return licenseType;
        }

        public VehicleInGarage.Owner SetOwnerDetails()
        {
            VehicleInGarage.Owner owner = new VehicleInGarage.Owner();

            Console.WriteLine("Please enter your name:");
            owner.Name = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");
            owner.Phone = Console.ReadLine();

            return owner;
        }

        public void ChargeOrFuelVehicle(int i_RequestNumber)
        {
            Dictionary<string, object> parameters;
            Vehicle vehicle;
            string licensePlate;

            Console.WriteLine("Please enter the Vehicle License Plate");
            licensePlate = Console.ReadLine();
            if(m_GarageManager.AlreadyInGarage(licensePlate))
            {
                if (i_RequestNumber == 5)
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
            //TODO ADD ELSE
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
            string fuelType;

            Console.WriteLine("Please enter how many liters to refuel");
            float.TryParse(Console.ReadLine(), out float amountToFuel);
            parameters["Liters To Add"] = amountToFuel;
            Console.WriteLine("Please enter your fuel type");
            fuelType = getEnumSelection(typeof(FuelEngine.eFuelType));
            parameters["Fuel Type"] = fuelType;

            return parameters;
        }

        private string getEnumSelection(Type i_enumType)
        {
            Array enumValues = Enum.GetValues(i_enumType);
            int counter = 1;
            string userInput;

            Console.WriteLine("Please select type:");
            foreach (var value in enumValues)
            {
                Console.WriteLine($"{counter} - {value}");
                counter++;
            }

            userInput = Console.ReadLine();

            return userInput;
        }
    }
}
