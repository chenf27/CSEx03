using System;

/// <summary>
/// Implent tires ---------------------- not yet
/// catch in run function -------------- done? needs more testing but so far it looks fine
/// overall lookout -------------------- need to do at the end
/// delete duplicates function --------- deleted, but maybe I missed some
/// add known params to function 7 ----- didn't understand what you meant, so not done
/// myabe change set owner ------------- done
/// use generic function when possible - done
/// unify enum handlling in vehicles --- done
/// fixed some issues in engines ------- done
/// add consts in UIManager? ----------- your call
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
            const bool v_FuelTypeVehicle = true;
            int userChoice;

            while (true)
            {
                try
                {
                    userChoice = uiManager.PrintMenuAndGetChoice();
                    switch (userChoice)
                    {
                        case 1:
                            uiManager.PuttingCarToGarage();
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

                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
