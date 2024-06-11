﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected readonly eLicenseType r_LicenseType;
        protected readonly int r_EngineCapacity;
        public const float k_MaxAirPressure = 33;
        public const int k_NumOfTires = 2;

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        :base(i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }
        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B1
        }

        public int EngineCapacity
        {
            get
            {
                return r_EngineCapacity;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }
    }
}
