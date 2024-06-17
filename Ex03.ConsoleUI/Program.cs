using Ex03.GarageLogic.vehicle;
using System;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            Run();  
        }

        public static void Run() 
        {
            UIManager uiManager = new UIManager();
            VehicleFactory vehicleFactory = new VehicleFactory();
            const bool v_FuelTypeVehicle = true;
            const bool v_RunProgram = true;
            int userChoice;

            Console.WriteLine("Hello! Welcome to our garage");
            while(v_RunProgram)
            {
                try
                {
                    userChoice = uiManager.PrintMenuAndGetChoice();
                    switch (userChoice)
                    {
                        case 1:
                            uiManager.AddingCarToGarage(vehicleFactory);
                            break;
                        case 2:
                            uiManager.GetVehiclesStatus();
                            break;
                        case 3:
                            uiManager.ChangeVehicleInGarageStatus();
                            break;
                        case 4:
                            uiManager.InflatingTireToMax();
                            break;
                        case 5:
                            uiManager.ChargeOrFuelVehicle(v_FuelTypeVehicle);
                            break;
                        case 6:
                            uiManager.ChargeOrFuelVehicle(!v_FuelTypeVehicle);
                            break;
                        case 7:
                            uiManager.GetVehicleDetailsByLicensePlate();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
