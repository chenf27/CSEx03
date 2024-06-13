using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class FuelTypeCar : Car
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxFuelTankCapacity = 45;
        private FuelEngine m_FuelTypeAttributes = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);

        //public FuelTypeCar(FuelTypeVehicleAttributes i_FuelCar, eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        //: base(i_CarColor, i_NumOfDoors, i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        //{
        //    m_FuelTypeAttributes = i_FuelCar;
        //}

        
    }
}
