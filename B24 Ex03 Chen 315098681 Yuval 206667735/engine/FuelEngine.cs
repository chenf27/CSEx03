using Ex03.GarageLogic.engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelTankCapacity;
        private float m_CurrentAmountOfFuelInTank;

        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        public float CurrentAmountOfFuelInTank
        {
            get
            {
                return m_CurrentAmountOfFuelInTank;
            }
            set
            {
                if (value < 0 || value > r_MaxFuelTankCapacity)
                {
                    throw new ValueOutOfRangeException(0, r_MaxFuelTankCapacity);
                }
                m_CurrentAmountOfFuelInTank = value;
                m_EnergyLeftInTank = (m_CurrentAmountOfFuelInTank / r_MaxFuelTankCapacity) * 100;
            }
        }

        public FuelEngine(eFuelType i_FuelType, float i_MaxFuelTankCapacity)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelTankCapacity = i_MaxFuelTankCapacity;
        }

        public override void RefuelOrRecharge(Dictionary<string, object> i_Parameters)
        {
            float litersToAdd;
            bool fuelTypeParsedSuccessfully;

            if (!i_Parameters.ContainsKey("Liters To Add") || !i_Parameters.ContainsKey("Fuel Type"))
            {
                throw new ArgumentException("Missing parameters for refueling.");
            }

            litersToAdd = (float)i_Parameters["Liters To Add"];
            fuelTypeParsedSuccessfully = Enum.TryParse((string)i_Parameters["Fuel Type"], out eFuelType fuelType);
            if (!fuelTypeParsedSuccessfully)
            {
                throw new FormatException("Fuel type should be one of these: Soler, Octan95, Octan96, Octan98");
            }

            if (fuelType != r_FuelType)
            {
                throw new ArgumentException($"Invalid fuel type. Expected: {r_FuelType}");
            }

            CurrentAmountOfFuelInTank += litersToAdd;
        }


        /*public void Refueling(float i_LittersToAdd, eFuelType i_FuelType)
        {
            if (checkTankCapacity(i_LittersToAdd) && checkFuelType(i_FuelType))
            {
                m_CurrentAmountOfFuelInTank += i_LittersToAdd;
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
            return i_LittersToAdd >= 0 && i_LittersToAdd + m_CurrentAmountOfFuelInTank <= r_MaxFuelTankCapacity;   
        }*/
    }
}
