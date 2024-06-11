using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTypeVehicleAttributes
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelTankCapacity;
        private float m_CurrentFuelTankCapacity;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public FuelTypeVehicleAttributes(eFuelType i_FuelType, float i_MaxFuelTankCapacity, float i_CurrentFuelTankCapacity)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelTankCapacity = i_MaxFuelTankCapacity;
            m_CurrentFuelTankCapacity = i_CurrentFuelTankCapacity;
        }
    }
}
