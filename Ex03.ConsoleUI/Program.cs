using Ex03.GarageLogic.vehicle;
using System;

/// <summary>
/// Implent tires ---------------------- done
/// catch in run function -------------- done? needs more testing but so far it looks fine
/// overall lookout -------------------- need to do at the end
/// add known params to function 7 ----- didn't understand what you meant, so not done
/// maybe do get parameters also in the engine to avoid duplicte code?
/// </summary> 

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
            int userChoice;

            Console.WriteLine("Hello! Welcome to our garage");
            while (true)
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
