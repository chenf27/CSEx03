using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    internal class FuelTypeMotorcycle: Motorcycle
    {
        private FuelTypeVehicleAttributes m_FuelMotorcycle;

        public FuelTypeMotorcycle(FuelTypeVehicleAttributes i_FuelMotorcycle, eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank)
        : base(i_LicenseType, i_EngineCapacity, i_ModelName, i_LicensePlate, i_EnergyLeftInTank)
        {
            m_FuelMotorcycle = i_FuelMotorcycle;
        }
    }
}
