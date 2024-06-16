using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Implent tires
/// catch in run function
/// overall lookout
/// delete duplicates function
/// add known params to function 7
/// myabe change set owner
/// 
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
                            //TODO CAHNGE TO BOOL
                            uiManager.ChargeOrFuelVehicle(userChoice);
                            break;
                        case 6:
                            uiManager.ChargeOrFuelVehicle(userChoice);
                            break;
                        case 7:
                            uiManager.GetVehicleDetailsByLicensePlate();
                            break;
                    }
                }
                catch // need to think about that 
                {

                }
            }
        }
    }
}
