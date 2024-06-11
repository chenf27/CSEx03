using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
6 - Car charging
7 - Get car details");
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
            Console.WriteLine("Please enter the license plate of the vehicle");
            licensePlate = Console.ReadLine();
            if (m_GarageManager.AlreadyInGarage(licensePlate))
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
                //TODO GET CHOICE
                
            }
                

        }

    }
}
