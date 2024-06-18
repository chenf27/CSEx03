using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class FuelTypeMotorcycle: Motorcycle
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
        private const float k_MaxFuelTankCapacity = 5.5f;

        internal FuelTypeMotorcycle()
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);
        }
    }
}
