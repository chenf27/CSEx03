using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricTypeCar : Car
    {
        private const float k_MaxBatteryLifeInHours = 3.5f;

        internal ElectricTypeCar()
        {
            m_Engine = new ElectricEngine(k_MaxBatteryLifeInHours);
        }
    }
}
