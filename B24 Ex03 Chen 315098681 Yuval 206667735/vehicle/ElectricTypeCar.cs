using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricTypeCar : Car
    {
        private const float k_MaxBatteryLifeInHours = 3.5f;
        private ElectricEngine m_Engine = new ElectricEngine(k_MaxBatteryLifeInHours);

        //public ElectricTypeCar(ElectricTypeVehicleAttributes i_ElectricCar, eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        //: base(i_CarColor, i_NumOfDoors, i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        //{
        //    m_ElectricCar = i_ElectricCar;
        //}


        ElectricEngine ElectricEngine
        {
            get 
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }

    }
}
