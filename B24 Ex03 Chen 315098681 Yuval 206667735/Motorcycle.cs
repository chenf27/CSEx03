using System;
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

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank)
        :base(i_ModelName, i_LicensePlate, i_EnergyLeftInTank)
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
