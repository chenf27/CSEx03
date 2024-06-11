using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    internal class FuelTypeCar : Car
    {
        private FuelTypeVehicleAttributes m_FuelCar {  get; set; }

        public FuelTypeCar(FuelTypeVehicleAttributes i_FuelCar, eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank)
        : base(i_CarColor, i_NumOfDoors, i_ModelName, i_LicensePlate, i_EnergyLeftInTank)
        {
            m_FuelCar = i_FuelCar;
        }
    }
}
