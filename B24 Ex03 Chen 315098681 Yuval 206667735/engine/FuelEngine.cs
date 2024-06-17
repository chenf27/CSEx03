using Ex03.GarageLogic.engine;
using System;
using System.Collections.Generic;

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
                    throw new ValueOutOfRangeException(0, r_MaxFuelTankCapacity - m_CurrentAmountOfFuelInTank, "remaining fuel left in the tank");
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
            bool litersToAddParsedSuccessfully;
            bool fuelTypeParsedSuccessfully;

            if (!i_Parameters.ContainsKey("Liters To Add") || !i_Parameters.ContainsKey("Fuel Type"))
            {
                throw new ArgumentException("Missing parameters for refueling.");
            }

            litersToAddParsedSuccessfully = float.TryParse(i_Parameters["Liters To Add"].ToString(), out float litersToAdd);
            fuelTypeParsedSuccessfully = Enum.TryParse(i_Parameters["Fuel Type"].ToString(), out eFuelType fuelType);
            if (!litersToAddParsedSuccessfully)
            {
                throw new FormatException("Liters to add must be a vaid number");
            }

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


        
    }
}
