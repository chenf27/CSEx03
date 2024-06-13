using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine
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

        //public FuelTypeVehicleAttributes(eFuelType i_FuelType, float i_MaxFuelTankCapacity, float i_CurrentFuelTankCapacity)
        //{
        //    r_FuelType = i_FuelType;
        //    r_MaxFuelTankCapacity = i_MaxFuelTankCapacity;
        //    m_CurrentFuelTankCapacity = i_CurrentFuelTankCapacity;
        //}

        public FuelEngine(eFuelType i_FuelType, float i_MaxFuelTankCapacity)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelTankCapacity = i_MaxFuelTankCapacity;
        }

        public void Refueling(float i_LittersToAdd, eFuelType i_FuelType)
        {
            if (checkTankCapacity(i_LittersToAdd) && checkFuelType(i_FuelType))
            {
                m_CurrentFuelTankCapacity += i_LittersToAdd;
            }
            else
            {
                //PROBLEM!!
            }
        }

        private bool checkFuelType(eFuelType i_FuelType)
        {
            return i_FuelType == r_FuelType;
        }

        private bool checkTankCapacity(float i_LittersToAdd)
        {
            return i_LittersToAdd >= 0 && i_LittersToAdd + m_CurrentFuelTankCapacity <= r_MaxFuelTankCapacity;   
        }
    }
}
