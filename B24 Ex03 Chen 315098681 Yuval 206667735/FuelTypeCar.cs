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
        private FuelTypeVehicleAttributes m_FuelTypeAttributes {  get; set; }

        public FuelTypeCar(FuelTypeVehicleAttributes i_FuelCar, eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        : base(i_CarColor, i_NumOfDoors, i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        {
            m_FuelTypeAttributes = i_FuelCar;
        }
    }
}
