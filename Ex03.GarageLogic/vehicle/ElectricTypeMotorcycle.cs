using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricTypeMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryLifeInHours = 2.5f;

        internal ElectricTypeMotorcycle()
        {
            base.m_Engine = new ElectricEngine(k_MaxBatteryLifeInHours);
        }
    }
}
