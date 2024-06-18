using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelTypeCar : Car
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxFuelTankCapacity = 45;

        internal FuelTypeCar()
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);
        }
    }
}
